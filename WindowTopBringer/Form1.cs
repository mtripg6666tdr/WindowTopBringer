using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowTopBringer
{
    public partial class Form1 : Form
    {
        Dictionary<int,Process> HavingFormProcesses = null;
        HashSet<IntPtr> SettedProcesses = new HashSet<IntPtr>();

        public Form1()
        {
            this.InitializeComponent();

            this.OnEnter(new EventArgs());
        }

        #region Win32APIのロード
        [DllImport("USER32.dll", SetLastError =true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int uFlags);
        private const int SWP_NOSIZE     = 0x0001;
        private const int SWP_NOMOVE     = 0x0002;
        private const int SWP_SHOWWINDOW = 0x0040;
        private const int HWND_TOPMOST   = -1;
        private const int HWND_NOTOPMOST = -2;

        private void SetTopMost(Process targetProc)
        {
            SetWindowPos(
                targetProc.MainWindowHandle, 
                HWND_TOPMOST, 
                0, 0, 0, 0, 
                SWP_SHOWWINDOW | SWP_NOMOVE | SWP_NOSIZE);
            if (!this.SettedProcesses.Contains(targetProc.MainWindowHandle))
            {
                this.SettedProcesses.Add(targetProc.MainWindowHandle);
            }
            this.ResumeMainTopMost();
        }

        private void SetUnTopMost(Process targetProc)
        {
            SetWindowPos(
                targetProc.MainWindowHandle, 
                HWND_NOTOPMOST, 
                0, 0, 0, 0, 
                SWP_SHOWWINDOW | SWP_NOMOVE | SWP_NOSIZE);
            if (this.SettedProcesses.Contains(targetProc.MainWindowHandle))
            {
                this.SettedProcesses.Remove(targetProc.MainWindowHandle);
            }
            this.ResumeMainTopMost();
        }
        private void SetUnTopMost(IntPtr targetHandle)
        {
            SetWindowPos(
                targetHandle,
                HWND_NOTOPMOST,
                0, 0, 0, 0,
                SWP_SHOWWINDOW | SWP_NOMOVE | SWP_NOSIZE);
            if (this.SettedProcesses.Contains(targetHandle))
            {
                this.SettedProcesses.Remove(targetHandle);
            }
            this.ResumeMainTopMost();
        }
        #endregion

        private void Form1_Enter(object sender, EventArgs e)
        {
            this.ProcessesList.Items.Clear();
            this.HavingFormProcesses = new Dictionary<int, Process>();
            int i = 100;
            this.ProcessesList.ItemCheck -= new ItemCheckEventHandler(this.ProcessesList_ItemCheck);
            foreach (Process p in Process.GetProcesses())
            {
                if (p.MainWindowTitle.Length != 0)
                {
                    if (p.MainWindowTitle.Contains("WindowTopBringer"))
                    {
                        continue;
                    }
                    this.HavingFormProcesses.Add(i, p);
                    int index = this.ProcessesList.Items.Add(i.ToString() + ":" + p.MainWindowTitle, this.SettedProcesses.Contains(p.MainWindowHandle));
                    i++;
                }
            }
            this.ProcessesList.ItemCheck += new ItemCheckEventHandler(this.ProcessesList_ItemCheck);
            this.SettedProcesses.RemoveWhere(p => this.HavingFormProcesses.Where(q => q.Value.MainWindowHandle == p).Count() == 0);
            this.ResumeMainTopMost();
        }

        private void ResumeMainTopMost()
        {
            this.TopMost = this.SettedProcesses.Count != 0;
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            //this.ProcessesList.Items.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(IntPtr p in this.SettedProcesses)
            {
                this.SetUnTopMost(p);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.ReloadListButton.Text = "リストを更新";
        }

        private void ReapplyButton_Click(object sender, EventArgs e)
        {
            for(int i= 0; i < this.ProcessesList.Items.Count; i++)
            {
                try
                {
                    Process p = this.HavingFormProcesses[int.Parse(this.ProcessesList.Items[i].ToString().Split(':')[0])];
                    if (!p.HasExited)
                    {
                        if (this.ProcessesList.GetItemChecked(i))
                        {
                            this.SetTopMost(p);
                        }
                        else
                        {
                            this.SetUnTopMost(p);
                        }
                    }
                }
                catch
                {
                    continue;
                }
            }
        }

        private void ReloadListButton_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.timer1.Enabled = true;
            this.OnEnter(new EventArgs());
            this.ReloadListButton.Text = "更新しました";
        }

        private void ProcessesList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            while(true)
            {
                try
                {
                    Process p = this.HavingFormProcesses[int.Parse(this.ProcessesList.Items[e.Index].ToString().Split(':')[0])];
                    if (p.HasExited)
                    {
                        this.OnEnter(new EventArgs());
                        return;
                    }
                    if (e.NewValue == CheckState.Checked)
                    {
                        this.SetTopMost(p);
                    }
                    else
                    {
                        this.SetUnTopMost(p);
                    }
                    break;
                }
                catch (Exception)
                {
                    if(MessageBox.Show("設定に失敗しました。管理者権限でアプリを起動しなおすと正常に設定できることがあります。", "エラー", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) == DialogResult.Cancel)
                    {
                        break;
                    }
                }
            }
        }
    }
}

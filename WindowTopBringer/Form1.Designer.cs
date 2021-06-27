namespace WindowTopBringer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ReloadListButton = new System.Windows.Forms.Button();
            this.ReapplyButton = new System.Windows.Forms.Button();
            this.ProcessesList = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ReloadListButton);
            this.groupBox1.Controls.Add(this.ReapplyButton);
            this.groupBox1.Controls.Add(this.ProcessesList);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 243);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "最上位の設定";
            // 
            // ReloadListButton
            // 
            this.ReloadListButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReloadListButton.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.ReloadListButton.Location = new System.Drawing.Point(7, 193);
            this.ReloadListButton.Name = "ReloadListButton";
            this.ReloadListButton.Size = new System.Drawing.Size(289, 34);
            this.ReloadListButton.TabIndex = 3;
            this.ReloadListButton.Text = "リストを更新";
            this.ReloadListButton.UseVisualStyleBackColor = true;
            this.ReloadListButton.Click += new System.EventHandler(this.ReloadListButton_Click);
            // 
            // ReapplyButton
            // 
            this.ReapplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReapplyButton.Font = new System.Drawing.Font("MS UI Gothic", 13F);
            this.ReapplyButton.Location = new System.Drawing.Point(7, 155);
            this.ReapplyButton.Name = "ReapplyButton";
            this.ReapplyButton.Size = new System.Drawing.Size(289, 32);
            this.ReapplyButton.TabIndex = 2;
            this.ReapplyButton.Text = "再適用";
            this.ReapplyButton.UseVisualStyleBackColor = true;
            this.ReapplyButton.Click += new System.EventHandler(this.ReapplyButton_Click);
            // 
            // ProcessesList
            // 
            this.ProcessesList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessesList.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.ProcessesList.FormattingEnabled = true;
            this.ProcessesList.Location = new System.Drawing.Point(6, 18);
            this.ProcessesList.Name = "ProcessesList";
            this.ProcessesList.ScrollAlwaysVisible = true;
            this.ProcessesList.Size = new System.Drawing.Size(289, 130);
            this.ProcessesList.TabIndex = 0;
            this.ProcessesList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ProcessesList_ItemCheck);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 267);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "WindowTopBringer";
            this.Activated += new System.EventHandler(this.Form1_Enter);
            this.Deactivate += new System.EventHandler(this.Form1_Leave);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ReloadListButton;
        private System.Windows.Forms.Button ReapplyButton;
        private System.Windows.Forms.CheckedListBox ProcessesList;
    }
}


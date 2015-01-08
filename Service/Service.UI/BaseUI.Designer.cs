﻿namespace SOAFramework.Service.UI
{
    partial class BaseUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseUI));
            this.tlButtons = new System.Windows.Forms.ToolStrip();
            this.tbStart = new System.Windows.Forms.ToolStripButton();
            this.tbStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbClear = new System.Windows.Forms.ToolStripButton();
            this.ssBar = new System.Windows.Forms.StatusStrip();
            this.gpbCondition = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.niIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.txbMessage = new System.Windows.Forms.TextBox();
            this.tlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlButtons
            // 
            this.tlButtons.AutoSize = false;
            this.tlButtons.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbStart,
            this.tbStop,
            this.toolStripSeparator1,
            this.tbClear});
            this.tlButtons.Location = new System.Drawing.Point(0, 0);
            this.tlButtons.Name = "tlButtons";
            this.tlButtons.Size = new System.Drawing.Size(633, 26);
            this.tlButtons.TabIndex = 0;
            // 
            // tbStart
            // 
            this.tbStart.Image = ((System.Drawing.Image)(resources.GetObject("tbStart.Image")));
            this.tbStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(52, 23);
            this.tbStart.Text = "启动";
            this.tbStart.Click += new System.EventHandler(this.tbStart_Click);
            // 
            // tbStop
            // 
            this.tbStop.Image = ((System.Drawing.Image)(resources.GetObject("tbStop.Image")));
            this.tbStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbStop.Name = "tbStop";
            this.tbStop.Size = new System.Drawing.Size(52, 23);
            this.tbStop.Text = "停止";
            this.tbStop.Click += new System.EventHandler(this.tbStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // tbClear
            // 
            this.tbClear.Image = ((System.Drawing.Image)(resources.GetObject("tbClear.Image")));
            this.tbClear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbClear.Name = "tbClear";
            this.tbClear.Size = new System.Drawing.Size(76, 23);
            this.tbClear.Text = "清除文本";
            this.tbClear.Click += new System.EventHandler(this.tbClear_Click);
            // 
            // ssBar
            // 
            this.ssBar.Location = new System.Drawing.Point(0, 363);
            this.ssBar.Name = "ssBar";
            this.ssBar.Size = new System.Drawing.Size(633, 22);
            this.ssBar.TabIndex = 1;
            this.ssBar.Text = "statusStrip1";
            // 
            // gpbCondition
            // 
            this.gpbCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpbCondition.Location = new System.Drawing.Point(0, 26);
            this.gpbCondition.Name = "gpbCondition";
            this.gpbCondition.Size = new System.Drawing.Size(633, 67);
            this.gpbCondition.TabIndex = 2;
            this.gpbCondition.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // niIcon
            // 
            this.niIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("niIcon.Icon")));
            this.niIcon.Visible = true;
            this.niIcon.DoubleClick += new System.EventHandler(this.niIcon_DoubleClick);
            // 
            // txbMessage
            // 
            this.txbMessage.BackColor = System.Drawing.SystemColors.Control;
            this.txbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbMessage.Location = new System.Drawing.Point(0, 93);
            this.txbMessage.MaxLength = 2000;
            this.txbMessage.Multiline = true;
            this.txbMessage.Name = "txbMessage";
            this.txbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txbMessage.Size = new System.Drawing.Size(633, 270);
            this.txbMessage.TabIndex = 3;
            // 
            // BaseUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 385);
            this.Controls.Add(this.txbMessage);
            this.Controls.Add(this.gpbCondition);
            this.Controls.Add(this.ssBar);
            this.Controls.Add(this.tlButtons);
            this.Name = "BaseUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseUI_FormClosing);
            this.Load += new System.EventHandler(this.BaseUI_Load);
            this.tlButtons.ResumeLayout(false);
            this.tlButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip ssBar;
        public System.Windows.Forms.GroupBox gpbCondition;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStrip tlButtons;
        public System.Windows.Forms.ToolStripButton tbStart;
        public System.Windows.Forms.ToolStripButton tbStop;
        public System.Windows.Forms.ToolStripButton tbClear;
        protected System.Windows.Forms.NotifyIcon niIcon;
        protected System.Windows.Forms.TextBox txbMessage;
    }
}

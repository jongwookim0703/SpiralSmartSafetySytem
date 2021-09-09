
namespace testestestsettest
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tssFirstPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tssProcess1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssProcess2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssProcess3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssProcess4 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.stbClose = new System.Windows.Forms.ToolStripButton();
            this.stbExit = new System.Windows.Forms.ToolStripButton();
            this.tssRed = new System.Windows.Forms.ToolStripLabel();
            this.tssYellow = new System.Windows.Forms.ToolStripLabel();
            this.tssGreen = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.myTabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.myTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssFirstPage,
            this.tssProcess1,
            this.tssProcess2,
            this.tssProcess3,
            this.tssProcess4});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1113, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tssFirstPage
            // 
            this.tssFirstPage.Name = "tssFirstPage";
            this.tssFirstPage.Size = new System.Drawing.Size(123, 24);
            this.tssFirstPage.Text = "전체 공정 관리";
            this.tssFirstPage.Click += new System.EventHandler(this.tssFirstPage_Click);
            // 
            // tssProcess1
            // 
            this.tssProcess1.Name = "tssProcess1";
            this.tssProcess1.Size = new System.Drawing.Size(91, 24);
            this.tssProcess1.Text = "프로세스1";
            // 
            // tssProcess2
            // 
            this.tssProcess2.Name = "tssProcess2";
            this.tssProcess2.Size = new System.Drawing.Size(91, 24);
            this.tssProcess2.Text = "프로세스2";
            // 
            // tssProcess3
            // 
            this.tssProcess3.Name = "tssProcess3";
            this.tssProcess3.Size = new System.Drawing.Size(91, 24);
            this.tssProcess3.Text = "프로세스3";
            // 
            // tssProcess4
            // 
            this.tssProcess4.Name = "tssProcess4";
            this.tssProcess4.Size = new System.Drawing.Size(91, 24);
            this.tssProcess4.Text = "프로세스4";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssUserName,
            this.tssTimer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1113, 26);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(54, 20);
            this.toolStripStatusLabel1.Text = "관리자";
            // 
            // tssUserName
            // 
            this.tssUserName.Name = "tssUserName";
            this.tssUserName.Size = new System.Drawing.Size(0, 20);
            // 
            // tssTimer
            // 
            this.tssTimer.Name = "tssTimer";
            this.tssTimer.Size = new System.Drawing.Size(0, 20);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stbClose,
            this.stbExit,
            this.tssRed,
            this.tssYellow,
            this.tssGreen,
            this.toolStripLabel4,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1113, 27);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // stbClose
            // 
            this.stbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stbClose.Image = ((System.Drawing.Image)(resources.GetObject("stbClose.Image")));
            this.stbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbClose.Name = "stbClose";
            this.stbClose.Size = new System.Drawing.Size(29, 24);
            this.stbClose.Text = "close";
            this.stbClose.Click += new System.EventHandler(this.stbClose_Click);
            // 
            // stbExit
            // 
            this.stbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stbExit.Image = ((System.Drawing.Image)(resources.GetObject("stbExit.Image")));
            this.stbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stbExit.Name = "stbExit";
            this.stbExit.Size = new System.Drawing.Size(29, 24);
            this.stbExit.Text = "exit";
            this.stbExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stbExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.stbExit.Click += new System.EventHandler(this.stbExit_Click);
            // 
            // tssRed
            // 
            this.tssRed.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssRed.Name = "tssRed";
            this.tssRed.Size = new System.Drawing.Size(17, 24);
            this.tssRed.Text = "0";
            // 
            // tssYellow
            // 
            this.tssYellow.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssYellow.Name = "tssYellow";
            this.tssYellow.Size = new System.Drawing.Size(17, 24);
            this.tssYellow.Text = "0";
            // 
            // tssGreen
            // 
            this.tssGreen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssGreen.Name = "tssGreen";
            this.tssGreen.Size = new System.Drawing.Size(17, 24);
            this.tssGreen.Text = "0";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(109, 24);
            this.toolStripLabel4.Text = "현재 공정 상태";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // myTabControl1
            // 
            this.myTabControl1.Controls.Add(this.tabPage1);
            this.myTabControl1.Controls.Add(this.tabPage2);
            this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl1.Location = new System.Drawing.Point(0, 55);
            this.myTabControl1.Name = "myTabControl1";
            this.myTabControl1.SelectedIndex = 0;
            this.myTabControl1.Size = new System.Drawing.Size(1113, 545);
            this.myTabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1105, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(242, 92);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 626);
            this.Controls.Add(this.myTabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.myTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssTimer;
        private System.Windows.Forms.ToolStripButton stbExit;
        private System.Windows.Forms.ToolStripLabel tssRed;
        private System.Windows.Forms.ToolStripLabel tssYellow;
        private System.Windows.Forms.ToolStripLabel tssGreen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssUserName;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripMenuItem tssFirstPage;
        private System.Windows.Forms.ToolStripMenuItem tssProcess1;
        private System.Windows.Forms.ToolStripMenuItem tssProcess2;
        private System.Windows.Forms.ToolStripMenuItem tssProcess3;
        private System.Windows.Forms.ToolStripMenuItem tssProcess4;
        private System.Windows.Forms.ToolStripButton stbClose;
        private System.Windows.Forms.TabControl myTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
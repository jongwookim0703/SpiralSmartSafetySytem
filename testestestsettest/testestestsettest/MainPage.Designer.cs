
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tssMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssProcess1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssProcess2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssProcess3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssProcess4 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssSafety = new System.Windows.Forms.ToolStripMenuItem();
            this.tssMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.tssRecord = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSafety = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.myTabControl1 = new testestestsettest.MyTabControl();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssMenuItem1,
            this.tssMenuItem2,
            this.tssMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1282, 30);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tssMenuItem1
            // 
            this.tssMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssProcess1,
            this.tssProcess2,
            this.tssProcess3,
            this.tssProcess4});
            this.tssMenuItem1.Name = "tssMenuItem1";
            this.tssMenuItem1.Size = new System.Drawing.Size(123, 24);
            this.tssMenuItem1.Text = "전체 공정 관리";
            // 
            // tssProcess1
            // 
            this.tssProcess1.Name = "tssProcess1";
            this.tssProcess1.Size = new System.Drawing.Size(224, 26);
            this.tssProcess1.Tag = "1";
            this.tssProcess1.Text = "프로세스1";
            this.tssProcess1.Click += new System.EventHandler(this.tssProcess_Click);
            // 
            // tssProcess2
            // 
            this.tssProcess2.Name = "tssProcess2";
            this.tssProcess2.Size = new System.Drawing.Size(224, 26);
            this.tssProcess2.Tag = "2";
            this.tssProcess2.Text = "프로세스2";
            this.tssProcess2.Click += new System.EventHandler(this.tssProcess_Click);
            // 
            // tssProcess3
            // 
            this.tssProcess3.Name = "tssProcess3";
            this.tssProcess3.Size = new System.Drawing.Size(224, 26);
            this.tssProcess3.Tag = "3";
            this.tssProcess3.Text = "프로세스3";
            this.tssProcess3.Click += new System.EventHandler(this.tssProcess_Click);
            // 
            // tssProcess4
            // 
            this.tssProcess4.Name = "tssProcess4";
            this.tssProcess4.Size = new System.Drawing.Size(224, 26);
            this.tssProcess4.Tag = "4";
            this.tssProcess4.Text = "프로세스4";
            this.tssProcess4.Click += new System.EventHandler(this.tssProcess_Click);
            // 
            // tssMenuItem2
            // 
            this.tssMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSafety});
            this.tssMenuItem2.Name = "tssMenuItem2";
            this.tssMenuItem2.Size = new System.Drawing.Size(83, 24);
            this.tssMenuItem2.Text = "환경관리";
            // 
            // tssSafety
            // 
            this.tssSafety.Name = "tssSafety";
            this.tssSafety.Size = new System.Drawing.Size(182, 26);
            this.tssSafety.Tag = "ProcessSafety";
            this.tssSafety.Text = "환경모니터링";
            this.tssSafety.Click += new System.EventHandler(this.tssPage_Click);
            // 
            // tssMenuItem3
            // 
            this.tssMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssRecord});
            this.tssMenuItem3.Name = "tssMenuItem3";
            this.tssMenuItem3.Size = new System.Drawing.Size(83, 24);
            this.tssMenuItem3.Text = "이력관리";
            // 
            // tssRecord
            // 
            this.tssRecord.Name = "tssRecord";
            this.tssRecord.Size = new System.Drawing.Size(152, 26);
            this.tssRecord.Tag = "Record";
            this.tssRecord.Text = "가동이력";
            this.tssRecord.Click += new System.EventHandler(this.tssPage_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssUserName,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.tssTimer});
            this.statusStrip1.Location = new System.Drawing.Point(0, 927);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1282, 26);
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
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(404, 20);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(404, 20);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // tssTimer
            // 
            this.tssTimer.Name = "tssTimer";
            this.tssTimer.Size = new System.Drawing.Size(404, 20);
            this.tssTimer.Spring = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnSafety);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 36);
            this.panel1.TabIndex = 15;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1159, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 29);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.Location = new System.Drawing.Point(1101, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 29);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "⇐";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSafety
            // 
            this.btnSafety.Location = new System.Drawing.Point(585, 3);
            this.btnSafety.Name = "btnSafety";
            this.btnSafety.Size = new System.Drawing.Size(30, 29);
            this.btnSafety.TabIndex = 5;
            this.btnSafety.Tag = "ProcessSafety";
            this.btnSafety.Text = "button1";
            this.btnSafety.UseVisualStyleBackColor = true;
            this.btnSafety.Click += new System.EventHandler(this.btnSafety_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "공기 순환 상태";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Red;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(185, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(157, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Green;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(129, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "현재 공정 상태";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.myTabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1282, 861);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // myTabControl1
            // 
            this.myTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myTabControl1.Location = new System.Drawing.Point(3, 23);
            this.myTabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.myTabControl1.Name = "myTabControl1";
            this.myTabControl1.SelectedIndex = 0;
            this.myTabControl1.Size = new System.Drawing.Size(1276, 835);
            this.myTabControl1.TabIndex = 19;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 953);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainPage";
            this.Text = "스마트 안전 모니터링";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel tssTimer;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tssUserName;
        private System.Windows.Forms.ToolStripMenuItem tssMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tssMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tssMenuItem3;
        private testestestsettest.MyTabControl myTabControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSafety;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem tssProcess1;
        private System.Windows.Forms.ToolStripMenuItem tssProcess2;
        private System.Windows.Forms.ToolStripMenuItem tssProcess3;
        private System.Windows.Forms.ToolStripMenuItem tssProcess4;
        private System.Windows.Forms.ToolStripMenuItem tssSafety;
        private System.Windows.Forms.ToolStripMenuItem tssRecord;
    }
}
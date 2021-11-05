
namespace testestestsettest
{
    partial class ProcessDetail
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
            this.grid1 = new System.Windows.Forms.DataGridView();
            this.btn_detail1 = new System.Windows.Forms.Button();
            this.btn_stop1 = new System.Windows.Forms.Button();
            this.btn_work1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblYellow = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblRed = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblGreen = new System.Windows.Forms.Label();
            this.cbo_proces1 = new System.Windows.Forms.ComboBox();
            this.LblProcessName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chk_re1 = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_plan = new System.Windows.Forms.Button();
            this.txt_end = new System.Windows.Forms.TextBox();
            this.txt_start = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.vlcControl = new Vlc.DotNet.Forms.VlcControl();
            this.grid2 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.AllowDrop = true;
            this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grid1.Location = new System.Drawing.Point(3, 23);
            this.grid1.Margin = new System.Windows.Forms.Padding(4);
            this.grid1.Name = "grid1";
            this.grid1.RowHeadersWidth = 51;
            this.grid1.RowTemplate.Height = 25;
            this.grid1.Size = new System.Drawing.Size(536, 232);
            this.grid1.TabIndex = 1;
            // 
            // btn_detail1
            // 
            this.btn_detail1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_detail1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_detail1.Location = new System.Drawing.Point(49, 747);
            this.btn_detail1.Margin = new System.Windows.Forms.Padding(4);
            this.btn_detail1.Name = "btn_detail1";
            this.btn_detail1.Size = new System.Drawing.Size(93, 45);
            this.btn_detail1.TabIndex = 4;
            this.btn_detail1.Text = "상세보기";
            this.btn_detail1.UseVisualStyleBackColor = false;
            this.btn_detail1.Click += new System.EventHandler(this.btn_detail1_Click);
            // 
            // btn_stop1
            // 
            this.btn_stop1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_stop1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_stop1.Location = new System.Drawing.Point(0, 0);
            this.btn_stop1.Margin = new System.Windows.Forms.Padding(4);
            this.btn_stop1.Name = "btn_stop1";
            this.btn_stop1.Size = new System.Drawing.Size(91, 47);
            this.btn_stop1.TabIndex = 4;
            this.btn_stop1.Text = "중단";
            this.btn_stop1.UseVisualStyleBackColor = false;
            this.btn_stop1.Click += new System.EventHandler(this.btn_stop1_Click);
            // 
            // btn_work1
            // 
            this.btn_work1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_work1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_work1.Location = new System.Drawing.Point(130, 27);
            this.btn_work1.Margin = new System.Windows.Forms.Padding(4);
            this.btn_work1.Name = "btn_work1";
            this.btn_work1.Size = new System.Drawing.Size(96, 47);
            this.btn_work1.TabIndex = 4;
            this.btn_work1.Text = "가동";
            this.btn_work1.UseVisualStyleBackColor = false;
            this.btn_work1.Click += new System.EventHandler(this.btn_work1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cbo_proces1);
            this.groupBox1.Controls.Add(this.LblProcessName);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1227, 98);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.LblYellow);
            this.panel3.Location = new System.Drawing.Point(865, 49);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(48, 43);
            this.panel3.TabIndex = 13;
            // 
            // LblYellow
            // 
            this.LblYellow.AutoSize = true;
            this.LblYellow.BackColor = System.Drawing.Color.Yellow;
            this.LblYellow.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblYellow.Location = new System.Drawing.Point(5, -4);
            this.LblYellow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblYellow.Name = "LblYellow";
            this.LblYellow.Size = new System.Drawing.Size(40, 46);
            this.LblYellow.TabIndex = 14;
            this.LblYellow.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LblRed);
            this.panel2.Location = new System.Drawing.Point(912, 49);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(48, 43);
            this.panel2.TabIndex = 12;
            // 
            // LblRed
            // 
            this.LblRed.AutoSize = true;
            this.LblRed.BackColor = System.Drawing.Color.Red;
            this.LblRed.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblRed.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LblRed.Location = new System.Drawing.Point(6, -4);
            this.LblRed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblRed.Name = "LblRed";
            this.LblRed.Size = new System.Drawing.Size(40, 46);
            this.LblRed.TabIndex = 16;
            this.LblRed.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblGreen);
            this.panel1.Location = new System.Drawing.Point(820, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 43);
            this.panel1.TabIndex = 11;
            // 
            // LblGreen
            // 
            this.LblGreen.AutoSize = true;
            this.LblGreen.BackColor = System.Drawing.Color.Green;
            this.LblGreen.Font = new System.Drawing.Font("맑은 고딕", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LblGreen.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LblGreen.Location = new System.Drawing.Point(5, -4);
            this.LblGreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblGreen.Name = "LblGreen";
            this.LblGreen.Size = new System.Drawing.Size(40, 46);
            this.LblGreen.TabIndex = 15;
            this.LblGreen.Text = "0";
            // 
            // cbo_proces1
            // 
            this.cbo_proces1.FormattingEnabled = true;
            this.cbo_proces1.Location = new System.Drawing.Point(995, 25);
            this.cbo_proces1.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_proces1.Name = "cbo_proces1";
            this.cbo_proces1.Size = new System.Drawing.Size(187, 28);
            this.cbo_proces1.TabIndex = 10;
            this.cbo_proces1.Text = "프로세스1";
            this.cbo_proces1.SelectedIndexChanged += new System.EventHandler(this.cbo_proces1_SelectedIndexChanged);
            // 
            // LblProcessName
            // 
            this.LblProcessName.AutoSize = true;
            this.LblProcessName.Location = new System.Drawing.Point(543, 36);
            this.LblProcessName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProcessName.Name = "LblProcessName";
            this.LblProcessName.Size = new System.Drawing.Size(77, 20);
            this.LblProcessName.TabIndex = 4;
            this.LblProcessName.Text = "프로세스1";
            // 
            // panel4
            // 
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(810, 15);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(165, 33);
            this.panel4.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "공정 누적 알림 횟수";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_work1);
            this.groupBox2.Controls.Add(this.chk_re1);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Location = new System.Drawing.Point(897, 720);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(345, 84);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // chk_re1
            // 
            this.chk_re1.AutoSize = true;
            this.chk_re1.Location = new System.Drawing.Point(14, 40);
            this.chk_re1.Margin = new System.Windows.Forms.Padding(4);
            this.chk_re1.Name = "chk_re1";
            this.chk_re1.Size = new System.Drawing.Size(111, 24);
            this.chk_re1.TabIndex = 11;
            this.chk_re1.Text = "재가동 옵션";
            this.chk_re1.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_stop1);
            this.panel6.Location = new System.Drawing.Point(234, 28);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(91, 48);
            this.panel6.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_plan);
            this.groupBox3.Controls.Add(this.txt_end);
            this.groupBox3.Controls.Add(this.txt_start);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(13, 119);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1227, 71);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            // 
            // btn_plan
            // 
            this.btn_plan.Location = new System.Drawing.Point(1048, 22);
            this.btn_plan.Margin = new System.Windows.Forms.Padding(4);
            this.btn_plan.Name = "btn_plan";
            this.btn_plan.Size = new System.Drawing.Size(129, 39);
            this.btn_plan.TabIndex = 4;
            this.btn_plan.Text = "계획 등록";
            this.btn_plan.UseVisualStyleBackColor = true;
            this.btn_plan.Click += new System.EventHandler(this.btn_plan_Click);
            // 
            // txt_end
            // 
            this.txt_end.Location = new System.Drawing.Point(736, 27);
            this.txt_end.Margin = new System.Windows.Forms.Padding(4);
            this.txt_end.Name = "txt_end";
            this.txt_end.Size = new System.Drawing.Size(279, 27);
            this.txt_end.TabIndex = 3;
            // 
            // txt_start
            // 
            this.txt_start.Location = new System.Drawing.Point(165, 27);
            this.txt_start.Margin = new System.Windows.Forms.Padding(4);
            this.txt_start.Name = "txt_start";
            this.txt_start.Size = new System.Drawing.Size(306, 27);
            this.txt_start.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(580, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "계획 가동 마감 시간";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 31);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "계획 가동 시작 시간";
            // 
            // vlcControl
            // 
            this.vlcControl.BackColor = System.Drawing.Color.Black;
            this.vlcControl.Location = new System.Drawing.Point(14, 197);
            this.vlcControl.Margin = new System.Windows.Forms.Padding(4);
            this.vlcControl.Name = "vlcControl";
            this.vlcControl.Size = new System.Drawing.Size(680, 510);
            this.vlcControl.Spu = -1;
            this.vlcControl.TabIndex = 10;
            this.vlcControl.Text = "vlcControl1";
            this.vlcControl.VlcLibDirectory = null;
            this.vlcControl.VlcMediaplayerOptions = null;
            this.vlcControl.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlcControl_VlcLibDirectoryNeeded);
            // 
            // grid2
            // 
            this.grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2.Location = new System.Drawing.Point(3, 259);
            this.grid2.Margin = new System.Windows.Forms.Padding(4);
            this.grid2.Name = "grid2";
            this.grid2.RowHeadersWidth = 51;
            this.grid2.RowTemplate.Height = 25;
            this.grid2.Size = new System.Drawing.Size(536, 254);
            this.grid2.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grid2);
            this.groupBox4.Controls.Add(this.splitter1);
            this.groupBox4.Controls.Add(this.grid1);
            this.groupBox4.Location = new System.Drawing.Point(701, 197);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(542, 516);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(3, 255);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(536, 4);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // ProcessDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 817);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.vlcControl);
            this.Controls.Add(this.btn_detail1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProcessDetail";
            this.Text = "프로세스 관리";
            this.Load += new System.EventHandler(this.ProcessDetail_Load);
            this.Shown += new System.EventHandler(this.ProcessDetail_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlcControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grid1;
        private System.Windows.Forms.Button btn_detail1;
        private System.Windows.Forms.Button btn_stop1;
        private System.Windows.Forms.Button btn_work1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbo_proces1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblProcessName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.CheckBox chk_re1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_plan;
        private System.Windows.Forms.TextBox txt_end;
        private System.Windows.Forms.TextBox txt_start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Vlc.DotNet.Forms.VlcControl vlcControl;
        private System.Windows.Forms.DataGridView grid2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label LblGreen;
        private System.Windows.Forms.Label LblYellow;
        private System.Windows.Forms.Label LblRed;
    }
}
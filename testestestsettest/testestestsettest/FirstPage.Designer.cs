
namespace testestestsettest
{
    partial class FirstPage
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.vlc4 = new Vlc.DotNet.Forms.VlcControl();
            this.btn_process4 = new System.Windows.Forms.Button();
            this.lb_process4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.vlc3 = new Vlc.DotNet.Forms.VlcControl();
            this.btn_process3 = new System.Windows.Forms.Button();
            this.lb_process3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.vlc2 = new Vlc.DotNet.Forms.VlcControl();
            this.btn_process2 = new System.Windows.Forms.Button();
            this.lb_process2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.vlc1 = new Vlc.DotNet.Forms.VlcControl();
            this.btn_process1 = new System.Windows.Forms.Button();
            this.lb_process1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlc4)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlc3)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlc2)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1273, 163);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 23);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 51;
            this.grid.RowTemplate.Height = 29;
            this.grid.Size = new System.Drawing.Size(1267, 137);
            this.grid.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 163);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1273, 701);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.vlc4);
            this.groupBox7.Controls.Add(this.btn_process4);
            this.groupBox7.Controls.Add(this.lb_process4);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(837, 23);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(433, 675);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "프로세스4";
            // 
            // vlc4
            // 
            this.vlc4.BackColor = System.Drawing.Color.Black;
            this.vlc4.Location = new System.Drawing.Point(21, 68);
            this.vlc4.Name = "vlc4";
            this.vlc4.Size = new System.Drawing.Size(231, 181);
            this.vlc4.Spu = -1;
            this.vlc4.TabIndex = 10;
            this.vlc4.Text = "vlcControl1";
            this.vlc4.VlcLibDirectory = null;
            this.vlc4.VlcMediaplayerOptions = null;
            this.vlc4.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlc4_VlcLibDirectoryNeeded);
            // 
            // btn_process4
            // 
            this.btn_process4.Location = new System.Drawing.Point(85, 263);
            this.btn_process4.Name = "btn_process4";
            this.btn_process4.Size = new System.Drawing.Size(94, 29);
            this.btn_process4.TabIndex = 8;
            this.btn_process4.Tag = "4";
            this.btn_process4.Text = "상세화면";
            this.btn_process4.UseVisualStyleBackColor = true;
            this.btn_process4.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // lb_process4
            // 
            this.lb_process4.AutoSize = true;
            this.lb_process4.Location = new System.Drawing.Point(108, 37);
            this.lb_process4.Name = "lb_process4";
            this.lb_process4.Size = new System.Drawing.Size(58, 20);
            this.lb_process4.TabIndex = 6;
            this.lb_process4.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(37, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 25);
            this.label12.TabIndex = 5;
            this.label12.Text = "label12";
            this.label12.UseCompatibleTextRendering = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.vlc3);
            this.groupBox5.Controls.Add(this.btn_process3);
            this.groupBox5.Controls.Add(this.lb_process3);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(555, 23);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(282, 675);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "프로세스3";
            // 
            // vlc3
            // 
            this.vlc3.BackColor = System.Drawing.Color.Black;
            this.vlc3.Location = new System.Drawing.Point(24, 68);
            this.vlc3.Name = "vlc3";
            this.vlc3.Size = new System.Drawing.Size(231, 181);
            this.vlc3.Spu = -1;
            this.vlc3.TabIndex = 10;
            this.vlc3.Text = "vlcControl1";
            this.vlc3.VlcLibDirectory = null;
            this.vlc3.VlcMediaplayerOptions = null;
            this.vlc3.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlc3_VlcLibDirectoryNeeded);
            // 
            // btn_process3
            // 
            this.btn_process3.Location = new System.Drawing.Point(87, 263);
            this.btn_process3.Name = "btn_process3";
            this.btn_process3.Size = new System.Drawing.Size(94, 29);
            this.btn_process3.TabIndex = 8;
            this.btn_process3.Tag = "3";
            this.btn_process3.Text = "상세화면";
            this.btn_process3.UseVisualStyleBackColor = true;
            this.btn_process3.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // lb_process3
            // 
            this.lb_process3.AutoSize = true;
            this.lb_process3.Location = new System.Drawing.Point(111, 37);
            this.lb_process3.Name = "lb_process3";
            this.lb_process3.Size = new System.Drawing.Size(50, 20);
            this.lb_process3.TabIndex = 6;
            this.lb_process3.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(39, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "label10";
            this.label10.UseCompatibleTextRendering = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.vlc2);
            this.groupBox4.Controls.Add(this.btn_process2);
            this.groupBox4.Controls.Add(this.lb_process2);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(277, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 675);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "프로세스2";
            // 
            // vlc2
            // 
            this.vlc2.BackColor = System.Drawing.Color.Black;
            this.vlc2.Location = new System.Drawing.Point(21, 65);
            this.vlc2.Name = "vlc2";
            this.vlc2.Size = new System.Drawing.Size(231, 181);
            this.vlc2.Spu = -1;
            this.vlc2.TabIndex = 9;
            this.vlc2.Text = "vlcControl1";
            this.vlc2.VlcLibDirectory = null;
            this.vlc2.VlcMediaplayerOptions = null;
            this.vlc2.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlc2_VlcLibDirectoryNeeded);
            // 
            // btn_process2
            // 
            this.btn_process2.Location = new System.Drawing.Point(84, 263);
            this.btn_process2.Name = "btn_process2";
            this.btn_process2.Size = new System.Drawing.Size(94, 29);
            this.btn_process2.TabIndex = 8;
            this.btn_process2.Tag = "2";
            this.btn_process2.Text = "상세화면";
            this.btn_process2.UseVisualStyleBackColor = true;
            this.btn_process2.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // lb_process2
            // 
            this.lb_process2.AutoSize = true;
            this.lb_process2.Location = new System.Drawing.Point(105, 37);
            this.lb_process2.Name = "lb_process2";
            this.lb_process2.Size = new System.Drawing.Size(50, 20);
            this.lb_process2.TabIndex = 6;
            this.lb_process2.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 25);
            this.label8.TabIndex = 5;
            this.label8.Text = "label8";
            this.label8.UseCompatibleTextRendering = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.vlc1);
            this.groupBox6.Controls.Add(this.btn_process1);
            this.groupBox6.Controls.Add(this.lb_process1);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(3, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(274, 675);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "프로세스1";
            // 
            // vlc1
            // 
            this.vlc1.BackColor = System.Drawing.Color.Black;
            this.vlc1.Location = new System.Drawing.Point(21, 65);
            this.vlc1.Name = "vlc1";
            this.vlc1.Size = new System.Drawing.Size(229, 181);
            this.vlc1.Spu = -1;
            this.vlc1.TabIndex = 9;
            this.vlc1.Text = "vlcControl1";
            this.vlc1.VlcLibDirectory = null;
            this.vlc1.VlcMediaplayerOptions = null;
            this.vlc1.VlcLibDirectoryNeeded += new System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>(this.vlc1_VlcLibDirectoryNeeded);
            // 
            // btn_process1
            // 
            this.btn_process1.Location = new System.Drawing.Point(82, 263);
            this.btn_process1.Name = "btn_process1";
            this.btn_process1.Size = new System.Drawing.Size(94, 29);
            this.btn_process1.TabIndex = 8;
            this.btn_process1.Tag = "1";
            this.btn_process1.Text = "상세화면";
            this.btn_process1.UseVisualStyleBackColor = true;
            this.btn_process1.Click += new System.EventHandler(this.btn_process_Click);
            // 
            // lb_process1
            // 
            this.lb_process1.AutoSize = true;
            this.lb_process1.Location = new System.Drawing.Point(93, 37);
            this.lb_process1.Name = "lb_process1";
            this.lb_process1.Size = new System.Drawing.Size(50, 20);
            this.lb_process1.TabIndex = 6;
            this.lb_process1.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "label6";
            this.label6.UseCompatibleTextRendering = true;
            // 
            // FirstPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 864);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirstPage";
            this.Text = "FirstPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FirstPage_Load);
            this.VisibleChanged += new System.EventHandler(this.FirstPage_VisibleChanged);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlc4)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlc3)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlc2)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_process1;
        private System.Windows.Forms.Label lb_process1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_process4;
        private System.Windows.Forms.Label lb_process4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_process3;
        private System.Windows.Forms.Label lb_process3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_process2;
        private System.Windows.Forms.Label lb_process2;
        private System.Windows.Forms.Label label8;
        private Vlc.DotNet.Forms.VlcControl vlc1;
        private Vlc.DotNet.Forms.VlcControl vlc2;
        private Vlc.DotNet.Forms.VlcControl vlc4;
        private Vlc.DotNet.Forms.VlcControl vlc3;
    }
}
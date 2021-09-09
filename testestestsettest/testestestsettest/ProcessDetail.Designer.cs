
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.btn_detail1 = new System.Windows.Forms.Button();
            this.btn_stop1 = new System.Windows.Forms.Button();
            this.btn_work1 = new System.Windows.Forms.Button();
            this.vlc1 = new LibVLCSharp.WinForms.VideoView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_proces1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(633, 89);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 25;
            this.grid.Size = new System.Drawing.Size(155, 286);
            this.grid.TabIndex = 1;
            // 
            // btn_detail1
            // 
            this.btn_detail1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_detail1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_detail1.Location = new System.Drawing.Point(2, 1);
            this.btn_detail1.Name = "btn_detail1";
            this.btn_detail1.Size = new System.Drawing.Size(72, 34);
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
            this.btn_stop1.Name = "btn_stop1";
            this.btn_stop1.Size = new System.Drawing.Size(65, 35);
            this.btn_stop1.TabIndex = 4;
            this.btn_stop1.Text = "중단";
            this.btn_stop1.UseVisualStyleBackColor = false;
            this.btn_stop1.Click += new System.EventHandler(this.btn_stop1_Click);
            // 
            // btn_work1
            // 
            this.btn_work1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_work1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_work1.Location = new System.Drawing.Point(0, 0);
            this.btn_work1.Name = "btn_work1";
            this.btn_work1.Size = new System.Drawing.Size(75, 35);
            this.btn_work1.TabIndex = 4;
            this.btn_work1.Text = "가동";
            this.btn_work1.UseVisualStyleBackColor = false;
            this.btn_work1.Click += new System.EventHandler(this.btn_work1_Click);
            // 
            // vlc1
            // 
            this.vlc1.BackColor = System.Drawing.Color.Black;
            this.vlc1.Location = new System.Drawing.Point(33, 89);
            this.vlc1.MediaPlayer = null;
            this.vlc1.Name = "vlc1";
            this.vlc1.Size = new System.Drawing.Size(583, 286);
            this.vlc1.TabIndex = 5;
            this.vlc1.Text = "videoView1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.cbo_proces1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Location = new System.Drawing.Point(33, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 61);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // panel3
            // 
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(504, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(29, 20);
            this.panel3.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(7, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(544, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(37, 20);
            this.panel2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(12, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::testestestsettest.Properties.Resources.green;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(461, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(37, 20);
            this.panel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(11, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "0";
            // 
            // cbo_proces1
            // 
            this.cbo_proces1.FormattingEnabled = true;
            this.cbo_proces1.Location = new System.Drawing.Point(600, 19);
            this.cbo_proces1.Name = "cbo_proces1";
            this.cbo_proces1.Size = new System.Drawing.Size(146, 23);
            this.cbo_proces1.TabIndex = 10;
            this.cbo_proces1.Text = "프로세스1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "프로세스1";
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::testestestsettest.Properties.Resources.panel_gray_;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(456, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(128, 25);
            this.panel4.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "공적 누적 알림 횟수";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel7);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Location = new System.Drawing.Point(536, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 63);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btn_detail1);
            this.panel5.Location = new System.Drawing.Point(6, 21);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(75, 35);
            this.panel5.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btn_stop1);
            this.panel6.Location = new System.Drawing.Point(94, 22);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(65, 36);
            this.panel6.TabIndex = 9;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_work1);
            this.panel7.Location = new System.Drawing.Point(170, 21);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(76, 36);
            this.panel7.TabIndex = 9;
            // 
            // ProcessDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vlc1);
            this.Controls.Add(this.grid);
            this.Name = "ProcessDetail";
            this.Text = "ProcessDetail";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).EndInit();
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
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btn_detail1;
        private System.Windows.Forms.Button btn_stop1;
        private System.Windows.Forms.Button btn_work1;
        private LibVLCSharp.WinForms.VideoView vlc1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbo_proces1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
    }
}
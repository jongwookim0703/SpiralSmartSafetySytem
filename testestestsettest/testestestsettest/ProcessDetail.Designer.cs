
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cbo_proces1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.btn_detail1.Location = new System.Drawing.Point(6, 23);
            this.btn_detail1.Name = "btn_detail1";
            this.btn_detail1.Size = new System.Drawing.Size(75, 23);
            this.btn_detail1.TabIndex = 4;
            this.btn_detail1.Text = "상세보기";
            this.btn_detail1.UseVisualStyleBackColor = true;
            // 
            // btn_stop1
            // 
            this.btn_stop1.Location = new System.Drawing.Point(87, 22);
            this.btn_stop1.Name = "btn_stop1";
            this.btn_stop1.Size = new System.Drawing.Size(75, 23);
            this.btn_stop1.TabIndex = 4;
            this.btn_stop1.Text = "중단";
            this.btn_stop1.UseVisualStyleBackColor = true;
            // 
            // btn_work1
            // 
            this.btn_work1.Location = new System.Drawing.Point(168, 22);
            this.btn_work1.Name = "btn_work1";
            this.btn_work1.Size = new System.Drawing.Size(75, 23);
            this.btn_work1.TabIndex = 4;
            this.btn_work1.Text = "가동";
            this.btn_work1.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.cbo_proces1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(33, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 61);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_detail1);
            this.groupBox2.Controls.Add(this.btn_stop1);
            this.groupBox2.Controls.Add(this.btn_work1);
            this.groupBox2.Location = new System.Drawing.Point(536, 386);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 63);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(253, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "프로세스1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "공적 누적 알림 횟수";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(463, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(508, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(553, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "label5";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProcessDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vlc1);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.menuStrip1);
            this.Name = "ProcessDetail";
            this.Text = "ProcessDetail";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
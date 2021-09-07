
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
            this.grid_utility1 = new System.Windows.Forms.DataGridView();
            this.txt_processname1 = new System.Windows.Forms.TextBox();
            this.btn_detail1 = new System.Windows.Forms.Button();
            this.btn_stop1 = new System.Windows.Forms.Button();
            this.btn_work1 = new System.Windows.Forms.Button();
            this.vic_camera1 = new LibVLCSharp.WinForms.VideoView();
            this.txt_processname1_1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_alarm1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grid_utility1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vic_camera1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_utility1
            // 
            this.grid_utility1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_utility1.Location = new System.Drawing.Point(633, 89);
            this.grid_utility1.Name = "grid_utility1";
            this.grid_utility1.RowTemplate.Height = 25;
            this.grid_utility1.Size = new System.Drawing.Size(155, 286);
            this.grid_utility1.TabIndex = 1;
            // 
            // txt_processname1
            // 
            this.txt_processname1.Location = new System.Drawing.Point(6, 22);
            this.txt_processname1.Name = "txt_processname1";
            this.txt_processname1.Size = new System.Drawing.Size(262, 23);
            this.txt_processname1.TabIndex = 3;
            this.txt_processname1.Text = "프로세스1";
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
            // vic_camera1
            // 
            this.vic_camera1.BackColor = System.Drawing.Color.Black;
            this.vic_camera1.Location = new System.Drawing.Point(33, 89);
            this.vic_camera1.MediaPlayer = null;
            this.vic_camera1.Name = "vic_camera1";
            this.vic_camera1.Size = new System.Drawing.Size(583, 286);
            this.vic_camera1.TabIndex = 5;
            this.vic_camera1.Text = "videoView1";
            // 
            // txt_processname1_1
            // 
            this.txt_processname1_1.Location = new System.Drawing.Point(600, 22);
            this.txt_processname1_1.Name = "txt_processname1_1";
            this.txt_processname1_1.Size = new System.Drawing.Size(155, 23);
            this.txt_processname1_1.TabIndex = 3;
            this.txt_processname1_1.Text = "프로세스1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_alarm1);
            this.groupBox1.Controls.Add(this.txt_processname1);
            this.groupBox1.Controls.Add(this.txt_processname1_1);
            this.groupBox1.Location = new System.Drawing.Point(33, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 71);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // txt_alarm1
            // 
            this.txt_alarm1.Location = new System.Drawing.Point(321, 22);
            this.txt_alarm1.Name = "txt_alarm1";
            this.txt_alarm1.Size = new System.Drawing.Size(262, 23);
            this.txt_alarm1.TabIndex = 3;
            this.txt_alarm1.Text = "공정누적알림횟수";
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
            // ProcessDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.vic_camera1);
            this.Controls.Add(this.grid_utility1);
            this.Name = "ProcessDetail";
            this.Text = "ProcessDetail";
            ((System.ComponentModel.ISupportInitialize)(this.grid_utility1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vic_camera1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grid_utility1;
        private System.Windows.Forms.TextBox txt_processname1;
        private System.Windows.Forms.Button btn_detail1;
        private System.Windows.Forms.Button btn_stop1;
        private System.Windows.Forms.Button btn_work1;
        private LibVLCSharp.WinForms.VideoView vic_camera1;
        private System.Windows.Forms.TextBox txt_processname1_1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_alarm1;
    }
}
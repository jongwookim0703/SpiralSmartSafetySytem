
namespace testestestsettest
{
    partial class Record
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Record));
            this.grid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtHR4 = new System.Windows.Forms.TextBox();
            this.txtHR3 = new System.Windows.Forms.TextBox();
            this.txtHR2 = new System.Windows.Forms.TextBox();
            this.txtPR4 = new System.Windows.Forms.TextBox();
            this.txtPR3 = new System.Windows.Forms.TextBox();
            this.txtPR2 = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtPR1 = new System.Windows.Forms.TextBox();
            this.txtHR1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProcess = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.ColumnHeadersHeight = 29;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(6, 27);
            this.grid.Margin = new System.Windows.Forms.Padding(4);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 51;
            this.grid.RowTemplate.Height = 25;
            this.grid.Size = new System.Drawing.Size(986, 491);
            this.grid.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.grid);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 276);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.groupBox1.Size = new System.Drawing.Size(998, 525);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboProcess);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Location = new System.Drawing.Point(15, 16);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(998, 249);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(250, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "위험";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "접근 금지",
            "화재 발생"});
            this.comboBox1.Location = new System.Drawing.Point(297, 24);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 28);
            this.comboBox1.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox3.Controls.Add(this.txtHR4);
            this.groupBox3.Controls.Add(this.txtHR3);
            this.groupBox3.Controls.Add(this.txtHR2);
            this.groupBox3.Controls.Add(this.txtPR4);
            this.groupBox3.Controls.Add(this.txtPR3);
            this.groupBox3.Controls.Add(this.txtPR2);
            this.groupBox3.Controls.Add(this.btnSet);
            this.groupBox3.Controls.Add(this.txtPR1);
            this.groupBox3.Controls.Add(this.txtHR1);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(10, 66);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(982, 173);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "위험요소 별 누적 평균 순위";
            // 
            // txtHR4
            // 
            this.txtHR4.Location = new System.Drawing.Point(400, 135);
            this.txtHR4.Margin = new System.Windows.Forms.Padding(4);
            this.txtHR4.Name = "txtHR4";
            this.txtHR4.Size = new System.Drawing.Size(202, 27);
            this.txtHR4.TabIndex = 18;
            // 
            // txtHR3
            // 
            this.txtHR3.Location = new System.Drawing.Point(400, 99);
            this.txtHR3.Margin = new System.Windows.Forms.Padding(4);
            this.txtHR3.Name = "txtHR3";
            this.txtHR3.Size = new System.Drawing.Size(202, 27);
            this.txtHR3.TabIndex = 17;
            // 
            // txtHR2
            // 
            this.txtHR2.Location = new System.Drawing.Point(400, 64);
            this.txtHR2.Margin = new System.Windows.Forms.Padding(4);
            this.txtHR2.Name = "txtHR2";
            this.txtHR2.Size = new System.Drawing.Size(202, 27);
            this.txtHR2.TabIndex = 16;
            // 
            // txtPR4
            // 
            this.txtPR4.Location = new System.Drawing.Point(109, 136);
            this.txtPR4.Margin = new System.Windows.Forms.Padding(4);
            this.txtPR4.Name = "txtPR4";
            this.txtPR4.Size = new System.Drawing.Size(202, 27);
            this.txtPR4.TabIndex = 15;
            // 
            // txtPR3
            // 
            this.txtPR3.Location = new System.Drawing.Point(109, 101);
            this.txtPR3.Margin = new System.Windows.Forms.Padding(4);
            this.txtPR3.Name = "txtPR3";
            this.txtPR3.Size = new System.Drawing.Size(202, 27);
            this.txtPR3.TabIndex = 14;
            // 
            // txtPR2
            // 
            this.txtPR2.Location = new System.Drawing.Point(109, 66);
            this.txtPR2.Margin = new System.Windows.Forms.Padding(4);
            this.txtPR2.Name = "txtPR2";
            this.txtPR2.Size = new System.Drawing.Size(202, 27);
            this.txtPR2.TabIndex = 13;
            // 
            // btnSet
            // 
            this.btnSet.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSet.BackgroundImage")));
            this.btnSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSet.Location = new System.Drawing.Point(911, 125);
            this.btnSet.Margin = new System.Windows.Forms.Padding(4);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(61, 37);
            this.btnSet.TabIndex = 12;
            this.btnSet.Text = "새로고침";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPR1
            // 
            this.txtPR1.Location = new System.Drawing.Point(109, 31);
            this.txtPR1.Margin = new System.Windows.Forms.Padding(4);
            this.txtPR1.Name = "txtPR1";
            this.txtPR1.Size = new System.Drawing.Size(202, 27);
            this.txtPR1.TabIndex = 7;
            // 
            // txtHR1
            // 
            this.txtHR1.Location = new System.Drawing.Point(400, 29);
            this.txtHR1.Margin = new System.Windows.Forms.Padding(4);
            this.txtHR1.Name = "txtHR1";
            this.txtHR1.Size = new System.Drawing.Size(202, 27);
            this.txtHR1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(353, 33);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "위험";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "프로세스";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(702, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "날 짜";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "프로세스";
            // 
            // cboProcess
            // 
            this.cboProcess.FormattingEnabled = true;
            this.cboProcess.Items.AddRange(new object[] {
            "선택",
            "프로세스1",
            "프로세스2",
            "프로세스3",
            "프로세스4"});
            this.cboProcess.Location = new System.Drawing.Point(100, 23);
            this.cboProcess.Margin = new System.Windows.Forms.Padding(4);
            this.cboProcess.Name = "cboProcess";
            this.cboProcess.Size = new System.Drawing.Size(127, 28);
            this.cboProcess.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(921, 21);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 37);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(504, 24);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(190, 27);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(723, 23);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(190, 27);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1027, 817);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Record";
            this.Text = "Record";
            this.Load += new System.EventHandler(this.Record_Load);
            this.Shown += new System.EventHandler(this.Record_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProcess;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtPR1;
        private System.Windows.Forms.TextBox txtHR1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtPR4;
        private System.Windows.Forms.TextBox txtPR3;
        private System.Windows.Forms.TextBox txtPR2;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtHR4;
        private System.Windows.Forms.TextBox txtHR3;
        private System.Windows.Forms.TextBox txtHR2;
    }
}
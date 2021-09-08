using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testestestsettest
{
    public partial class ProcessSafety : Form
    {
        public ProcessSafety()
        {
            InitializeComponent();
            //체크박스를 그룹박스에 고정
            this.chkPro1.Location = new Point(this.groupBox2.Location.X + 13, this.groupBox2.Location.Y - 1);
            this.chkPro2.Location = new Point(this.groupBox3.Location.X + 13, this.groupBox3.Location.Y - 1);
            this.chkPro3.Location = new Point(this.groupBox4.Location.X + 13, this.groupBox4.Location.Y - 1);
            this.chkPro4.Location = new Point(this.groupBox5.Location.X + 13, this.groupBox5.Location.Y - 1);
        }

        private void chkPro1_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox2.Enabled = this.chkPro1.Checked;
        }
        private void chkPro2_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox3.Enabled = this.chkPro2.Checked;
        }
        private void chkPro3_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox4.Enabled = this.chkPro3.Checked;
        }
        private void chkPro4_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox5.Enabled = this.chkPro4.Checked;
        }
    }
}

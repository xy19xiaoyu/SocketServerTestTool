using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSDemo.Dialog
{
    public partial class FrmPort : Form
    {
        public FrmPort()
        {
            InitializeComponent();
        }
        public int Port
        {
            get
            {
                return (int)numericUpDown1.Value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

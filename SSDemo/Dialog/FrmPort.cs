using SSDemo.Config;
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
     
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (cmbEncoding.Text)
            {
                case "GB2312":
                    Configs.Encoding = Encoding.GetEncoding("gb2312");
                    break;
                case "ASCII":
                    Configs.Encoding = Encoding.ASCII;
                    break;
                case "UTF8":
                    Configs.Encoding = Encoding.UTF8;
                    break;
                case "Unicode":
                    Configs.Encoding = Encoding.Unicode;
                    break;
            }

            Configs.IP = this.txtIP.Text.Trim();
            Configs.Port = (int)this.numPort.Value;

            if (rbServer.Checked)
            {
                Configs.Type = "Server";
            }
            else
            {
                Configs.Type = "Client";
            }



            this.DialogResult = DialogResult.OK;
        }

        private void FrmPort_Load(object sender, EventArgs e)
        {
            cmbEncoding.Items.Clear();
            cmbEncoding.Items.Add("GB2312");
            cmbEncoding.Items.Add("ASCII");
            cmbEncoding.Items.Add("UTF8");
            cmbEncoding.Items.Add("Unicode");
            cmbEncoding.Text = "GB2312";
        }
    }
}

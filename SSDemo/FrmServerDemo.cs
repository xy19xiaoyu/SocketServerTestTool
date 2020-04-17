using SSDemo.Controller;
using SSDemo.Dialog;
using SSDemo.Model;
using SSDemo.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SSDemo
{
    public partial class FrmServerDemo : Form
    {
        public FrmServerDemo()
        {
            InitializeComponent();
        }
        private string LastDir
        {
            get
            {
                if (File.Exists("LastDir"))
                {
                    return File.ReadAllText("LastDir");
                }
                return "";
            }
            set
            {
                File.WriteAllText("LastDir", value);
            }
        }
        private void tsmOpenDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (string.IsNullOrEmpty(LastDir))
            {
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            }
            else
            {
                fbd.SelectedPath = LastDir;
            }

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var dir = fbd.SelectedPath;
                LastDir = dir;
                ShowCommand();
            }
        }
        private void ShowCommand()
        {
            if (!Directory.Exists(LastDir)) return;

            CommandController.LoadCommands(LastDir);

            this.lstFiles.DataSource = CommandController.Commands;
            this.lstFiles.DisplayMember = "Name";
            if (CommandController.Commands.Count > 0)
            {
                this.lstFiles.SelectedItem = CommandController.Commands.First();
            }
            BindHis();
        }
        private void BindHis()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = CommandController.His;
            lstHis.SelectedIndexChanged -= lstHis_SelectedIndexChanged;
            this.lstHis.DataSource = bs;
            this.lstHis.DisplayMember = "Name";
            lstHis.SelectedIndexChanged += lstHis_SelectedIndexChanged;
        }



        private Command LastSelect { get; set; }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCommand.Text)) return;
            AddConsole("Send", this.txtCommand.Text);
            // SendCommand();
            server.SendMessage(this.txtCommand.Text.Trim());
            AddHis();
        }
        private void AddConsole(string type, string content)
        {
            txtAll.Invoke((Action)delegate ()
            {
                txtAll.AppendText($"======================>>>{type} Start {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} <<<======================{Environment.NewLine}{Environment.NewLine}");
                txtAll.AppendText(content);
                txtAll.AppendText(Environment.NewLine);
                txtAll.AppendText(Environment.NewLine);
                txtAll.AppendText($"======================>>>{type} End  {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} <<<======================{Environment.NewLine}{Environment.NewLine}");
            });

        }
        private void AddHis()
        {
            if (LastSelect == null)
            {
                CommandController.AddHis(this.txtCommand.Text);
            }
            else
            {
                var cmd = new Command()
                {
                    Name = "",
                    Content = LastSelect.type == "json" ? this.txtCommand.Text.FormatJSON() : this.txtCommand.Text,
                    type = LastSelect.type
                };
                if (LastSelect.Name.IndexOf("_") > 0)
                {
                    var index = LastSelect.Name.LastIndexOf("_");
                    var name = DateTime.Now.ToString("yyMMddHHmmss") + LastSelect.Name.Substring(index);
                    cmd.Name = name;
                }
                else
                {

                    cmd.Name = DateTime.Now.ToString("yyMMddHHmmss");
                    cmd.Name += LastSelect.Name == "空" ? "" : "_" + LastSelect.Name;
                }

                CommandController.AddHis(cmd);
                //lstHis.DataSource = CommandController.His;
                //lstHis.DisplayMember = "Name";
                BindHis();
            }

        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem == null) return;
            LastSelect = lstFiles.SelectedItem as Command;
            this.txtCommand.Text = LastSelect.Content;
        }

        private void lstHis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstHis.SelectedItem == null) return;
            LastSelect = lstHis.SelectedItem as Command;
            this.txtCommand.Text = LastSelect.Content;
        }

        private SServer server { get; set; }

        private void FrmServerDemo_Load(object sender, EventArgs e)
        {
            FrmPort frm = new FrmPort();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SServer.MessageReceiveEvent -= Server_MessageReceiveEvent;
                SServer.MessageReceiveEvent += Server_MessageReceiveEvent;
                server = new SServer(frm.Port);

                ShowCommand();

            }
            else
            {
                Application.Exit();
            }

        }

        private void Server_MessageReceiveEvent(string msg)
        {
            AddConsole("Receive", msg.FormatJSON());
        }

        private void FrmServerDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Dispose();
        }
    }
}

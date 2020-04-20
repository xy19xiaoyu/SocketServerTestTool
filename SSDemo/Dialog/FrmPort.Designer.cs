namespace SSDemo.Dialog
{
    partial class FrmPort
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rbServer = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmbEncoding);
            this.panel1.Controls.Add(this.txtIP);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.rbServer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numPort);
            this.panel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 182);
            this.panel1.TabIndex = 0;
            // 
            // cmbEncoding
            // 
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEncoding.FormattingEnabled = true;
            this.cmbEncoding.Items.AddRange(new object[] {
            "UTF-8",
            "ASSIC",
            "GB2312"});
            this.cmbEncoding.Location = new System.Drawing.Point(110, 110);
            this.cmbEncoding.Name = "cmbEncoding";
            this.cmbEncoding.Size = new System.Drawing.Size(216, 20);
            this.cmbEncoding.TabIndex = 10;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(109, 52);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(217, 21);
            this.txtIP.TabIndex = 9;
            this.txtIP.Text = "127.0.0.1";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(216, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 16);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.Text = "TCP Client";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rbServer
            // 
            this.rbServer.AutoSize = true;
            this.rbServer.Checked = true;
            this.rbServer.Location = new System.Drawing.Point(100, 16);
            this.rbServer.Name = "rbServer";
            this.rbServer.Size = new System.Drawing.Size(83, 16);
            this.rbServer.TabIndex = 7;
            this.rbServer.TabStop = true;
            this.rbServer.Text = "TCP Server";
            this.rbServer.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "编码：";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(131, 144);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(138, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "启动";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP：";
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(109, 81);
            this.numPort.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(217, 21);
            this.numPort.TabIndex = 0;
            this.numPort.Value = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            // 
            // FrmPort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 196);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPort";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPort";
            this.Load += new System.EventHandler(this.FrmPort_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.RadioButton rbServer;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.ComboBox cmbEncoding;
    }
}
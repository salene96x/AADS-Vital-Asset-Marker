
namespace AADS.Views.VitalAsset
{
    partial class main
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPointLat = new System.Windows.Forms.TextBox();
            this.txtPointLng = new System.Windows.Forms.TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbManual = new System.Windows.Forms.RadioButton();
            this.rdbAuto = new System.Windows.Forms.RadioButton();
            this.tbPriority = new System.Windows.Forms.TrackBar();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtProvince = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.txtUnitStatus = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbRPerson = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnMark = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnConfirmEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 37);
            this.panel1.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("TH SarabunPSK", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(100, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vital Asset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 28);
            this.label2.TabIndex = 63;
            this.label2.Text = "Point lattitude : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 28);
            this.label3.TabIndex = 64;
            this.label3.Text = "Point longtitude : ";
            // 
            // txtPointLat
            // 
            this.txtPointLat.Enabled = false;
            this.txtPointLat.Location = new System.Drawing.Point(140, 124);
            this.txtPointLat.Name = "txtPointLat";
            this.txtPointLat.Size = new System.Drawing.Size(131, 28);
            this.txtPointLat.TabIndex = 65;
            this.txtPointLat.TextChanged += new System.EventHandler(this.txtPointLat_TextChanged);
            // 
            // txtPointLng
            // 
            this.txtPointLng.Enabled = false;
            this.txtPointLng.Location = new System.Drawing.Point(140, 158);
            this.txtPointLng.Name = "txtPointLng";
            this.txtPointLng.Size = new System.Drawing.Size(131, 28);
            this.txtPointLng.TabIndex = 66;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(44, 194);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(93, 28);
            this.lblType.TabIndex = 67;
            this.lblType.Text = "Asset Type : ";
            // 
            // cmbType
            // 
            this.cmbType.Enabled = false;
            this.cmbType.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Political",
            "Military",
            "Psychological",
            "Economic"});
            this.cmbType.Location = new System.Drawing.Point(140, 192);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(131, 36);
            this.cmbType.TabIndex = 68;
            this.cmbType.Text = "Asset Type";
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(65, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 28);
            this.label4.TabIndex = 69;
            this.label4.Text = "Priority : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(76, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 28);
            this.label5.TabIndex = 70;
            this.label5.Text = "Mode : ";
            // 
            // rdbManual
            // 
            this.rdbManual.AutoSize = true;
            this.rdbManual.Location = new System.Drawing.Point(140, 40);
            this.rdbManual.Name = "rdbManual";
            this.rdbManual.Size = new System.Drawing.Size(67, 26);
            this.rdbManual.TabIndex = 71;
            this.rdbManual.TabStop = true;
            this.rdbManual.Text = "Manual ";
            this.rdbManual.UseVisualStyleBackColor = true;
            this.rdbManual.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // rdbAuto
            // 
            this.rdbAuto.AutoSize = true;
            this.rdbAuto.Location = new System.Drawing.Point(140, 61);
            this.rdbAuto.Name = "rdbAuto";
            this.rdbAuto.Size = new System.Drawing.Size(50, 26);
            this.rdbAuto.TabIndex = 72;
            this.rdbAuto.TabStop = true;
            this.rdbAuto.Text = "Auto";
            this.rdbAuto.UseVisualStyleBackColor = true;
            this.rdbAuto.CheckedChanged += new System.EventHandler(this.rdb_CheckedChanged);
            // 
            // tbPriority
            // 
            this.tbPriority.Location = new System.Drawing.Point(173, 234);
            this.tbPriority.Maximum = 99;
            this.tbPriority.Minimum = 1;
            this.tbPriority.Name = "tbPriority";
            this.tbPriority.Size = new System.Drawing.Size(98, 45);
            this.tbPriority.TabIndex = 73;
            this.tbPriority.Value = 1;
            this.tbPriority.Scroll += new System.EventHandler(this.tbPriority_Scroll);
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(140, 234);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(27, 28);
            this.txtPriority.TabIndex = 74;
            this.txtPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPriority.TextChanged += new System.EventHandler(this.txtPriority_TextChanged);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(140, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 28);
            this.txtName.TabIndex = 76;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(37, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 28);
            this.lblName.TabIndex = 75;
            this.lblName.Text = "Asset Name : ";
            // 
            // txtProvince
            // 
            this.txtProvince.Location = new System.Drawing.Point(140, 268);
            this.txtProvince.Name = "txtProvince";
            this.txtProvince.Size = new System.Drawing.Size(131, 28);
            this.txtProvince.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(55, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 28);
            this.label6.TabIndex = 77;
            this.label6.Text = "Province : ";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(140, 302);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(131, 28);
            this.txtSize.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(84, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 28);
            this.label7.TabIndex = 79;
            this.label7.Text = "Size : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 28);
            this.label8.TabIndex = 81;
            this.label8.Text = "Response Unit : ";
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Items.AddRange(new object[] {
            "กองทหารราบที่ 1"});
            this.cmbUnit.Location = new System.Drawing.Point(140, 336);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(131, 30);
            this.cmbUnit.TabIndex = 82;
            this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // txtUnitStatus
            // 
            this.txtUnitStatus.Enabled = false;
            this.txtUnitStatus.Location = new System.Drawing.Point(140, 372);
            this.txtUnitStatus.Name = "txtUnitStatus";
            this.txtUnitStatus.Size = new System.Drawing.Size(131, 28);
            this.txtUnitStatus.TabIndex = 84;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(40, 372);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 28);
            this.label9.TabIndex = 83;
            this.label9.Text = "Unit Status : ";
            // 
            // cmbRPerson
            // 
            this.cmbRPerson.FormattingEnabled = true;
            this.cmbRPerson.Items.AddRange(new object[] {
            "พล.อ.ประยุทธ์ จันทร์โอชา"});
            this.cmbRPerson.Location = new System.Drawing.Point(140, 406);
            this.cmbRPerson.Name = "cmbRPerson";
            this.cmbRPerson.Size = new System.Drawing.Size(131, 30);
            this.cmbRPerson.TabIndex = 86;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1, 408);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 28);
            this.label10.TabIndex = 85;
            this.label10.Text = "Response Person : ";
            // 
            // btnMark
            // 
            this.btnMark.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMark.Location = new System.Drawing.Point(204, 46);
            this.btnMark.Name = "btnMark";
            this.btnMark.Size = new System.Drawing.Size(67, 38);
            this.btnMark.TabIndex = 87;
            this.btnMark.Text = "Mark";
            this.btnMark.UseVisualStyleBackColor = true;
            this.btnMark.Visible = false;
            this.btnMark.Click += new System.EventHandler(this.btnMark_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(6, 450);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(265, 52);
            this.btnConfirm.TabIndex = 88;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnConfirmEdit
            // 
            this.btnConfirmEdit.Font = new System.Drawing.Font("TH SarabunPSK", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmEdit.Location = new System.Drawing.Point(6, 508);
            this.btnConfirmEdit.Name = "btnConfirmEdit";
            this.btnConfirmEdit.Size = new System.Drawing.Size(265, 52);
            this.btnConfirmEdit.TabIndex = 89;
            this.btnConfirmEdit.Text = "Editting Confirm";
            this.btnConfirmEdit.UseVisualStyleBackColor = true;
            this.btnConfirmEdit.Visible = false;
            this.btnConfirmEdit.Click += new System.EventHandler(this.btnConfirmEdit_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnConfirmEdit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnMark);
            this.Controls.Add(this.cmbRPerson);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtUnitStatus);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProvince);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPriority);
            this.Controls.Add(this.tbPriority);
            this.Controls.Add(this.rdbAuto);
            this.Controls.Add(this.rdbManual);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtPointLng);
            this.Controls.Add(this.txtPointLat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("TH SarabunPSK", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "main";
            this.Size = new System.Drawing.Size(288, 821);
            this.Load += new System.EventHandler(this.main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPointLat;
        public System.Windows.Forms.TextBox txtPointLng;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbManual;
        private System.Windows.Forms.RadioButton rdbAuto;
        private System.Windows.Forms.TrackBar tbPriority;
        public System.Windows.Forms.TextBox txtPriority;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        public System.Windows.Forms.TextBox txtProvince;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbUnit;
        public System.Windows.Forms.TextBox txtUnitStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbRPerson;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnMark;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnConfirmEdit;
    }
}


namespace IPChecking
{
    partial class CheckBoxExp
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
            this.btnSubmit = new System.Windows.Forms.Button();
            this.chkVaccinationList = new System.Windows.Forms.CheckedListBox();
            this.cmbVaccinationStatus = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.chkVaccinationList);
            this.groupBox1.Controls.Add(this.cmbVaccinationStatus);
            this.groupBox1.Location = new System.Drawing.Point(62, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(116, 244);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(68, 26);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkVaccinationList
            // 
            this.chkVaccinationList.FormattingEnabled = true;
            this.chkVaccinationList.Location = new System.Drawing.Point(69, 82);
            this.chkVaccinationList.Name = "chkVaccinationList";
            this.chkVaccinationList.Size = new System.Drawing.Size(179, 130);
            this.chkVaccinationList.TabIndex = 1;
            // 
            // cmbVaccinationStatus
            // 
            this.cmbVaccinationStatus.FormattingEnabled = true;
            this.cmbVaccinationStatus.Items.AddRange(new object[] {
            "Vaccination",
            "Non Vaccination"});
            this.cmbVaccinationStatus.Location = new System.Drawing.Point(69, 42);
            this.cmbVaccinationStatus.Name = "cmbVaccinationStatus";
            this.cmbVaccinationStatus.Size = new System.Drawing.Size(179, 23);
            this.cmbVaccinationStatus.TabIndex = 0;
            this.cmbVaccinationStatus.SelectedIndexChanged += new System.EventHandler(this.cmbVaccinationStatus_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "First",
            "Second",
            "None"});
            this.listBox1.Location = new System.Drawing.Point(295, 82);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(132, 124);
            this.listBox1.TabIndex = 3;
            // 
            // CheckBoxExp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 363);
            this.Controls.Add(this.groupBox1);
            this.Name = "CheckBoxExp";
            this.Text = "CheckBoxExp";
            this.Load += new System.EventHandler(this.CheckBoxExp_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbVaccinationStatus;
        private System.Windows.Forms.CheckedListBox chkVaccinationList;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.ListBox listBox1;
    }
}
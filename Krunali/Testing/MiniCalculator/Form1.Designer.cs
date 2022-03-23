using Krunali_Test;
using System;

namespace MiniCalculator

{
    partial class Form1
    {
        Krunali_Test.Calculation c1 = new Calculation();
        private System.ComponentModel.IContainer components = null;
  
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndiv = new System.Windows.Forms.Button();
            this.btnmult = new System.Windows.Forms.Button();
            this.btnsub = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtno2 = new System.Windows.Forms.TextBox();
            this.txtno1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtres = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(146, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calculation";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btndiv);
            this.panel1.Controls.Add(this.btnmult);
            this.panel1.Controls.Add(this.btnsub);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.txtno2);
            this.panel1.Controls.Add(this.txtno1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(31, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 162);
            this.panel1.TabIndex = 1;
            // 
            // btndiv
            // 
            this.btndiv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btndiv.Location = new System.Drawing.Point(273, 115);
            this.btndiv.Name = "btndiv";
            this.btndiv.Size = new System.Drawing.Size(45, 32);
            this.btndiv.TabIndex = 7;
            this.btndiv.Text = "/";
            this.btndiv.UseVisualStyleBackColor = true;
            this.btndiv.Click += new System.EventHandler(this.btndiv_Click);
            // 
            // btnmult
            // 
            this.btnmult.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnmult.Location = new System.Drawing.Point(186, 115);
            this.btnmult.Name = "btnmult";
            this.btnmult.Size = new System.Drawing.Size(45, 32);
            this.btnmult.TabIndex = 6;
            this.btnmult.Text = "*";
            this.btnmult.UseVisualStyleBackColor = true;
            this.btnmult.Click += new System.EventHandler(this.btnmult_Click);
            // 
            // btnsub
            // 
            this.btnsub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsub.Location = new System.Drawing.Point(100, 115);
            this.btnsub.Name = "btnsub";
            this.btnsub.Size = new System.Drawing.Size(45, 32);
            this.btnsub.TabIndex = 5;
            this.btnsub.Text = "-";
            this.btnsub.UseVisualStyleBackColor = true;
            this.btnsub.Click += new System.EventHandler(this.btnsub_Click);
            // 
            // btnadd
            // 
            this.btnadd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnadd.Location = new System.Drawing.Point(19, 115);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(45, 32);
            this.btnadd.TabIndex = 4;
            this.btnadd.Text = "+";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtno2
            // 
            this.txtno2.Location = new System.Drawing.Point(169, 69);
            this.txtno2.Name = "txtno2";
            this.txtno2.Size = new System.Drawing.Size(100, 23);
            this.txtno2.TabIndex = 3;
            // 
            // txtno1
            // 
            this.txtno1.Location = new System.Drawing.Point(169, 22);
            this.txtno1.Name = "txtno1";
            this.txtno1.Size = new System.Drawing.Size(100, 23);
            this.txtno1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Enter No 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter No 1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(62, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Answer";
            // 
            // txtres
            // 
            this.txtres.Location = new System.Drawing.Point(200, 247);
            this.txtres.Name = "txtres";
            this.txtres.Size = new System.Drawing.Size(100, 23);
            this.txtres.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 297);
            this.Controls.Add(this.txtres);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtno2;
        private System.Windows.Forms.TextBox txtno1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtres;
        private System.Windows.Forms.Button btndiv;
        private System.Windows.Forms.Button btnmult;
        private System.Windows.Forms.Button btnsub;
    }
}


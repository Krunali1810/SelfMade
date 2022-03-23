using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPChecking
{
    public partial class CheckBoxExp : Form
    {
        public CheckBoxExp()
        {
            InitializeComponent();
        }

        private void CheckBoxExp_Load(object sender, EventArgs e)
        {

        }

        protected void loadItems()
        {
            chkVaccinationList.Visible = false;
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbVaccinationStatus.Items.Count>0)
            {
                if (chkVaccinationList .Items .Count >0)
                {
                    string a = cmbVaccinationStatus.SelectedValue.ToString ();
                    foreach (Object item in chkVaccinationList.CheckedItems)
                    {
                        //for get selected index
                        string b = item.ToString();

                         //   int index = chkVaccinationList.Items.IndexOf(item);
                            string val = chkVaccinationList.SelectedValue.ToString();
                        
                    }
                    //insert into (
                }
            }
        }

        private void cmbVaccinationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVaccinationStatus .Items .Count >0)
            {
                chkVaccinationList.Visible = true;
                DataSet ds=new DataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        chkVaccinationList.Items.Add(item["emp_name"].ToString());
                    }
                }
                //chkVaccinationList.DA
           }       

        }
    }
}

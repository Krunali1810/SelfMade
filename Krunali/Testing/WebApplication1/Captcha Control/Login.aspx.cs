using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace Captcha_Control
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillImageText();
            }
        }

        void FillImageText()
        {
            try
            {
                Random rdm = new Random();
                string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                StringBuilder ImgValue = new StringBuilder();
                for (int i = 0; i < 5; i++)
                {
                    ImgValue.Append(combination[rdm.Next(combination.Length)]);
                    Session["ImgValue"] = ImgValue.ToString();
                    btnImg.ImageUrl = "captchaimage.aspx?";
                }
            }
            catch
            {
                throw;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {     
            if (Session["ImgValue"].ToString() != txtImage.Text)
            {
                Response.Write("Invalid Image Code");
            }
            else
            {
                Response.Write("Valid Image Code");
                Response.Redirect("~/About.aspx");
            }
            FillImageText();
        }

        protected void btnRefresh_Click(object sender,EventArgs e)
        {
            FillImageText();
        }

    }
}
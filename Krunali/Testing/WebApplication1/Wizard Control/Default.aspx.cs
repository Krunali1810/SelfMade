using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wizard_Control
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string filePath = Server.MapPath("~/Reports/");
                this.Response.ContentType = "application/pdf";
                this.Response.AppendHeader("Content-Disposition;", "attachment;filename=");
                this.Response.WriteFile(filePath);
                this.Response.End();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //E:\Krunali\Project\GERMIS\GERMIS User Manual   GERMIS User Guidelines  (English)'
                string path = Server.MapPath("~/Scripts/GERMIS User Guidelines  (Gujarati).pdf");
                WebClient client = new WebClient();
                Byte[] buffer = client.DownloadData(path);

                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "Message", "window.open('application/pdf','_blank');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Error Message", "alert('" + ex.Message.ToString() + "')", true);
            }

            //Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
            //PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //Paragraph Text = new Paragraph("Hi , This is Test Content");
            //pdfDoc.Add(Text);
            //pdfWriter.CloseStream = false;
            //pdfDoc.Close();
            //Response.Buffer = true;
            //Response.ContentType = "application/pdf";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.End();
        }
    }
}
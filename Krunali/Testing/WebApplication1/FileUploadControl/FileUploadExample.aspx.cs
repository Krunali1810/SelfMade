using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUploadControl
{
    public partial class FileUploadExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                string fileName1 = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string Extension1 = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string filePath1 = Server.MapPath("UploadFile/" + fileName1);

                if (FileUpload1.PostedFile.ContentLength>100)
                {   
                    if ((Extension1.ToLower() == ".xls") || (Extension1.ToLower() == "xlsx"))
                    { 
                        FileUpload1.SaveAs(filePath1);
                    }
                }
            }

             if (FileUpload2.HasFile)
             {
                string fileName2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string filePath2 = Server.MapPath("UploadFile/" + fileName2);
                FileUpload2.SaveAs(filePath2);
             }
        }

        protected void FileUploadComplete(object sender, EventArgs e)
        {
            if (AsyncFileUpload1.HasFile)
            {
                string filename = Path.GetFileName(AsyncFileUpload1.PostedFile.FileName);
                string Extension = Path.GetExtension(AsyncFileUpload1.PostedFile.FileName);
                string file_Path = Server.MapPath("UploadFile/" + filename);

                if (AsyncFileUpload1.PostedFile.ContentLength > 100)
                {
                    if ((Extension.ToLower() == ".xls") || (Extension.ToLower() == "xlsx"))
                    {
                        AsyncFileUpload1.SaveAs(file_Path);
                        lblMesg.Text = "File Save successfully";

                    }
                    else
                    {
                     AsyncFileUpload1.Attributes.Add("bgcolor", "red");
                        lblMesg.Text = "Please choose correct file";
                    }
                }
                //string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            }
        }
    }
}
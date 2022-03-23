<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUploadExample.aspx.cs" Inherits="FileUploadControl.FileUploadExample" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        //function uploadComplete(sender) {
        //    $get("<%=lblMesg.ClientID%>").innerHTML = "File Uploaded Successfully";
        //}

        //function uploadError(sender) {
        //    $get("<%=lblMesg.ClientID%>").innerHTML = "File upload failed.";
        //    }
     
    </script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div>
            <asp:FileUpload ID="FileUpload1" accept=".png,.jpeg" runat="server" />

        </div>
       <br />
        <div>
            <asp:FileUpload ID="FileUpload2" accept=".xls,.xlsx,.docx" runat="server" />
        </div>


        <br />

        <div>
            </div>
        <div>
            <cc1:AsyncFileUpload 
                runat="server" ID="AsyncFileUpload1" Width="400px" UploaderStyle="Modern"
          OnUploadedComplete="FileUploadComplete" />
           <%-- OnClientUploadError="uploadError"
            OnClientUploadComplete="uploadComplete"--%>

        </div>
        <br />
        <div>
         <%--<cc1:AjaxFileUpload ID="AjaxFileUpload1" Mode="Auto" runat="server" />--%>
        </div>
        <br />
        <div>
            <asp:Label ID="lblMesg" runat="server"></asp:Label>
        </div>
        <br />
        <br />
       
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

    </form>  
</body>
</html>

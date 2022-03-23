<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateExample.aspx.cs" Inherits="DateExample.DateExample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <link type="text/css" href="../css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript" src="../js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.8.19.custom.min.js"></script>
    <script type="text/javascript">
        $(function ()
        {
            $(".forDatePicker").datepicker(
                {
                    dateFormat: 'mm/yy'
                   // yearRange: '1950:2000'
                }
            );
        });

      
    </script>
    <script>
        function ValidateDate()
        {
            var startrange = new Date(Date.parse("12/02/1900"));
            var endrange = new Date(Date.parse("12/31/2000"));
            var dt = document.getElementById("<%=txtDate.ClientID%>");
            var lblmesg = document.getElementById("<%=lblMesg.ClientID%>");
              if (dt < startrange || dt > endrange) {
                  lblmesg.style.color = "red";
                  lblmesg.innerHTML = "Date should be between 12/01/2014 and 12/31/2099";
              }
          }
    </script>

     <style type="text/css">
        .ui-datepicker 
        {
            font-size: 8pt !important;
            /*width: 500px;*/
        }
        .widget.widget-gray {
    background: #f5f5f5;
    clear:both;
}
        .clear{
            clear:both;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="lblExp">Enter Date</asp:Label>
            <br />
            <asp:TextBox ID="txtDate" class="form-control" runat="server" CssClass="form-control forDatePicker"></asp:TextBox>
            <asp:CustomValidator runat="server" ClientValidationFunction="ValidateDate" ControlToValidate="txtDate"
    ErrorMessage="Invalid Date." ValidationGroup="Group2" />
            <asp:Label ID="lblMesg" runat="server" ></asp:Label>
        </div>
    </form>
</body>
</html>

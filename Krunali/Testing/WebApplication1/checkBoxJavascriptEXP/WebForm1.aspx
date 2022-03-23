<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="checkBoxJavascriptEXP.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/jscript" >
    function showDiv(show) {
        var x = document.getElementById("ShowDiv");
  if (show) {
      x.show();
  } else {
      x.hide();
  }
}
</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:CheckBox ID="EnabledCheckBox" runat="server" OnClick="showDiv(this.checked);"/>
<div id="ShowDiv">Show me now</div>
<div id="ShowDiv">Show me now</div>
        </div>
    </form>
</body>
</html>

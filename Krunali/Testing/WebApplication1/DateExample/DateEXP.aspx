<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateEXP.aspx.cs" Inherits="DateExample.DateEXP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <%--     $(function(){
    var dtToday = new Date();
    
    var month = dtToday.getMonth() + 1;
    var day = dtToday.getDate();
    var year = dtToday.getFullYear();
    if(month < 10)
        month = '0' + month.toString();
    if(day < 10)
        day = '0' + day.toString();
    
    var maxDate = year + '-' + month + '-' + day;
    alert(maxDate);
    $('#txtDate').attr('min', maxDate);
});--%>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1"  runat="server">

        </asp:ScriptManager>

<asp:TextBox ID="txtDate" runat="server" ValidationGroup="DtVal"/>      

   <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"

    CultureName="en-GB" TargetControlID="txtDate"

    Mask="99 / 9999" MaskType="Date"  AcceptNegative="None"/>

    </form>
</body>
</html>

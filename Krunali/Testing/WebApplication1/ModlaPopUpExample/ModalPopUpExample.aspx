﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModalPopUpExample.aspx.cs" Inherits="ModlaPopUpExample.ModalPopUpExample" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>   


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Modal Example</title>
<link href="CSS/CSS.css" rel="stylesheet" type="text/css" /> 
<script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
<script src="scripts/jquery.blockUI.js" type="text/javascript"></script>
<script type = "text/javascript">

    function BlockUI(elementID)
    {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function ()
        {
            $("#" + elementID).block
                ({
                message: '<table align = "center"><tr><td>' +
                    '<img src="images/loadingAnim.gif"/></td></tr></table>',
                css: {},
                overlayCSS:
                {
                    backgroundColor: '#000000', opacity: 0.6
                }
            });
        });
        prm.add_endRequest(function ()
        {
            $("#" + elementID).unblock();
        });
    }
    $(document).ready(function ()
    {
        BlockUI("<%=pnlAddEdit.ClientID %>");
        $.blockUI.defaults.css = {};
    });
    function Hidepopup()
    {
        $find("popup").hide();
        return false;
    }
</script>
</head>

<body style ="margin:0;padding:0">
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

<asp:GridView ID="GridView1" runat="server" Width = "550px" AutoGenerateColumns = "false" AlternatingRowStyle-BackColor="#f2ddea" HeaderStyle-BackColor = "green" AllowPaging ="true" PageSize = "10" >
<Columns>
<asp:BoundField DataField = "CustomerID" HeaderText = "Customer ID" HtmlEncode = "true" HeaderStyle-BackColor="#f2ddea" />
<asp:BoundField DataField = "ContactName" HeaderText = "Contact Name" HtmlEncode = "true" HeaderStyle-BackColor="#f2ddea" />
<asp:BoundField DataField = "CompanyName" HeaderText = "Company Name" HtmlEncode = "true" HeaderStyle-BackColor="#f2ddea"/>
<asp:TemplateField ItemStyle-Width = "30px" HeaderText = "CustomerID" HeaderStyle-BackColor="#f2ddea">
   <ItemTemplate>
       <asp:LinkButton ID="lnkEdit" runat="server" Text = "Edit" ></asp:LinkButton>
   </ItemTemplate>
</asp:TemplateField>
</Columns>
<AlternatingRowStyle BackColor="#D69BC2" />    
</asp:GridView>

<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="Add"/>
<asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" style = "display:none">
<asp:Label Font-Bold="true" ID="lblCustomerDetail" runat="server" Text="Customer Details"></asp:Label>
<br />
<table align="center">
<tr>
<td>
<asp:Label ID="lblCustomerId" runat="server" Text="CustomerId"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtCustomerID" Width="40px" TextMode="Number" MaxLength="5" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblContactName" runat="server" Text="Contact Name"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtContactName" runat="server"></asp:TextBox>   
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblCompany" runat="server" Text="Company"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnSave" runat="server" Text="Save" OnClick = "Save" />
</td>
<td>
<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick="return Hidepopup()"/>
</td>
</tr>
</table>
</asp:Panel>

<asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
<cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
PopupControlID="pnlAddEdit" TargetControlID = "lnkFake"
BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>

</ContentTemplate>
<Triggers>
<asp:AsyncPostBackTrigger ControlID = "GridView1" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers>
</asp:UpdatePanel>
</form>

</body>
</html>

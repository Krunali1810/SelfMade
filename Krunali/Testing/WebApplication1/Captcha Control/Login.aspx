<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Captcha_Control.Login" MasterPageFile="~/Site.Master" %>


 <asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <table style="border: solid 1px inherit; padding: 15px; position: relative; top: 50px;">  
            <tr>  
                <td> Email ID </td>  
                <td>  
                    <asp:TextBox ID="txtEmailID" runat="server" Width="200px"></asp:TextBox>  
                </td>  
            </tr>  
            <tr>  
                <td> Password </td>  
                <td>  
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>  
                </td>  
            </tr>  
            <tr>  
                <td>  
                </td>  
                <td>  
                    <asp:UpdatePanel ID="UpdateImage" runat="server">  
                        <ContentTemplate>  
                            <table>  
                                <tr>  
                                    <td style="height: 40px; width:20px;">  
                                        <asp:Image ID="btnImg" runat="server" ImageUrl ="~/captchaimage.aspx"/>  
                                    </td>  
                                </tr>  
                            </table>  
                        </ContentTemplate>  
                    </asp:UpdatePanel>  
                </td>  
                <td>
                    <asp:LinkButton ID="btnRefresh" runat="server" onclick="btnRefresh_Click">Refresh captcha</asp:LinkButton>
                </td>
            </tr>  
            <tr>  
                <td> Enter Display Image Code </td>  
                <td>  
                    <asp:TextBox ID="txtImage" runat="server"></asp:TextBox>  
                </td>  
            </tr>  
            <tr>  
                <td></td>  
                <td colspan="2">  
                    <asp:Button ID="btnRegiser" runat="server" Text="Sign Up" OnClick="btnRegister_Click" />  
                </td>  
            </tr>  
        </table>  
   </asp:Content>


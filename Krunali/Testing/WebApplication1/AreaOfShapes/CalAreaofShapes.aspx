<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalAreaofShapes.aspx.cs" Inherits="AreaOfShapes.CalAreaofShapes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Area of Shapes</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script type="text/javascript"> $(document).ready(function () { $('#imgCaptcha').bind('contextmenu', function (e) { e.preventDefault(); }); }); </script>
</head>
<body>


    <div class="jumbotron text-center">
        <h1>Area of Shapes</h1>
         <p>Resize this responsive page to see the effect!</p>
    </div>

    <form id="frmShapes" runat="server" >
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <asp:Label ID="imgCaptcha" runat="server" CssClass="control-label well captcha" oncopy="return false" Text="321" onpaste="return false" oncut="return false" />
               Please select shape
             </div>
            <br />

            <div class="col-sm-4">
                <asp:DropDownList ID="ddlShapes" runat="server" OnSelectedIndexChanged="ddlShapes_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem runat="server">---Select---</asp:ListItem>
                    <asp:ListItem runat="server">Rectangle</asp:ListItem>
                    <asp:ListItem runat="server">Circle</asp:ListItem>
                    <asp:ListItem runat="server">Square</asp:ListItem>
                    <asp:ListItem runat="server">Triangle</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />

            </div>

            <div class="col-sm-4">
                <asp:Label ID="lblres" runat="server" Text="Result : " Visible="false"></asp:Label>
            <br />
            <br />
            <div class="col-sm-4">
                <asp:Label ID="lblresult" runat="server" Text="" Visible="false"></asp:Label>
            <br />
            <br />
            <div class="col-sm-4">
                    <asp:Panel ID="PanelRectangle" runat="server">    
                        <span>
                            <Table>
                                <tr>
                                    <td>
                                     <asp:Label ID="lbllenght" runat="server" CssClass="form-horizontal" Text="Enter Length" oncopy="return false" onpaste="return false" oncut="return false"></asp:Label>  
                                    </td>
                                   </tr>
                                  <tr>
                                   <td>



                                   <asp:TextBox ID="txtlenght" runat="server" type="numeric" CssClass="form-horizontal"></asp:TextBox>
                                  </td>
                                  </tr>

                                <caption>
                                    <br />
                                    <br />
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblbreadth" runat="server" CssClass="form-horizontal" Text="Enter Breadth"></asp:Label>
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txtbreadth" runat="server" CssClass="form-horizontal" type="numeric"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnsubmitRec" runat="server" CssClass="btn-default" OnClick="btnsubmitRec_Click" Text="Submit" Visible="false" />
                                        </td>
                                    </tr>
                                </caption>
                            </Table>
                        </span>
                  </asp:Panel>
             </div>


            <div class="col-sm-4">
                <asp:Panel ID="PanelCircle" runat="server">
                    <span>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblradius" runat="server" CssClass="form-horizontal" Text="Enter Radius"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtradius" runat="server" CssClass="form-horizontal"></asp:TextBox>
                                </td>
                            </tr>

                            <caption>
                                <br />
                                <br />
                                <tr>
                                    <td>
                                        <asp:Label ID="lblconstant" runat="server" CssClass="form-horizontal" Text="Enter Constant"></asp:Label>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtconstant" runat="server" CssClass="form-horizontal" type="decimal"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="txtconstantReg" runat="server" ControlToValidate="txtconstant" ErrorMessage="Decimal Only" ValidationExpression="^\d+\.\d{0,2}$" ValidationGroup="Insert"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnsubmitCir" runat="server" OnClick="btnsubmitCir_Click" Text="Submit" Visible="false" />
                                    </td>
                                </tr>
                            </caption>
                        </table>
                    </span>
                </asp:Panel>
            </div>

            <div class="col-sm-4">
                <asp:Panel ID="Panelsquare" runat="server">
                    <span>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblside" runat="server" CssClass="form-horizontal" Text="Enter Side"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtside" CssClass="form-horizontal" runat="server"></asp:TextBox>
                                </td> 
                            </tr>

                            <tr>
                                <td></td>
                            </tr>

                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnsubmitSqu" runat="server" Text="Submit" Visible="false" OnClick="btnsubmitSqu_Click" />
                                </td>
                            </tr>
                        </table>
                    </span>
                </asp:Panel>
            </div>


            <div class="col-sm-4">
                <asp:Panel ID="PanelTriangle" runat="server">
                    <span>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblbreadthfortriangle" runat="server" Text="Enter breadthfortriangle"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:TextBox ID="txtbreadthfortriangle" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                            <caption>
                                <br />
                                <br />
                                <tr>
                                    <td>
                                        <asp:Label ID="lblheight" runat="server" Text="Enter height"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtheight" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnsubmittri" runat="server" OnClick="btnsubmittri_Click" Text="Submit" Visible="false" />
                                    </td>
                                </tr>
                            </caption>
                        </table>
                    </span>
                </asp:Panel>
            </div>
   
        </div>
    </div>
   </div>
  </div>
 </form>
</body>
</html>

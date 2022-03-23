<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Demo_Practical.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Category Master</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <script>
      function populateSecondTextBox() {
          document.getElementById('txtCat2').value = document.getElementById('txtCat1').value;
            }
    </script>
</head>
<body>
        <div class="container">
            <form id="form1" runat="server">


                <asp:HiddenField Visible="false" ID="HiddenMsg" runat="server" />
                <div class="col-xs-6 col-md-4"">
                    <label>Category ID-1:</label>
                    <asp:TextBox ID="txtCat1" runat="server" onkeyup="populateSecondTextBox();"></asp:TextBox>
                </div>

             <div class="col-xs-6 col-md-4"">
                <label>Category ID-2:</label>
                <asp:TextBox ID="txtCat2" runat="server"></asp:TextBox>
            </div>

                <div class="row">
                    <div class="col-xs-3">
         
                       <asp:Button ID="btnSubmit" runat="server" class="btn btn-default" Text="Submit" OnClick="btnSubmit_Click" />
                </div>
                </div>
                <div class="row">
                    <div class="alert alert-success alert-dismissible">
                        <asp:Label ID="alert" runat="server" visible="false">Success! Data Deleted for given Category id.</asp:Label>
                       
                    </div>
                 </div>
            </form>
        </div>
</body>
</html>

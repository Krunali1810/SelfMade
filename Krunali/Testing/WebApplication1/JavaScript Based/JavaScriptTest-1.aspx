<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JavaScriptTest-1.aspx.cs" Inherits="JavaScript_Based.JavaScrriptTest_1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Vallidations Page</title>
    <script type="text/javascript">  

        window.onload = function ()
        {
            const xhttp = new XMLHttpRequest();
            const select = document.getElementById("countySel");    
            let countries;

            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    countries = JSON.parse(xhttp.responseText);
                    assignValues();
                    handleCountryChange();
                }
            };

            xhttp.open("GET", "https://restcountries.eu/rest/v2/all",true);
            xhttp.send();

            function assignValues()
            {
                countries.forEach(country =>
                {
                    const option = document.createElement("option");
                    option.textContent = country.name;
                    option.value = country.alpha3Code;
                    select.appendChild(option);
                });
            }

            function handleCountryChange()
            {
                let countryData = countries.find(
                    country => select.value === country.alpha3Code
                );
                var ImagePath = "https://restcountries.eu/data/" + (select.value.toLowerCase()) + ".svg";
                document.getElementById('<%= myImage.ClientID %>').setAttribute('src', ImagePath);
            }
            select.addEventListener("change", handleCountryChange.bind(this));
        }

        //var stateObject;
        //if (document.getElementById("countySel").value == "India")
        //{
        //    stateObject =
        //    {
        //        "India": {
        //            "Delhi": ["new Delhi", "North Delhi"],
        //            "Kerala": ["Thiruvananthapuram", "Palakkad"],
        //            "Goa": ["North Goa", "South Goa"],
        //        },
        //    }

        //    stateObject =
        //    {
        //        "Australia": {
        //            "South Australia": ["Dunstan", "Mitchell"],
        //            "Victoria": ["Altona", "Euroa"]
        //        },
        //    }


        //    stateObject =
        //    {
        //        "Canada": {
        //            "Alberta": ["Acadia", "Bighorn"],
        //            "Columbia": ["Washington", ""]
        //        },
        //    }
        //} 

        var stateObject =
        {
            "India": {
                "Delhi": ["new Delhi", "North Delhi"],
                "Kerala": ["Thiruvananthapuram", "Palakkad"],
                "Goa": ["North Goa", "South Goa"],
            },
            "Australia": {
                "South Australia": ["Dunstan", "Mitchell"],
                "Victoria": ["Altona", "Euroa"]
            }, "Canada": {
                "Alberta": ["Acadia", "Bighorn"],
                "Columbia": ["Washington", ""]
            },
        }


        function Allvalidate()
        {
            var ValidationSummary = "";
            ValidationSummary += NameValidation();
            ValidationSummary += EmailValidation();
            ValidationSummary += PhoneNumValidation();
            ValidationSummary += ValidateDOB();
            ValidationSummary += CheckPwd();
            if (ValidationSummary.includes("false"))
            {
                alert(document.getElementById("lblError").innerHTML);
                return false;
            }
            else
            {
                alert("Information submited successfuly");
                document.getElementById('txtname').value = "";
                document.getElementById('txtemail').value = "";
                document.getElementById('txtcontct').value = "";
                document.getElementById('txtdate').value = "";
                return true;  
            }
        }
        
        function PhoneNumValidation()
        {   
            var mob = /^[1-9]{1}[0-9]{9}$/;
            if (mob.test(document.getElementById("<%=txtcontct.ClientID %>").value) == false)
            {    
                document.getElementById("lblError").innerHTML = "Please enter valid mobile number."
                return false;
            }
            document.getElementById("lblError").innerHTML = "";
            return true;
        }

        function NameValidation()
        {
            userid = document.getElementById("<%=txtname.ClientID %>").value;  
            var val = /^[a-zA-Z ]+$/;
            if (userid == "")  
            { 
                document.getElementById("lblError").innerHTML = "Please Enter Name" + "\n"
                return false;
             }  
            else if (val.test(userid))  
            {  
                document.getElementById("lblError").innerHTML = "";
                return true;
             }  
            else  
            {  
                document.getElementById("lblError").innerHTML = "Name accepts only spaces and charcters" + "\n"
                return false;
            }  
        }  

        function EmailValidation()  
        {  
            var userid = document.getElementById("<%=txtemail.ClientID%>").value;
            var val = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            if (userid == "")
            {
                document.getElementById("lblError").innerHTML = "Please Enter Email Id" + "\n"
                return false;
            } 
            else if (val.test(userid))
            {
                document.getElementById("lblError").innerHTML = "";
                return true;
            }
            else
            {
                document.getElementById("lblError").innerHTML = "Email should be in this form example: xyz@abc.com" + "\n"
                return false;
            }
        }

        function ValidateDOB()
        {
            var dateString = document.getElementById("txtdate").value;
            var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;
            if (regex.test(dateString))
            {
                var parts = dateString.split("/");
                var dtDOB = new Date(parts[1] + "/" + parts[0] + "/" + parts[2]);
                var dtCurrent = new Date();
                document.getElementById("lblError").innerHTML = "Eligibility 18 years ONLY."
                if (dtCurrent.getFullYear() - dtDOB.getFullYear() < 18)
                {
                    return false;
                }
                if (dtCurrent.getFullYear() - dtDOB.getFullYear() == 18)
                {
                    if (dtCurrent.getMonth() < dtDOB.getMonth())
                    {
                        return false;
                    }
                    if (dtCurrent.getMonth() == dtDOB.getMonth())
                    {
                        if (dtCurrent.getDate() < dtDOB.getDate())
                        {
                            return false;
                        }
                    }
                }
                document.getElementById("lblError").innerHTML = "";
                return true;
            }
            else
            {
                document.getElementById("lblError").innerHTML = "Enter date in dd/MM/yyyy format ONLY."
                return false;
            }
        }

        function myFunction(tab)
        {
            if (tab == "1")
            {
                var np = document.getElementById("<%=txtPassword.ClientID%>");
                if (np.type === "password")
                {
                    np.type = "text";
                }
                else
                {
                    np.type = "password";
                }
            }
            if (tab == "2")
            {
                var np = document.getElementById("<%=txtCPassword.ClientID%>");
                if (np.type === "password")
                {
                    np.type = "text";
                }
                else
                {
                    np.type = "password";
                }
            }
        }

        function CheckPwd()
        {
            var lblError = document.getElementById("lblError");

            var Pwd = document.getElementById("<%=txtPassword.ClientID%>");
            var cPwd = document.getElementById("<%=txtCPassword.ClientID%>");
            var uName = document.getElementById("<%=txtname.ClientID%>");

            if (Pwd.value != "" && Pwd.value == cPwd.value)
            {
                if (Pwd.value.length < 6)
                {
                    lblError.innerHTML ="Error: Password must contain at least six characters!";
                    Pwd.focus();
                    return false;
                }
                if (Pwd.value == uName.value)
                {
                    lblError.innerHTML ="Error: Password must be different from Username!";
                    Pwd.focus();
                    return false;
                }
                re = /[0-9]/;
                if (!re.test(Pwd.value)) {
                    lblError.innerHTML ="Error: password must contain at least one number (0-9)!";
                    Pwd.focus();
                    return false;
                }
                re = /[a-z]/;
                if (!re.test(Pwd.value)) {
                    lblError.innerHTML ="Error: password must contain at least one lowercase letter (a-z)!";
                    Pwd.focus();
                    return false;
                }
                re = /[A-Z]/;
                if (!re.test(Pwd.value)) {
                    lblError.innerHTML = "Error: password must contain at least one uppercase letter (A-Z)!";
                    Pwd.focus();
                    return false;
                }
            }
            else
            {
                lblError.innerHTML = "Error: Please check that you've entered and confirmed your password!";
                Pwd.focus();
                return false;
            }
            lblError.innerHTML = "You entered a valid password: " + Pwd.value;
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <h3 style="color: blue">Validation in JavaScript</h3>
        <table style="border-color: #333300; z-index: 1; left: 15px; top: 54px; position: absolute; height: 122px; width: 261px">
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>

            <tr><td></td></tr>
            
            <tr><td>Current Year ::</td> <td><asp:Label runat="server" ID="lblCurrentYear"></asp:Label></td></tr>
            
            <tr>
                <td>
                    <asp:Label ID="lblname" runat="server" Text="FirstName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtname" runat="server" ></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblemail" runat="server" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblCntno" runat="server" Text="Phone No"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtcontct" runat="server" TextMode ="Number"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lbldate" runat="server" Text="Birth Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    <button id="show_password1" class="btn btn-primary" onclick="myFunction('1');" Type="button">
                        <span class="fa fa-eye-slash icon">Show</span>
                    </button>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="lblCPassword" runat="server" Text="Confirm Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCPassword" runat="server"  TextMode="Password"></asp:TextBox>
                    <button id="show_password2" class="btn btn-primary" onclick="myFunction('2');" type="button">
                        <span class="fa fa-eye-slash icon">Show</span>
                    </button>               
                </td>
            </tr>

            <tr>
                <td>
                   <asp:Label ID="lblcountry" runat="server" Text="Country"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="countySel" runat="server">
                        <asp:ListItem Value="--Select--"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                   <asp:Image ID="myImage" runat="server" Height="30px" Width="50px" />
                </td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="lblstate" runat="server" Text="State"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="stateSel" runat="server">
                        <asp:ListItem Value="Select Country First"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>


            <tr>
                <td>
                    <asp:Label ID="lbldistrict" runat="server" Text="District"></asp:Label>
                </td>

                <td>
                    <asp:DropDownList ID="districtSel" runat="server">
                        <asp:ListItem Value="Select State First"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>


            <tr>
                <td></td>
                <td>
                    <asp:Button ID="bttnsubmit" runat="server" Text="Submit"
                        OnClientClick="Allvalidate();" Font-Bold="True" />
                </td>
            </tr>

        </table>

        </h3>  
    </form>
</body>
</html>



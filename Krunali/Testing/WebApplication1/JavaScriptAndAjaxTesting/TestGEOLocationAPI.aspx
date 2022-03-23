<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestGEOLocationAPI.aspx.cs" Inherits="JavaScriptAndAjaxTesting.TestGEOLocationAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<script>
const x = document.getElementById("demo");

function getLocation() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(showPosition);
  } else { 
    x.innerHTML = "Geolocation is not supported by this browser.";
  }
}

function showPosition(position)
{

    var latlon = position.coords.latitude + "," + position.coords.longitude;

    var img_url = "https://maps.googleapis.com/maps/api/staticmap?center=" + latlon+ " &zoom=14&size=400x300&sensor=false&key=YOUR_KEY";

    document.getElementById("mapholder").innerHTML = "<img src='" + img_url + "'>";

}
</script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="mapholder" runat="server" ></asp:Label>
            <button onclick="getLocation()">Try It</button>
        </div>
    </form>
</body>
</html>

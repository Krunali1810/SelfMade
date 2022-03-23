<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lat-Long Scraper.aspx.cs" Inherits="Lat_Long_Scraper.Lat_Long_Scraper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="frm" runat="server">
    <textarea id="txtAddress" runat="server" rows="3" cols="25">362268,Gujarat India</textarea>
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Get Location" OnClick="btnSubmit_Click" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>
    </form>
   <%-- <script type="text/javascript">
    <!--
        function GetLocation() {
            var geocoder = new google.maps.Geocoder();
            var address = document.getElementById("txtAddress").value;
            debugger;
            geocoder.geocode({ 'address': address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    var latitude = results[0].geometry.location.lat();
                    var longitude = results[0].geometry.location.lng();
                    alert("Latitude: " + latitude + "\nLongitude: " + longitude);
                } else {
                    alert("Request failed.")
                }
            });
        };
        //-->
    </script>--%>
</body>
</html>

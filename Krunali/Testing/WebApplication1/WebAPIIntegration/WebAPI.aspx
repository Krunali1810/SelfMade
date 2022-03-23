
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebAPI.aspx.cs" Inherits="WebAPIIntegration.WebAPI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
      
//  let endpoint = 'https://api.linkpreview.net'
//  let apiKey = '5b578yg9yvi8sogirbvegoiufg9v9g579gviuiub8'

//  $( ".content a" ).each(function( index, element ) {

//    $.ajax({
//        url: endpoint + "?key=" + apiKey + " &q=" + $( this ).text(),
//        contentType: "application/json",
//        dataType: 'json',
//        success: function(result){
//            console.log(result);
//        }
//    })
//  });
//});


        //$(document).ready(function ()
        //{
        //    debugger;
        //    $("#Button1").click(function (e) {
        //        debugger;
        //        var validate = 0;
        //        if (validate.length == 0)
        //        {
        //            $.ajax({
        //                type: "POST",
        //                //http://api.weatherstack.com/current?access_key=424e1125e54c016579cfbdea6ad6e869&query=India'
        //                url: "http://api.weatherstack.com/current?access_key=424e1125e54c016579cfbdea6ad6e869&query=India",
        //                //url: "http://api.openweathermap.org/data/2.5/weather?id=" + $("#citySelect").val() + "&appid=API-KEY&units=metric",
        //                dataType: "json",
        //                success: function (result, status, xhr) {
        //                    var table = $("<table><tr><th>Weather Description</th></tr>");

        //                    table.append("<tr><td>City:</td><td>" + result["name"] + "</td></tr>");
        //                    table.append("<tr><td>Country:</td><td>" + result["sys"]["country"] + "</td></tr>");
        //                    table.append("<tr><td>Current Temperature:</td><td>" + result["current"]["temperature"] + "°C</td></tr>");
        //                    table.append("<tr><td>Humidity:</td><td>" + result["current"]["humidity"] + "</td></tr>");
        //                    table.append("<tr><td>Weather:</td><td>" + result["current"][0]["weather_descriptions"][0] + "</td></tr>");

        //                    $("#message").html(table);
        //                },
        //                error: function (xhr, status, error) {
        //                    alert("Result: " + status + " " + error + " " + xhr.status + " " + xhr.statusText)
        //                }
        //            });
        //        }
        //    });

        //    $(document).ajaxStart(function () {
        //        $("img").show();
        //    });

        //    $(document).ajaxStop(function () {
        //        $("img").hide();
        //    });


        //    return errorMessage;
        

        //function Validate()
        //    {
        //        var errorMessage = "";
        //        if ($("#citySelect").val() == "Select") {
        //            errorMessage += "► Select City";
        //        }
        //        return errorMessage;
        //    }
       
    </script>
</head>
<body>

    <form id="form1" runat="server" method="get">   
       <%-- <div class="textAlignCenter">
            <img src="~/Content/Image/Sign.jpg" />
        </div>--%>
        <div id="message">

        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
    </form>

<%--<script>
    $(document).ready(function ()
        {
            function getTemperatureDetails() {
            //I put lat first
                debugger;
                $.ajax({
              
                // http:// added
                url: "http://api.openweathermap.org/data/2.5/weather",
                type: "GET",
                dataType: "JSON",
                data: {
                    lat: 35,
                    lon: 149,
                    APPID: "b1b15e88fa797225412429c1c50c122a1"
                },
                success: function (data) {
                    console.log(data);
                },
                error: function (data, textStatus, errorThrown) {
                    //Do Something to handle error
                    console.log(textStatus);
                }
            });
        }
   }
</script>--%>
</body>
</html>

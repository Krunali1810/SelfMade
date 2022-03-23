<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartExample.aspx.cs" Inherits="CystalReportExample.ChartExample" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%--<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="DepartmentC" HeaderText="Department" />
                <asp:BoundField DataField="Period_Shown" HeaderText="Period_Shown" />
                <asp:BoundField DataField="PAR %" HeaderText="PAR %" />
            </Columns>
        </asp:GridView>

        <asp:Chart ID="Chart1" runat="server">
            <Titles>
                <asp:Title ShadowOffset="3" Name="Items"></asp:Title>
            </Titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                    LegendStyle="Row" />
            </Legends>
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>

        

       <%-- <asp:Chart ID="Chart1" runat="server">
            <Titles>
                <asp:Chart runat="server">
                    <series><asp:Series Name="Series1"></asp:Series></series>
                    <chartareas><asp:ChartArea Name="ChartArea1"></asp:ChartArea></chartareas>
                </asp:Chart>
                <asp:Title ShadowOffset="3" Name="Items"></asp:Title>
            </Titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                    LegendStyle="Row" />
            </Legends>
            <Series>
                <asp:Series Name="Series1"></asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>--%>


        <%--<asp:Chart ID="Chart1" runat="server" Height="300px" Width="400px">
            <Titles>
                <asp:Title ShadowOffset="3" Name="Items"></asp:Title>
            </Titles>
            <Legends>
                <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                    LegendStyle="Row" />
            </Legends>
          
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>--%>
       
    </form>
</body>
</html>

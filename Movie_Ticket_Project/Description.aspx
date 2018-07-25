<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Description.aspx.cs" Inherits="Movie_Ticket_Project.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: black;">
        
    <div style="text-align: center;">
        <h1 id ="title" style = "text-align: center; color: #FF00FF; font-family: Magneto; font-weight: bolder; font-size: xx-large; font-style: italic; text-decoration: blink;" runat="server"></h1>

         <div>
            <asp:Image ID="Image1" runat="server" Height="80px" BorderColor="#CC0000" BorderStyle="Ridge" HorizontalAlign="center" />
        </div>

        <p id = "synopsis" runat = "server" style="font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; font-size: medium; font-style: italic; font-weight: normal; color: #FFFFFF; background-color: #000000; border-style: groove; width: 914px; text-align: inherit;">
           
        </p>
    </div>


        <form id="form1" runat="server">
        
        </form>
</body>
</html>

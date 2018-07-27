<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AllMovies.aspx.cs" Inherits="Movie_Ticket_Project.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Back To Recommendation" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="BacK To All Movies" />
    </form>
</body>
</html>

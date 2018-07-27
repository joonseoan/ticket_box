<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="Movie_Ticket_Project.WebForm4" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" autocomplete="on">
        <div>
            
            This is service page
            <!-- autocopl -->
            <!-- <asp:Panel ID="Panel1" runat="server"> -->
                <asp:Button ID="Button1" runat="server" Text="All Movies" OnClick="Button1_Click" />
           <!-- </asp:Panel> -->
             <asp:Table ID="Table1" runat="server" BackColor="Black" ForeColor="White" HorizontalAlign="Center"></asp:Table>

        </div>
        

        <asp:Button ID="Button2" runat="server" Text="Button" />
        

    </form>

   
            
   
</body>
</html>

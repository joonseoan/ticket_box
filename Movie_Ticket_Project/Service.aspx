<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Service.aspx.cs" Inherits="Movie_Ticket_Project.WebForm4" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            This is service page
            
            <br />
            
            <br />
            <br />
            
        </div>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button1" runat="server" Text="Button" />
        
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <asp:GridView ID="GridView1" runat="server" Height="223px" Width="428px">
        </asp:GridView>
        <asp:Image ID="Image1" runat="server" />
        <asp:FormView ID="FormView1" runat="server">
        </asp:FormView>

        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>

    </form>
</body>
</html>

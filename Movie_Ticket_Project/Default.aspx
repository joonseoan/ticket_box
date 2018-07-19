<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Movie_Ticket_Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <div>

        <h1>Welcome to TicketEasy!</h1>

    </div>

    <form id="form1" runat="server">
       
        <div style="margin-left: 400px">
            <asp:Button ID="signup" runat="server" Text="Singup" OnClick="signup_Click" />
        </div>
        <br />
        <br />
        <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" autofocus></asp:TextBox>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Please, enter email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Email must not be empty."></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="password" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="You have to enter your password."></asp:RegularExpressionValidator>
        <br />
        <br />
        <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
       
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckBox1" runat="server" Text="I am an administrator" OnCheckedChanged="CheckBox1_CheckedChanged" />
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
       
    </form>
</body>
</html>

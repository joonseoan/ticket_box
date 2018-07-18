<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfileInput.aspx.cs" Inherits="Movie_Ticket_Project.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <h1>Please, fill out the form below.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h1>
            <br />
            <asp:Label ID="first_name" runat="server" Text="First Name"></asp:Label>
            :
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="first_name_validation" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Please, enter your first name."></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="last_name" runat="server" Text="Last Name"></asp:Label>
            :
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="last_name_validation" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Pleasse, enter your last name."></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="genger" runat="server" Text="Gender"></asp:Label>
            :
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="209px">
                <asp:ListItem Selected="True" Value="male">Male</asp:ListItem>
                <asp:ListItem Value="female">Female</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="age" runat="server" Text="Age"></asp:Label>
            :&nbsp;
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="7">0 - 7</asp:ListItem>
                <asp:ListItem Value="13">8 - 13</asp:ListItem>
                <asp:ListItem Selected="True" Value="17">15 -17</asp:ListItem>
                <asp:ListItem Value="18">18 ~</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
            :
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="email_required_validation" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="Please, enter your email."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="email_format_validation" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="It must be an email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Validation duplicate email"></asp:CustomValidator>
            <br />
            <br />
            <asp:Label ID="password1" runat="server" Text="Password"></asp:Label>
            :
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="password1_required_validation" runat="server" ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="Please, enter password."></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="size_validator" runat="server" ControlToValidate="TextBox6" ErrorMessage="It must be at least 8 characters. "></asp:CustomValidator>
            <br />
            <br />
            <asp:Label ID="password2" runat="server" Text="Password (Confirm)"></asp:Label>
            :
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="password2_required_validation" runat="server" ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="Please, enter password."></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="password2_compare_validation" runat="server" ControlToCompare="TextBox6" ControlToValidate="TextBox7" Display="Dynamic" ErrorMessage="It does not match Password above."></asp:CompareValidator>
            <br />
            <br />
            <asp:Label ID="genre" runat="server" Text="Favorite Genre"></asp:Label>
            :
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label10" runat="server" Text="Favorite Director:"></asp:Label>
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="186px" Width="222px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="actor" runat="server" Text="Favorite Actor / Actress"></asp:Label>
            :
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="actor_required_validator" runat="server" ControlToValidate="TextBox8" Display="Dynamic" ErrorMessage="Please, enter your favorite actor or actress"></asp:RequiredFieldValidator>
            <br />
            <asp:ListBox ID="ListBox2" runat="server" Height="186px" Width="225px"></asp:ListBox>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
            
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Back to Login" />
            
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="profileInput.aspx.cs" Inherits="Movie_Ticket_Project.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <h1>Please, fill out a form below.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h1>
            <p>&nbsp;</p>
            <a href="Default.aspx">Back to login page.</a>
            <br />
            <br />
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
            :
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="age_required_validation" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please, enter your age."></asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="age_number_validation" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="Please, enter digit numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            <asp:RangeValidator ID="age_range_validation" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="It can't be less than 1." MaximumValue="150" MinimumValue="1" Type="Integer"></asp:RangeValidator>
            <br />
            <br />
            <asp:Label ID="email" runat="server" Text="Email"></asp:Label>
            :
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="email_required_validation" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="Please, enter your email."></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="email_format_validation" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="It must be an email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
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
                <asp:ListItem Value="action">Action</asp:ListItem>
                <asp:ListItem Value="blockbuster">Blockbuster</asp:ListItem>
                <asp:ListItem Value="drama">Drama</asp:ListItem>
                <asp:ListItem Value="romance">Romance</asp:ListItem>
                <asp:ListItem Value="comedy">Comedy</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="actor" runat="server" Text="Favorite Actor / Actress"></asp:Label>
            :
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            <asp:RequiredFieldValidator ID="actor_required_validator" runat="server" ControlToValidate="TextBox8" Display="Dynamic" ErrorMessage="Please, enter your favorite actor or actress"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Submit" />
            
        </div>
    </form>
</body>
</html>

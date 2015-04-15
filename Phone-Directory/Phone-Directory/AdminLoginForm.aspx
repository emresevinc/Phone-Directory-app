<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLoginForm.aspx.cs" Inherits="Phone_Directory.AdminLoginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Admin</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border:dotted; background-color:coral">
             <div>
                 &nbsp;<br />
&nbsp;
                 <asp:Label ID="Label1" runat="server" Height="15px" Text="Kullanıcı Adı :"></asp:Label>
                 <asp:TextBox ID="userNameTxt" runat="server" Height="16px" Width="220px" style="margin-left: 34px"></asp:TextBox>
                 *</div>
             <div>
             <p>
                 &nbsp;&nbsp;
                 <asp:Label ID="Label2" runat="server" Text="Parola  :"></asp:Label>
                 <asp:TextBox ID="TextBox2" runat="server" Height="16px" Width="220px" style="margin-left: 80px" TextMode="Password"></asp:TextBox>
                 *</p>
             </div>
             <div>
             <p>
                 <asp:Button ID="giris_btn" runat="server" Text="Giris" style="margin-left: 3px" Width="67px" OnClick="giris_btn_Click"/>
                 <asp:Label ID="state_lbl" runat="server" style="margin-left: 100px; color:red;" ></asp:Label>
             </p>
             </div>
        </div>
    </form>
</body>
</html>

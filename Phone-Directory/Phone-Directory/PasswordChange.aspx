<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="Phone_Directory.PasswordChange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border:double">
            <div style="background-color:lightgoldenrodyellow">
             &nbsp;
                <br />
                &nbsp;Eski Parola :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
             *
             <p>
                 &nbsp;
                 Yeni Parola:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                 *</p>
             <p>
                 &nbsp;
                 Tekrar Yeni Parola: <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                 *</p>
                 &nbsp;
             <asp:Button ID="kaydet_btn" runat="server" Text="Kaydet" OnClick="kaydet_btn_Click" Width="94px" />
                <br />
            </div>
        </div>
    </form>
</body>
</html>

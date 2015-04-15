<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Phone_Directory.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
       <div style="background-color:azure">   
           <div>
               <h1>ÇALIŞANLAR</h1>
               <p>Aşağıda sırasıyla çalışannın telefon numarası, ismi ve soyismi şeklinde bilgileri listelenmektedir.</p>
           </div>
           <div>
               <asp:ListBox AutoPostBack="true" ID="employee_list" runat="server" Height="290px" OnSelectedIndexChanged="employee_list_SelectedIndexChanged" Width="716px"></asp:ListBox>
               
               <br />

               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

               <asp:Button ID="yenile_btn" runat="server" Text="Listeyi yenile" OnClick="yenile_btn_Click" />
                            
               <p style="text-align:inherit;"><a href="AdminLoginForm.aspx" target="_blank">Admin girişi için tıklayiniz</a> </p>

           </div>
           &nbsp;<p style="text-align: inherit">
                   <asp:Label ID="Label1" runat="server" Text="Ad    :"></asp:Label>
                   <asp:Label ID="Ad_label" runat="server"></asp:Label>
               </p>
               <p>
                   <asp:Label ID="Label2" runat="server" Text="Soyad      :"></asp:Label>
                   <asp:Label ID="Soyad_label" runat="server"></asp:Label>
               </p>
               <p>
                   <asp:Label ID="Label3" runat="server" Text="Telefon     :"></asp:Label>
                   <asp:Label ID="Telefon_label" runat="server"></asp:Label>
               </p>
               <p>
               <asp:Label ID="Label4" runat="server" Text="Departman  :"></asp:Label>
               <asp:Label ID="Dep_label" runat="server"></asp:Label>
               </p>
               <p>
                   <asp:Label ID="Label6" runat="server" Text="Yöneticisi :"></asp:Label>
                   <asp:Label ID="yonLAbel" runat="server"></asp:Label>
               </p>
               <p>
                   <asp:Label ID="Label5" runat="server" Text="Departmanın Yöneticisi :"></asp:Label>
                   <asp:Label ID="DepYonetici_label" runat="server"></asp:Label>
               </p>
           </div>
    </form>
</body>
</html>

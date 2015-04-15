<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUI.aspx.cs" Inherits="Phone_Directory.AdminUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin UI</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color:fuchsia">
             <div style="float:right;">
                 <asp:Label ID="label1" runat="server"></asp:Label><br />
             </div>
             <div>
                 <br />
                 <h2>*HESAP İŞLEMLERİ</h2> <br />
                 <p>Parola değiştirmek için&nbsp; 
                     <asp:Button ID="ChangePass" runat="server" Text="Tıklayınız" OnClick="ChangePass_Click" OnClientClick="document.forms[0].target ='_blank';"/>
                 </p>
             </div>
        </div>
        <div style="background-color: #6495ed;">
            <p>
                &nbsp;</p>
            <h2>
                *ÇALIŞAN EKLE</h2>

            <div>
        
            Ad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        
                *</div>
            <p>
                Soyad&nbsp; :&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                *</p>
            <p>
                Telefon :&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                *</p>
            <p>
                Departman :&nbsp;
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </p>
            <p>
                Yonetici&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="ekle_btn" runat="server" OnClick="ekle_btn_Click" Text="Ekle" />
            </p>
            <p>
                &nbsp;</p>
            <h2>
                *ÇALIŞAN DÜZENLE</h2>
            <p>
                Çalışan seç&nbsp; :&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList5" runat="server" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </p>

            <div>
        
            Ad&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        
                *</div>
            <p>
                Soyad&nbsp; :&nbsp;&nbsp;
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                *</p>
            <p>
                Telefon :&nbsp;
                <asp:TextBox ID="TextBox6" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                *</p>
            <p>
                Departman :&nbsp;
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                </asp:DropDownList>
            </p>
            <p>
                Yonetici&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack ="true">
                </asp:DropDownList>
            </p>
            <p>
                <asp:Button ID="duzenle_btn" runat="server" Text="Duzenle" OnClick="duzenle_btn_Click" />
            </p>
            <p>
                &nbsp;</p>
            <h2>
                *ÇALIŞAN SİL</h2>
            <p>
                Çalışan seç :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="true">
                </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="sil_btn" runat="server" OnClick="sil_btn_Click" Text="Sil" Width="47px" />
            </p>
        </div>
        <div style="background-color:lightcyan">
              <p>
                 &nbsp;</p>
              <h2>
                 *DEPARTMAN EKLE</h2>
             <p>
                 Departman Adi :&nbsp;&nbsp;
                 <asp:TextBox ID="depAdiTxt" runat="server"></asp:TextBox>
             </p>
             <p>
                 Departman Yoneticisi :&nbsp;&nbsp;
                 <asp:DropDownList ID="depDropDown" runat="server">
                 </asp:DropDownList>
             </p>
             <p>
                 <asp:Button ID="Dep_Ekle_btn" runat="server" OnClick="Dep_Ekle_btn_Click" Text="Ekle" Width="53px" />
             </p>
             <p>
                 &nbsp;</p>
             <h2>
                 *DEPARTMAN GÜNCELLE</h2>
             <p>
                 Departman Seç :&nbsp;&nbsp;
                 <asp:DropDownList ID="dep_sec_dropDown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dep_sec_dropDown_SelectedIndexChanged">
                 </asp:DropDownList>
             </p>
             <p>
                 Departman Adi :&nbsp;&nbsp;
                 <asp:TextBox ID="depAdiTxt2" runat="server"></asp:TextBox>
             </p>
             <p>
                 Departman Yoneticisi :&nbsp;&nbsp;
                 <asp:DropDownList ID="depYonDropDown" runat="server">
                 </asp:DropDownList>
             </p>
             <p>
                 <asp:Button ID="Dep_Gunc_btn" runat="server" OnClick="Dep_Gunc_btn_Click" Text="Guncelle" Width="67px" />
             </p>
             <p>
                 &nbsp;</p>
             <h2>
                 *DEPARTMAN SİLME</h2>
             <p>
                 Departman Seç :&nbsp;&nbsp;
                 <asp:DropDownList ID="dep_Sil_sec_dropDown" runat="server" AutoPostBack="True">
                 </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="dep_Sil_btn" runat="server" OnClick="dep_Sil_btn_Click" Text="Sil" Width="44px" />
             </p>
        </div>
    </form>
</body>
</html>

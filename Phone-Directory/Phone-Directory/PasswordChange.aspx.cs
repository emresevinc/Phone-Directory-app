using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phone_Directory
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void kaydet_btn_Click(object sender, EventArgs e)
        {
            String eskiPass = TextBox1.Text;
            String yeniPass = TextBox2.Text;
            String yeniPassTekrar = TextBox3.Text;
            String userName = Request.QueryString["username"];
            Phone_Directory_dbEntities ent = new Phone_Directory_dbEntities();
            Admins admin = (from ad in ent.Admins
                        where ad.Username == userName
                        select ad).First();

            if (eskiPass.Equals(admin.Password))
            {
                if (yeniPass.Equals(yeniPassTekrar) && yeniPass.Length>0)
                {
                    admin.Password = yeniPass;
                    ent.SaveChanges();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Parola değiştirildi');</script>");
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Yeni parolalar tutarsız ya da illegal');</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Eski parolanızı yanlış girdiniz');</script>");
            }

        }
    }
}
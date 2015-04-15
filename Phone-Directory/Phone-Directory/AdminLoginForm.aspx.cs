using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phone_Directory
{
    public partial class AdminLoginForm : System.Web.UI.Page
    {
        Phone_Directory_dbEntities ent = new Phone_Directory_dbEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                state_lbl.Text = "Hatali giris";
            }
            
        }

        protected void giris_btn_Click(object sender, EventArgs e)
        {
            String username = userNameTxt.Text;
            String pass = TextBox2.Text;
            var admin = (from a in ent.Admins
                        where a.Username == username 
                        where a.Password == pass
                        select a).ToList();
            
            if (admin.Count>0)
            {
                Response.Redirect("AdminUI.aspx?username="+username);
            }
        }
    }
}
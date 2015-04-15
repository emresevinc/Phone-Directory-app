using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phone_Directory
{
    public partial class AdminUI : System.Web.UI.Page
    {
        Phone_Directory_dbEntities ent = new Phone_Directory_dbEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                label1.Text = "Hoş geldiniz "+Request.QueryString["username"];
                DropDownListDoldur();
                calisanlariDuzenlemeVeSilmeDropDownListesineDoldur();
                getDepts();
            } 
        }


        protected void ChangePass_Click(object sender, EventArgs e)
        {
            Response.Redirect("PasswordChange.aspx?username="+label1.Text.Substring(13));
        }

        private void DropDownListDoldur() 
        {
            depsListUpdate();
            yoneticiDropDownDoldur();
        }

        protected void ekle_btn_Click(object sender, EventArgs e)
        {
            String ad = TextBox1.Text;
            String soyad = TextBox2.Text;
            String tel = TextBox3.Text;

            if (ad.Length>0 && soyad.Length>0 && tel.Length == 6)
            {
                int depID = Int32.Parse(DropDownList1.SelectedItem.Text.Split('.')[0]);
                int ID = ent.Employees.Max(p => p.ID);
                Employees emp = new Employees();
                emp.ID = ID + 1;
                emp.Name = ad;
                emp.Surname = soyad;
                emp.Phone = tel;
                emp.DepartmentID = depID;
                if (DropDownList2.SelectedIndex != 0)
                {
                    int yoneticiID = Int32.Parse(DropDownList2.SelectedItem.Text.Split('.')[0]);
                    emp.ManagerID = yoneticiID;
                }
                ent.Employees.Add(emp);
                ent.SaveChanges();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Çalışan eklendi');</script>");
                calisanlariDuzenlemeVeSilmeDropDownListesineDoldur();
                yoneticiDropDownDoldur();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Ad ve Soyad boş geçilemez ve telefon numarası 6 haneli olmalıdır');</script>");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            yoneticiDropDownDoldur();
        }

        private void yoneticiDropDownDoldur()
        {
            int depID = Int32.Parse(DropDownList1.SelectedItem.Text.Split('.')[0]);
            var emps = from emp in ent.Employees
                       where emp.DepartmentID == depID
                       select emp;
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Yöneticisi yok");
            foreach (var item in emps)
            {
                DropDownList2.Items.Add(item.ID + ". " + item.Name + " " + item.Surname);
            }
        }

        private void calisanlariDuzenlemeVeSilmeDropDownListesineDoldur() 
        {
            var calisanlar = from cal in ent.Employees
                             select cal;
            DropDownList5.Items.Clear();
            DropDownList6.Items.Clear();
            foreach (var item in calisanlar)
            {
                DropDownList5.Items.Add(item.ID + ". " + item.Name + " " + item.Surname);
                DropDownList6.Items.Add(item.ID + ". " + item.Name + " " + item.Surname);
            }
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int calisanID = Int32.Parse(DropDownList5.SelectedItem.Text.Split('.')[0]);
            var calisan = from cal in ent.Employees
                                from dept in ent.Departments
                                where cal.ID == calisanID
                                where cal.DepartmentID == dept.ID
                                select new { cal, dept };
            foreach (var item in calisan)
            {
                
                    TextBox4.Text = item.cal.Name;
                    TextBox5.Text = item.cal.Surname;
                    TextBox6.Text = item.cal.Phone;
                    DropDownList3.Items.Clear();
                    deptDoldur();
                    DropDownList3.SelectedIndex = item.dept.ID - 1;
                    var yonetici = (from yon in ent.Employees
                                         where yon.ID == item.cal.ManagerID
                                         select yon).ToList();
                    departmanCalisanlariniDoldur();
            }
        }

        private void deptDoldur() 
        {
            DropDownList3.Items.Clear();
            var dets = from d in ent.Departments
                       select d;
            foreach (var item in dets)
            {
                DropDownList3.Items.Add(item.ID+". "+item.Dep_Name);
            }
        }

        protected void duzenle_btn_Click(object sender, EventArgs e)
        {
            if (TextBox4.Text.Length > 0 && TextBox5.Text.Length > 0 && TextBox6.Text.Length > 0 && DropDownList3.SelectedItem.Text.Length > 0 && DropDownList4.SelectedItem.Text.Length > 0)
            {
                 int empID = Int32.Parse(DropDownList5.SelectedItem.Text.Split('.')[0]);
                 Employees emp = (from em in ent.Employees
                                  where em.ID == empID
                                  select em).First();
                 emp.Name = TextBox4.Text;
                 emp.Surname = TextBox5.Text;
                 emp.Phone = TextBox6.Text;
                 if (DropDownList4.SelectedIndex != 0)
	             {
                     emp.ManagerID = Int32.Parse(DropDownList4.Text.Split(',')[0]);
	             }
                 ent.SaveChanges();
                 Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Kayıt guncellendi');</script>");
                 calisanlariDuzenlemeVeSilmeDropDownListesineDoldur();
                 yoneticiDropDownDoldur();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Belirtilen alanlar boş geçilemez');</script>");
            }
        }

        protected void sil_btn_Click(object sender, EventArgs e)
        {
            int calisanID = Int32.Parse(DropDownList6.SelectedItem.Text.Split('.')[0]);
            var employees = (from emp in ent.Employees
                             where emp.ManagerID == calisanID
                             select emp).ToList();
            if (employees.Count == 0)
            {
                //Eğer kendisine bağlı alt çalışanlar yoksa silinecek
                Employees empl = (from em in ent.Employees
                                  where em.ID == calisanID
                                  select em).First();
                ent.Employees.Remove(empl);
                ent.SaveChanges();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Çalışan silindi');</script>");
                calisanlariDuzenlemeVeSilmeDropDownListesineDoldur();
                yoneticiDropDownDoldur();
                departmanCalisanlariniDoldur();
            }
            else
            {
                //Eğer kendisine bağlı alt çalışanlar varsa silinmeyecek
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Yönetici çalışan olduğu için silinemez');</script>");
            }
        }
        private List<Employees> calisanlariGetir(int departmanID) 
        {
            var calisanlar = (from cal in ent.Employees
                              where cal.DepartmentID == departmanID
                                    select cal).ToList();
            return calisanlar;
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            departmanCalisanlariniDoldur();
        }

        private void departmanCalisanlariniDoldur() 
        {
            if (DropDownList3.SelectedItem != null)
            {
                DropDownList4.Items.Clear();
                foreach (var i in calisanlariGetir(Int32.Parse(DropDownList3.SelectedItem.Text.Split('.')[0])))
                {
                    DropDownList4.Items.Add(i.ID + ". " + i.Name + " " + i.Surname);
                }
            }
        }

        private void getDepts() 
        {
            var admins = from a in ent.Admins
                        select a;
            depDropDown.Items.Clear();
            depYonDropDown.Items.Clear();
            foreach (var item in admins)
            {
                depDropDown.Items.Add(item.ID+". "+item.Name+" "+item.Surname);
                depYonDropDown.Items.Add(item.ID + ". " + item.Name + " " + item.Surname);
            }
        }

        private void depsListUpdate()
        {
            var depts = from d in ent.Departments
                        select d;
            DropDownList1.Items.Clear();
            DropDownList3.Items.Clear();
            dep_sec_dropDown.Items.Clear();
            dep_Sil_sec_dropDown.Items.Clear();
            foreach (var item in depts)
            {
                DropDownList1.Items.Add(item.ID + ". " + item.Dep_Name);
                DropDownList3.Items.Add(item.ID + ". " + item.Dep_Name);
                dep_sec_dropDown.Items.Add(item.ID + ". " + item.Dep_Name);
                dep_Sil_sec_dropDown.Items.Add(item.ID + ". " + item.Dep_Name);
            }
        }

        protected void Dep_Ekle_btn_Click(object sender, EventArgs e)
        {
            if (depAdiTxt.Text.Length > 0)
            {
                int admID = int.Parse(depDropDown.SelectedItem.Text.Split('.')[0]);
                int ID = ent.Departments.Max(d => d.ID);
                Departments dp = new Departments();
                dp.ID = ID + 1;
                dp.Dep_Name = depAdiTxt.Text;
                dp.ManagerID = admID;
                ent.Departments.Add(dp);
                ent.SaveChanges();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Departman eklendi');</script>");
                depsListUpdate();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Departman ismi boş geçilemez');</script>");
            }
        }

        protected void dep_sec_dropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            int depID = Int32.Parse(dep_sec_dropDown.SelectedItem.Text.Split('.')[0]);
            var dep = from d in ent.Departments
                      where d.ID == depID
                      select d;
            depAdiTxt2.Text = dep.First().Dep_Name;
            getDepts();
        }

        protected void Dep_Gunc_btn_Click(object sender, EventArgs e)
        {
            int depID = Int32.Parse(dep_sec_dropDown.SelectedItem.Text.Split('.')[0]);
            Departments d = (from de in ent.Departments
                            where de.ID == depID
                            select de).First();
            d.Dep_Name = depAdiTxt2.Text;
            int adID = Int32.Parse(depYonDropDown.SelectedItem.Text.Split('.')[0]);
            d.ManagerID = adID;
            ent.SaveChanges();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Departman güncellendi')</script>");
            depsListUpdate();
        }

        protected void dep_Sil_btn_Click(object sender, EventArgs e)
        {
            int depID = Int32.Parse(dep_Sil_sec_dropDown.SelectedItem.Text.Split('.')[0]);
            Departments d = (from de in ent.Departments
                            where de.ID == depID
                            select de).First();
            ent.Departments.Remove(d);
            ent.SaveChanges();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başlık", "<script>alert('Departman silindi')</script>");
            depsListUpdate();
        }
    }
}
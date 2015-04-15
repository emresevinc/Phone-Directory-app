using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Phone_Directory
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Phone_Directory_dbEntities entities = new Phone_Directory_dbEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var employees = from ee in entities.Employees
                                select ee;
                foreach (var employee in employees)
                {
                    employee_list.Items.Add(employee.Phone + "    " + employee.Name + " " + employee.Surname);
                }
            }

        }

        protected void employee_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            String currentItem = employee_list.SelectedItem.Text;
            String phone_numb = "";
            foreach (char item in currentItem)
            {
                if (item.ToString().Equals(" "))
                {
                    break;
                }
                phone_numb += item.ToString();
            }
            
            var emp = from em in entities.Employees
                      from de in entities.Departments
                      from ad in entities.Admins
                      where em.DepartmentID == de.ID
                      where de.ManagerID == ad.ID
                      where em.Phone == phone_numb
                      select new { empAdi = em.Name, empSoyadi = em.Surname, tele_num = em.Phone, manID = em.ManagerID, depadi = de.Dep_Name, admAdi = ad.Name + " " + ad.Surname };

            

            foreach (var item in emp)
            {
                Ad_label.Text = item.empAdi;
                Soyad_label.Text = item.empSoyadi;
                Telefon_label.Text = item.tele_num;
                Dep_label.Text = item.depadi;
                var man = (from empl in entities.Employees
                                 where item.manID == empl.ID
                                 select empl).ToList();
                if (man.Count > 0)
                {
                    yonLAbel.Text = man.First().Name + " " + man.First().Surname;
                }
                else
                {
                    yonLAbel.Text = "Yok";
                }
                DepYonetici_label.Text = item.admAdi;
            }
        }

        protected void yenile_btn_Click(object sender, EventArgs e)
        {
            employee_list.Items.Clear();
            var employees = from ee in entities.Employees
                            select ee;
            foreach (var employee in employees)
            {
                employee_list.Items.Add(employee.Phone + "    " + employee.Name + " " + employee.Surname);
            }
        }


    }
}
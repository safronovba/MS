using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbwork temp = new dbwork();
    string dbaddress = null, oldaddress = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        dbaddress = temp.getdbparam((Request.PhysicalApplicationPath).ToString() + "app_data/config.txt").GetValue(1).ToString();
        oldaddress = addressbox.Text;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string newdbaddress = addressbox.Text;
        if (newdbaddress.Contains("accdb"))
        {
            if (temp.tableexist(addressbox.Text, "hosts"))
            {
                temp.setdbparam(((Request.PhysicalApplicationPath).ToString() + "app_data/config.txt"), 1, newdbaddress);
                Button2.Visible = false;
                Response.Redirect("monitoring.aspx");
            }
            else
            {
                if (CultureInfo.CurrentCulture.DisplayName.Contains("English"))
                {
                    Label2.Text = "DB error. No 'hosts' table here";
                }
                else
                {
                    Label2.Text = "Ошибка базы данных. Таблица 'hosts' не найдена";
                }

                Button2.Visible = true;
            }
        }
        else
        {
            if (CultureInfo.CurrentCulture.DisplayName.Contains("English"))
            {
                Label2.Text = "Wrong db name";
            }
            else
            {
                Label2.Text = "Неверное имя базы данных";
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        dbaddress=addressbox.Text;
        temp.addmaindb(dbaddress, (Request.PhysicalApplicationPath).ToString());
    }
}
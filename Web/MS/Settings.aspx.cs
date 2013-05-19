using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbwork temp = new dbwork();
    string dbaddress=null, newdbaddress = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        dbaddress = (Request.PhysicalApplicationPath).ToString() + "App_Data\\" + temp.getdbparam((Request.PhysicalApplicationPath).ToString() + "app_data/config.txt").GetValue(1).ToString();
   //     addressbox.Text = temp.getdbparam((Request.PhysicalApplicationPath).ToString() + "App_Data\\config.txt").GetValue(1).ToString();
    }
    private void checkfile()
    {
        newdbaddress = addressbox.Text;
        if ((dbaddress.Equals((Request.PhysicalApplicationPath).ToString() + "App_Data\\" + newdbaddress))&(temp.tableexist((Request.PhysicalApplicationPath).ToString() + "App_Data\\" + newdbaddress,"hosts")))
        {
            Button2.Visible = false;
            Response.Redirect("monitoring.aspx");
        }
        else
        {
            if (newdbaddress.Contains("accdb"))
            {
                if (temp.tableexist((Request.PhysicalApplicationPath).ToString() + "App_Data\\" + newdbaddress, "hosts"))
                {
                    temp.setdbparam(((Request.PhysicalApplicationPath).ToString() + "App_Data\\config.txt"), 1, newdbaddress);
                    temp.setdbparam(((Request.PhysicalApplicationPath).ToString() + "App_Data\\config.txt"), 2, "scanstopnow");
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
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        checkfile();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        dbaddress = (Request.PhysicalApplicationPath).ToString() + "App_Data\\" + addressbox.Text;
        temp.addmaindb(dbaddress, (Request.PhysicalApplicationPath).ToString());
        Label2.Text = "Table created";
        Thread.Sleep(1000);
        temp.setdbparam(((Request.PhysicalApplicationPath).ToString() + "App_Data\\config.txt"), 1, addressbox.Text);
        Label2.Text=("New config");
        Thread.Sleep(1000);

        checkfile();
    }
    protected void addressbox_TextChanged(object sender, EventArgs e)
    {

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public partial class hostadd : System.Web.UI.Page
{
    dbwork temp = new dbwork();
    string dbaddress = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        dbaddress = (Request.PhysicalApplicationPath).ToString() + "App_Data\\" + temp.getdbparam((Request.PhysicalApplicationPath).ToString() + "app_data/config.txt").GetValue(1).ToString();
    }
    protected void addbutton_Click(object sender, EventArgs e)
    {
        host temphost = new host(hostipform.Text, hostnameform.Text, System.Int32.Parse(hostscanint.Text), grouptextbox.Text);
        string strAccessSelect = "SELECT Код FROM hosts";
        int lastnum = 0;

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(strAccessSelect, connection);
        cmd.CommandText = strAccessSelect;
        cmd.Connection = connection;

        connection.Open();

        OleDbDataReader readID = cmd.ExecuteReader(); // Выполняем команду
        while (readID.Read())
        {
            lastnum = Convert.ToInt32(readID["Код"]); // Присваиваем таймеру значение максимального id
        }
        readID.Close();
        lastnum++;
        string strAccessInsert = "INSERT INTO hosts (код,ip,name,mac,scanint,grp) values (" + lastnum + ",'" + temphost.Ip + "','" + temphost.Name + "','" + temphost.Mac + "','" + temphost.Scanint + "','" + temphost.Group + "')";
        cmd.CommandText = strAccessInsert;
        cmd.ExecuteNonQuery();

        connection.Close();
    }
    protected void clearbutton_Click(object sender, EventArgs e)
    {
        hostipform.Text = "";
        hostnameform.Text = "";
        grouptextbox.Text = "";
        resulttextbox.Text = "";
    }
    protected void resolvebutton_Click(object sender, EventArgs e)
    {
        host temphost = new host(hostipform.Text, hostnameform.Text, grouptextbox.Text);
        icmp tempicmp = new icmp();

        if (temphost.Ip == "")
        {
            hostipform.Text = tempicmp.resolveip(temphost.Name);
        }
        else { hostipform.Text = temphost.Ip; };

        if (temphost.Name == "")
        {
            hostnameform.Text = tempicmp.resolvename(temphost.Ip);
        }
        else { hostnameform.Text = temphost.Name; };

        resulttextbox.Text = tempicmp.ping(hostipform.Text);
    }
    protected void testbutton_Click(object sender, EventArgs e)
    {
        host temphost = new host(hostipform.Text);
        icmp tempicmp = new icmp();
        resulttextbox.Text = tempicmp.ping(temphost.Ip);
    }
    protected void hostnameform_TextChanged(object sender, EventArgs e)
    {
        hostipform.Text = "";
    }
    protected void hostipform_TextChanged(object sender, EventArgs e)
    {
        hostnameform.Text = "";
    }
}
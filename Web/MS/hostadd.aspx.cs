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
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void addbutton_Click(object sender, EventArgs e)
    {
        string dbaddress = "E:\\hosts.accdb";
        host temphost = new host(hostipform.Text, hostnameform.Text, hostmacform.Text, System.Int32.Parse(hostscanint.Text));
        string strAccessSelect = "SELECT Код FROM hosts";
        int lastnum = 0;
        try
        {
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
            string strAccessInsert = "INSERT INTO hosts (код,ip,name,mac,scanint) values (" + lastnum + ",'" + temphost.Ip + "','" + temphost.Name + "','" + temphost.Mac + "','" + temphost.Scanint + "')";
            cmd.CommandText = strAccessInsert;
            cmd.ExecuteNonQuery();
 
            connection.Close();
        }
        catch (Exception ex)
        {
            resulttextbox.Text=ex.Message;
            return;
        }
    }
    protected void clearbutton_Click(object sender, EventArgs e)
    {
        hostipform.Text = "";
        hostmacform.Text = "";
        hostnameform.Text = "";
        resulttextbox.Text = "";
    }
    protected void resolvebutton_Click(object sender, EventArgs e)
    {
        host temphost = new host(hostipform.Text, hostnameform.Text, hostmacform.Text);
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

        if (temphost.Mac == "")
        {
            hostmacform.Text = tempicmp.resolvemac(temphost.Ip);
        }
        else { hostmacform.Text = temphost.Mac; };

        resulttextbox.Text = tempicmp.ping(hostipform.Text);
    }
    protected void testbutton_Click(object sender, EventArgs e)
    {
        host temphost = new host(hostipform.Text, hostnameform.Text, hostmacform.Text);
        icmp tempicmp = new icmp();
        resulttextbox.Text=tempicmp.ping(temphost.Ip);
    }
    protected void hostnameform_TextChanged(object sender, EventArgs e)
    {
        hostipform.Text = "";
        hostmacform.Text = "";
    }
    protected void hostipform_TextChanged(object sender, EventArgs e)
    {
        hostmacform.Text = "";
        hostnameform.Text = "";
    }
}
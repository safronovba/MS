using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data.OleDb;
using System.Data;

public partial class scan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string dbaddress = "E:\\hosts.accdb";
        dbwork db = new dbwork();
        try
        {
            db.addtbforscandb(dbaddress, "forscan");
        }
        catch (Exception ex) {scanstate.Text=ex.ToString();}
        IPAddress fromip = IPAddress.Parse(scanrangefrombox.Text);
        IPAddress toip = IPAddress.Parse(scanrangetobox.Text);
        icmp temp = new icmp();

        int re = 1, id = 1;
        re = System.Int32.Parse(retrycountbox.Text);
        var ips = temp.ExpandIpRange(fromip, toip);
        foreach (var ip in ips)
        {
            id++;
            db.insertdb(dbaddress, "INSERT INTO forscan (Код,ip) values (" + id + ",'" + ip + "')");
        }
        scanstate.Text = (id-1) + " devices to check";
    }
}
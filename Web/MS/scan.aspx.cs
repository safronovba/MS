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
        IPAddress fromip = null;
        IPAddress toip = null;

        if (db.tableexist(dbaddress, "forscan"))
        {
            db.droptdforscandb(dbaddress, "forscan");
            db.addtbforscandb(dbaddress, "forscan"); 
        }
        else
        { 
            db.addtbforscandb(dbaddress, "forscan"); 
        }


        try
        {
            fromip = IPAddress.Parse(scanrangefrombox.Text);
            toip = IPAddress.Parse(scanrangetobox.Text);
        }
        catch
        { scanstate.Text = "Wrong ip"; }
        icmp temp = new icmp();

        int re = 1, id = 1;
        re = System.Int32.Parse(retrycountbox.Text);
        string group = groupnamebox.Text;
        var ips = temp.ExpandIpRange(fromip, toip);
        foreach (var ip in ips)
        {
            id++;
            db.insertdb(dbaddress, "INSERT INTO forscan (Код,ip,grp) values (" + id + ",'" + ip + "','" + group + "')");
        }
  //      scanstate.Text = "Range send to check";
    }
}
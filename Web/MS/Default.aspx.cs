using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    StreamReader s = File.OpenText("config.txt");
        //    string read = null;
        //    while ((read = s.ReadLine()) != null)
        //    {
        //        addressbox.Text = (read);
        //    }
        //    s.Close();
        //}
        //catch (Exception ex) { Console.ReadKey(); return; }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    FileInfo f = new FileInfo("config.txt");
        //    StreamWriter w = f.CreateText();
        //    w.WriteLine(addressbox.Text);
        //    w.Write(w.NewLine);
        //    w.Close();
        //}
        //catch (Exception ex) { Console.Write(ex); Console.ReadKey(); return; }

        string dbaddress = "Z:\\hosts.accdb";
        Response.Redirect("monitoring.aspx");
  //      db.droptdforscandb(dbaddress, "Test");
        
    }
}
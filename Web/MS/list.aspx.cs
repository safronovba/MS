using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dbwork temp = new dbwork();
    string dbaddress = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        dbaddress = temp.getdbparam((Request.PhysicalApplicationPath).ToString() + "app_data/config.txt").GetValue(1).ToString();
        AccessDataSource1.DataFile = dbaddress;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
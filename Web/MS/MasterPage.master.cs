using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    dbwork temp = new dbwork();
    private string masterdb = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Text = CultureInfo.CurrentCulture.DisplayName;
        try
        {
            masterdb = temp.getdbparam((Request.PhysicalApplicationPath).ToString() + "app_data/config.txt").GetValue(1).ToString();
            Label1.Text = masterdb;
        }
        catch (Exception)
        {
            Response.Redirect("error.aspx");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class monitoring : System.Web.UI.Page
{
    dbwork temp = new dbwork();
    string dbaddress = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        dbaddress = (Request.PhysicalApplicationPath).ToString() + "App_Data\\" + temp.getdbparam((Request.PhysicalApplicationPath).ToString() + "app_data/config.txt").GetValue(1).ToString();
        AccessDataSource1.DataFile = dbaddress;
    }
}
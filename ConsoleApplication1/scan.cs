﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mssupport
{
    class scan
    {
        public void scannow()
        {
            Console.WriteLine("Now scan.");
            string dbaddress = "E:\\hosts.accdb";
            dbwork db = new dbwork();
            icmp temp = new icmp();
            string tempip = null;

            dbaddress = db.getdbparam("config.txt").GetValue(0).ToString();
            db.setdbparam("config.txt", 1, "scanworknow");

            int lastid = db.findlastkod(dbaddress, "hosts");
            int tempkod = 0;
            string tempname = "", tempgroup="";

            if (db.tableexist(dbaddress,"forscan")){

            OleDbDataReader tempread = db.readdb(dbaddress, "SELECT Код,ip,grp FROM forscan");

            while (tempread.Read())
            {
                tempkod = Convert.ToInt32(tempread["Код"]);
                tempip = tempread["ip"].ToString();
                tempgroup = tempread["grp"].ToString();

                if (temp.ping(tempip, 1))
                {
                    lastid++;
                    tempname=temp.resolvename(tempip);
                    db.insertdb(dbaddress, "INSERT INTO hosts (Код,ip,name,scanint,grp) values (" + lastid + ",'" + tempip + "','" + tempname + "',22,'" + tempgroup + "')");
                    if (tempname == tempip)
                    {
                        Console.WriteLine("!New device with ip " + tempip);
                    }
                    else
                    {
                        Console.WriteLine("!New device " + tempname + " with ip " + tempip);
                    }
                }
                else
                {
                    Console.WriteLine("No icmp device at " + tempip);
                }
            }
            Process MyProc = new Process();
            MyProc.StartInfo.FileName = "MSservice.exe";
            MyProc.StartInfo.Arguments = "deltd";
            MyProc.Start();}
        }
    }
}

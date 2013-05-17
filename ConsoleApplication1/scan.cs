using System;
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
            string dbaddress = "Z:\\hosts.accdb";
            dbwork db = new dbwork();
            icmp temp = new icmp();
            string tempip = null;

            dbaddress = db.getdbaddress("config.txt");

           
                int lastid = db.findlastkod(dbaddress, "hosts");
                int tempkod = 0;

                OleDbDataReader tempread = db.readdb(dbaddress, "SELECT Код,ip FROM forscan");

                while (tempread.Read())
                {
                    tempkod = Convert.ToInt32(tempread["Код"]);
                    tempip = tempread["ip"].ToString();

                    if (temp.ping(tempip, 1))
                    {
                        lastid++;
                        Console.WriteLine("before");
                        db.insertdb(dbaddress, "INSERT INTO hosts (Код,ip,scanint) values (" + lastid + ",'" + tempip + "',22)");
                        Console.WriteLine("new device: " + tempip);
                    }
                }
                Process MyProc = new Process();
                MyProc.StartInfo.FileName = "MSservice.exe";
                MyProc.StartInfo.Arguments = "del";
                MyProc.Start();
        }
    }
}

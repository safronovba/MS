using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace mssupport
{
    class monitor
    {
        public void checknow()
        {
            string dbaddress = "Z:\\hosts.accdb";
            Process MyProc = new Process();
            icmp icmp = new icmp();
            dbwork db = new dbwork();

            string newnowstate = "", newlasterror = "", newlastsuccess = "";
            DateTime newlasttime = DateTime.Parse("00:00:00");
            int tempkod = 0, n = 0;
            int scanint;

            dbaddress = db.getdbaddress("config.txt");

            if (db.tableexist(dbaddress, "forscan"))
            {
                MyProc.StartInfo.FileName = "MSservice.exe";
                MyProc.StartInfo.Arguments = "scan";
                MyProc.Start();
            }

            while (n < 3)
            {
                OleDbDataReader tempread = db.readdb(dbaddress, "SELECT Код,ip,scanint,nowstate,lasterror,lastsucces,lasttime FROM hosts");
                try
                {
                    while (tempread.Read())
                    {
                        tempkod = Convert.ToInt32(tempread["Код"]);
                        try
                        {
                            scanint = Convert.ToInt32(tempread["scanint"]);
                        }
                        catch (Exception ex) { Console.WriteLine("Convert scanint error: " + ex); scanint = 0; }
                        host temp = new host(tempkod, (tempread["ip"]).ToString(), scanint, (tempread["nowstate"]).ToString(), (tempread["lasterror"]).ToString(), (tempread["lastsucces"]).ToString(), (tempread["lasttime"]).ToString());

                        if (temp.timecheck())
                        {
                            newnowstate = "";
                            newlasterror = "";
                            newlastsuccess = "";
                            newlasttime = DateTime.Parse("00:00:00");

                            Console.Write("host: " + temp.Ip + "\t");
                            if (icmp.ping(temp.Ip, 1))
                            {
                                newnowstate = "ok";
                                newlastsuccess = icmp.ping(temp.Ip);
                                newlasttime = DateTime.Now;
                                db.updatedb(dbaddress, "UPDATE hosts SET nowstate='" + newnowstate + "', lastsucces='" + newlastsuccess + "', lasttime='" + newlasttime + "' WHERE Код =" + tempkod);
                            }
                            else
                            {
                                newnowstate = "na";
                                newlasterror = DateTime.Now.ToString();
                                newlasttime = DateTime.Now;
                                db.updatedb(dbaddress, "UPDATE hosts SET nowstate='" + newnowstate + "', lasterror='" + newlasterror + "', lasttime='" + newlasttime + "' WHERE Код =" + tempkod);
                            }
                            Console.WriteLine(newnowstate);
                        }
                    }
                }
                catch (Exception ex) { Console.Write("Ошибка tempread.Read()\n" + ex); Console.ReadKey(); return; }
                n++;
                Console.WriteLine("Sleep for 10 seconds. | " + n);
                Thread.Sleep(10000);
            }

            MyProc.StartInfo.FileName = "MSservice.exe";
            MyProc.StartInfo.Arguments = "check";
            MyProc.Start();

        }
    }
}

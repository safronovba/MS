using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mssupport
{
    class scan
    {
        public void scannow()
        {
            Console.WriteLine("Scan");

            Process MyProc = new Process();
            dbwork db = new dbwork();
            icmp temp = new icmp();

            MyProc.StartInfo.FileName = "MSservice.exe";

            string dbaddress = null;
            string tempip = null;
            int errortimes = 0;

            Console.WriteLine("read cfg");
            dbaddress = db.getdbparam("config.txt").GetValue(0).ToString();

            Console.WriteLine("Write new cfg");
            db.setdbparam("config.txt", 1, "scanworknow");

            int lastid = db.findlastkod(dbaddress, "hosts") + 1;
            int tempkod = 0;
            string tempname = "", tempgroup = "";

            Console.WriteLine("Start scan.");
            if (db.tableexist(dbaddress, "forscan"))
            {
                try
                {
                    Console.WriteLine("Table exists");
                    OleDbDataReader tempread = db.readdb(dbaddress, "SELECT Код,ip,grp FROM forscan");

                    while (tempread.Read())
                    {
                        Console.Write("Read next one: ");
                        tempkod = Convert.ToInt32(tempread["Код"]);
                        tempip = tempread["ip"].ToString();
                        Console.WriteLine(tempip);
                        tempgroup = tempread["grp"].ToString();

                        if (db.doubleipcheck(dbaddress, tempip))
                        {
                            Console.WriteLine("Try to ping");
                            if (temp.ping(tempip, 2))
                            {
                                Console.WriteLine("New host avalible.\nTry to resolve hostname");
                                tempname = temp.resolvename(tempip);
                                if (tempname == tempip)
                                {
                                    Console.WriteLine("!New device with ip " + tempip + "\nWrite it to db.");
                                }
                                else
                                {
                                    Console.WriteLine("!New device " + tempname + " with ip " + tempip + "\nWrite it to db.");
                                }

                                db.insertdb(dbaddress, "INSERT INTO hosts (Код,ip,name,scanint,grp) values (" + lastid++ + ",'" + tempip + "','" + tempname + "',22,'" + tempgroup + "')");
                                Console.WriteLine("Done.\n");
                            }
                            else
                            {
                                Console.WriteLine("No icmp device at " + tempip + "\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Host " + tempip + " not new\n");
                        }
                    }
                    Thread.Sleep(3000);

                    MyProc.StartInfo.Arguments = "deltd";
                    MyProc.Start();
                }
                catch (Exception ex)
                {
                    Console.Write("Ошибка tempread.Read()\n" + ex + "\n" + errortimes++ + " times already");
                    if (errortimes > 3)
                    {
                        MyProc.StartInfo.Arguments = "scan";
                        MyProc.Start();
                        return;
                    }
                }
            }
        }
    }
}

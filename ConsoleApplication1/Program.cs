using System;
using System.Threading;

namespace mssupport
{
    class Program
    {
        static void Main(string[] args)
        {
            monitor m1 = new monitor();
            scan s1 = new scan();
            dbwork db = new dbwork();

            string dbaddress = db.getdbparam("config.txt").GetValue(0).ToString();

            int scaninterval = 3000;

            if (args.Length == 0)
            {
                m1.checknow();
                while (1 == 1) 
                {
                    Console.Write("q");
                    s1.scannow();
                    Thread.Sleep(scaninterval);
                }
            }
            else
            {
                if (args[0] == "scan")
                {
                     s1.scannow(); return;
                }
                if (args[0] == "del")
                {
                    db.droptdforscandb(dbaddress, "forscan");
                    db.setdbparam("config.txt", 1, "scanstopnow");
                    return;
                }
                if (args[0] == "check")
                {
                    m1.checknow(); return;
                }
                
            }
        }
    }
}

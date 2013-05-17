using System;

namespace mssupport
{
    class Program
    {
        static void Main(string[] args)
        {
            monitor m1 = new monitor();
            if (args.Length == 0)
            {
                m1.checknow();
                return;
            }
            else
            {
                if (args[0] == "scan")
                {
                    scan s1 = new scan(); s1.scannow(); return;
                }
                if (args[0] == "del")
                {
                    dbwork db = new dbwork();
                    string dbaddress = db.getdbaddress("config.txt");
                    db.droptdforscandb(dbaddress, "forscan");
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

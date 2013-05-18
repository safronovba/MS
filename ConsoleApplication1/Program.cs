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

            Console.WriteLine("Hello. Database file at "+dbaddress+"\n");

            if (args.Length == 0)
            {
                m1.checknow();
            }
            else
            {
                if (args[0] == "scantd")
                {
                     s1.scannow(); return;
                }
                if (args[0] == "deltd")
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

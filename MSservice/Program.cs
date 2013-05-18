using System;
using System.Threading;


namespace mssupport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello.");

            monitor m1 = new monitor();
            scan s1 = new scan();
            dbwork db = new dbwork();
            string dbaddress=null;

            try { dbaddress = db.getdbparam("config.txt").GetValue(0).ToString(); }
            catch (System.IO.FileNotFoundException) { Console.WriteLine("Config file is not found"); Console.ReadKey(); return; }

            try 
            { 
                db.tableexist(dbaddress, "hosts"); 
            }
            catch (InvalidOperationException) 
            { 
                Console.WriteLine("You have no AccessDatabaseEngine. Contact your administrator."); 
                Console.ReadKey(); 
                return; 
            }

            Console.WriteLine("Database file at "+dbaddress+"\n");

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
                    Console.WriteLine("Now table forscan delete");
                    try
                    {
                        db.droptdforscandb(dbaddress, "forscan");
                    }
                    catch (System.Data.OleDb.OleDbException) { Console.WriteLine("Can not delete"); return; }
                    Console.WriteLine("Complite.\nWrite new cfg");
                    db.setdbparam("config.txt", 1, "scanstopnow");
                    Console.WriteLine("Done\nGood bye.");
                    Thread.Sleep(3000);
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

﻿using System;
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

            string dbaddress = db.getdbparam("config.txt").GetValue(0).ToString();

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
                    db.droptdforscandb(dbaddress, "forscan");
                    Console.WriteLine("Complite.\nWrite new cfg file");
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

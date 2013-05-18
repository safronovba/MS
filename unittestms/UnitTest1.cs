using System;
using System.Data.OleDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using mssupport;



namespace unittestms
{
    [TestClass]
    public class UnitTest1
    {
        host newhost = new host("10.0.0.1");
        icmp newicmp = new icmp();
        dbwork newdb = new dbwork();
        string dbaddress=null;

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void DbAccessExceptionTest() //dbaccess test
        {
            dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
            newdb.tableexist(dbaddress, "forscan1");
        }

        [TestMethod]
        public void DbAccessTest() //dbaccess test
        {
            dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
            newdb.tableexist(dbaddress, "forscan");
        }

        [TestMethod]
        public void DbCreateTableTest() //dbaccess test
        {
            dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
            newdb.addtbforscandb(dbaddress, "forscan");
        }

        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void DbCreateTableExceptionDBTest() //dbaccess test
        {
            newdb.addtbforscandb("hereisnodb", "forscan");
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.FileNotFoundException))]
        public void DbReadExceptionCFGTest() //dbaccess test
        {
            dbaddress = newdb.getdbparam("config1.txt").GetValue(0).ToString();
        }

        [TestMethod]
        public void DbReadCFGTest() //dbaccess test
        {
            dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
        }


        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void DbUpdateTest() //dbaccess test
        {
            dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
            newdb.updatedb(dbaddress, "UPDATE forscan SET (Код='0', ip='0.0.0.0', grp=test) WHERE id=0");
        }
    
        [TestMethod]
        [ExpectedException(typeof(OleDbException))]
        public void DbUpdateExceptionTest() //dbaccess test
        {
            dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
            newdb.updatedb(dbaddress, "UPDATE forscan1 SET (Код='0', ip='0.0.0.0', grp=test) WHERE id=0");
        }
    }
}

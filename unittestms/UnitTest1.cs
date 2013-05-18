using System;
using System.Net;
using System.Data.OleDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest1
{
    host newhost = new host("10.0.0.1");
    icmp newicmp = new icmp();
    dbwork newdb = new dbwork();
    string dbaddress = null;

    [TestMethod]
    [ExpectedException(typeof(OleDbException))]
    public void DbAccessExceptionTest()  
    {
        dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
        newdb.tableexist(dbaddress, "forscan1", true);
    }

    [TestMethod]
    public void DbCreateTableTest()  
    {
        dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
        newdb.addtbforscandb(dbaddress, "forscan");
    }

    [TestMethod]
    public void DbAccessTest()
    {
        dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
        newdb.tableexist(dbaddress, "forscan", true);
    }

    [TestMethod]
    public void DbDeleteTableTest()
    {
        dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
        newdb.droptdforscandb(dbaddress, "forscan");
    }

    [TestMethod]
    [ExpectedException(typeof(OleDbException))]
    public void DbCreateTableExceptionDBTest()  
    {
        newdb.addtbforscandb("hereisnodb", "forscan");
    }

    [TestMethod]
    [ExpectedException(typeof(System.IO.FileNotFoundException))]
    public void DbReadExceptionCFGTest()  
    {
        dbaddress = newdb.getdbparam("config1.txt").GetValue(0).ToString();
    }

    [TestMethod]
    public void DbReadCFGTest()  
    {
        dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
    }


    [TestMethod]
    [ExpectedException(typeof(OleDbException))]
    public void DbUpdateTest()  
    {
        dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
        newdb.updatedb(dbaddress, "UPDATE forscan SET (Код='0', ip='0.0.0.0', grp=test) WHERE id=0");
    }

    [TestMethod]
    [ExpectedException(typeof(OleDbException))]
    public void DbUpdateExceptionTest()  
    {
        dbaddress = newdb.getdbparam("config.txt").GetValue(0).ToString();
        newdb.updatedb(dbaddress, "UPDATE forscan1 SET (Код='0', ip='0.0.0.0', grp=test) WHERE id=0");
    }

    [TestMethod]
    public void HostTimeCheckTest()  
    {
        host temp = new host(0, "0", 10, "0", "0", "0", DateTime.Now.ToUniversalTime().ToString());
        temp.timecheck();
    }

    [TestMethod]
    [ExpectedException(typeof(System.FormatException))]
    public void HostTimeCheckExceptionTest()  
    {
        host temp = new host(0, "0", 10, "0", "0", "0", "0");
        temp.timecheck();
    }

    [TestMethod]
    public void IcmpPingTest()  
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        newicmp.ping(ip);
    }

    [TestMethod]
    [ExpectedException(typeof(System.FormatException))]
    public void IcmpPingExceptionTest()  
    {
        IPAddress ip = IPAddress.Parse("");
        newicmp.ping(ip);
    }

    [TestMethod]
    public void IcmpAvalibleTest()  
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        newicmp.ping(ip,2);
    }

    [TestMethod]
    [ExpectedException(typeof(System.FormatException))]
    public void IcmpAvaliblePingExceptionTest()  
    {
        IPAddress ip = IPAddress.Parse("");
        newicmp.ping(ip,2);
    }
}
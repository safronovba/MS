using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;


public class dbwork
{
    public string[] getdbparam(string filename)
    {
        StreamReader reader = File.OpenText(filename);
        string[] exit = new string[10];
        int i = 0;

        while ((exit[i] = reader.ReadLine()) != null)
        {
            i++;
        }
        reader.Close();

        if (exit[1].Contains("accdb")) 
        { 
            return exit; 
        }
        return null;
    }

    public void setdbparam(string filename, int i, string param)
    {
        StreamReader reader = new StreamReader(filename);
        string[] temp = new string[10];
        int j = 0,max=0;

        while ((temp[j] = reader.ReadLine())!=null)
        {
            j++; max++;
        }
        reader.Close();

        // todo:         Regex.Replace(param,"\\","\\");

        temp[i] = Regex.Replace(temp[i], temp[i], param);

        StreamWriter writer = new StreamWriter(filename);
        for (j = 0; j < max; j++) { writer.WriteLine(temp[j]); }
        writer.Close();
    }

    public OleDbDataReader readdb(string dbaddress, string strAccessSelect)
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(strAccessSelect, connection);

        try
        {
            connection.Open();
            OleDbDataReader temp = cmd.ExecuteReader();
            return temp;
        }
        catch (Exception)
        {
            Console.WriteLine("error from readdb");
            return null;
        }

    }

    public void updatedb(string dbaddress, string strAccessInsert)
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(strAccessInsert, connection);

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public void insertdb(string dbaddress, string strAccessInsert)
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(strAccessInsert, connection);

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();
    }

    public int findlastkod(string dbaddress, string str)
    {
        dbwork db = new dbwork();
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand("SELECT Код FROM " + str, connection);
        int lastnum = 0;

        if (db.tableexist(dbaddress, str))
        {
            connection.Open();

            OleDbDataReader readID = cmd.ExecuteReader(); // Выполняем команду
            while (readID.Read())
            {
                lastnum = Convert.ToInt32(readID["Код"]); // Присваиваем таймеру значение максимального id
            }
            readID.Close();
            connection.Close();
            return lastnum;
        }
        return 1;
    }

    public bool tableexist(string dbaddress, string str)
    {
        dbwork db = new dbwork();
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand("SELECT Код FROM " + str, connection);

        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (OleDbException) { if (str=="hosts") Console.WriteLine("DB does not exists"); return false; }
        return true;
    }

    public bool tableexist(string dbaddress, string str, bool unittest)
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand("SELECT Код FROM " + str, connection);

        if (unittest)
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (OleDbException) { return false; }
        return true;
    }

    public void droptdforscandb(string dbaddress, string str)
    {
        dbwork db = new dbwork();
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand("DROP TABLE " + str, connection);

        if (db.tableexist(dbaddress, str))
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void addtbforscandb(string dbaddress, string str)
    {
        dbwork db = new dbwork();
        if (db.tableexist(dbaddress, str)) { return; };

        str = "CREATE TABLE " + str + "(Код Integer, ip VARCHAR, grp VARCHAR)";

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(str, connection);

        connection.Open();
        cmd.ExecuteNonQuery();
        connection.Close();

    }

    public void addmaindb(string dbaddress, string nowdirect)
    {
        dbwork db = new dbwork();
        if (db.tableexist(dbaddress, "hosts")) { return; };

        File.Copy(nowdirect+"/app_data/newdb.accdb", dbaddress);
    }

    public bool doubleipcheck(string dbaddress, string newip)
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand("SELECT ip FROM hosts", connection);
        OleDbDataReader tempread = null;
        dbwork db = new dbwork();

        if (db.tableexist(dbaddress, "hosts"))
        {
            connection.Open();
            tempread = cmd.ExecuteReader();
            while (tempread.Read())
            {
                if (newip == tempread["ip"].ToString()) { return false; }
            }
        }
        return true;
    }

    public string[] takehosts(string dbaddress)
    {
        Console.WriteLine("Loading ip from hosts..");
        dbwork db = new dbwork();
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand("SELECT ip FROM hosts", connection);
        int i = 0;

        string[] hosts = new string[db.findlastkod(dbaddress, "hosts")];

        connection.Open();

        OleDbDataReader read = cmd.ExecuteReader();
        while (read.Read())
        {
            hosts[i] = read["ip"].ToString();
            i++;
        }
        read.Close();
        connection.Close();
        return hosts;

    }
}

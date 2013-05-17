using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Сводное описание для dbwork
/// </summary>

public class dbwork
{
    public string getdbaddress(string filename)
    {
        try
        {
            StreamReader s = File.OpenText(filename);
            string read = null;
            while ((read = s.ReadLine()) != null)
            {
                return read;
            }
            s.Close();
            return null;
        }
        catch (Exception ex) { Console.Write(ex); return null; }
    }

    public OleDbDataReader readdb(string dbaddress, string strAccessSelect)
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(strAccessSelect, connection);
        cmd.CommandText = strAccessSelect;
        cmd.Connection = connection;
        try
        {
            connection.Close();
            connection.Open();
            return cmd.ExecuteReader();

        }
        catch (Exception ex)
        {
            Console.WriteLine("error: " + ex.Message);
            return null;
        }

    }

    public void updatedb(string dbaddress, string strAccessInsert)
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(strAccessInsert, connection);
        cmd.CommandText = strAccessInsert;
        cmd.Connection = connection;
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("error: " + ex.Message);
        }
    }

    public void insertdb(string dbaddress, string strAccessInsert)
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(strAccessInsert, connection);
        cmd.CommandText = strAccessInsert;
        cmd.Connection = connection;
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("error: " + ex.Message);
        }
    }

    public void droptdforscandb(string dbaddress, string str)
    {
        str = "DROP TABLE " + str;
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(str, connection);
        cmd.CommandText = str;
        cmd.Connection = connection;
        try
        {
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("error: " + ex.Message);
        }
    }
        public void addtbforscandb(string dbaddress, string str)
        {
            str = "CREATE TABLE " + str + "(Код Integer, ip VARCHAR)";
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
        OleDbCommand cmd = new OleDbCommand(str, connection);
        cmd.CommandText = str;
        cmd.Connection = connection;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
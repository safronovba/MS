﻿using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class dbwork
{
    public string[] getdbparam(string filename)
    {
        StreamReader reader = File.OpenText(filename);
        string[] exit = new string[5];
        int i = 0;

        while ((exit[i] = reader.ReadLine()) != null)
        {
            i++;
        }
        reader.Close();
        return exit;
    }

    public void setdbparam(string filename, int i, string param)
    {

        StreamReader reader = new StreamReader(filename);
        string content = null, temp = null;

        for (int j = 0; j != i + 1; j++)
        {
            temp = reader.ReadLine();
            content = content + temp;
            content = content + '\n';
        }

        reader.Close();

        content = Regex.Replace(content, temp, param);

        StreamWriter writer = new StreamWriter(filename);
        writer.Write(content);
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
        catch (OleDbException) { return false; }
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
}

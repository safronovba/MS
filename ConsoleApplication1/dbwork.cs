using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mssupport
{
    class dbwork
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

            try
            {
                connection.Open();
                OleDbDataReader temp = cmd.ExecuteReader();
                //              connection.Close();
                return temp;


            }
            catch (Exception ex)
            {
                Console.WriteLine("error from readdb: " + ex.Message);
                return null;
            }

        }

        public void readdbclose(string dbaddress, string strAccessSelect)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
            OleDbCommand cmd = new OleDbCommand("SELECT Код,ip FROM forscan", connection);
            string tempip = "";

            try
            {
                connection.Open();

                //OleDbDataReader tempread = cmd.ExecuteReader();

                //while (tempread.Read())
                //{
                //    tempip = tempread["ip"].ToString();
                //}
                connection.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("error from readdb: " + ex.Message);
            }

        }

        public void updatedb(string dbaddress, string strAccessInsert)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
            OleDbCommand cmd = new OleDbCommand(strAccessInsert, connection);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from updatedb: " + ex.Message);
            }
        }

        public void insertdb(string dbaddress, string strAccessInsert)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
            OleDbCommand cmd = new OleDbCommand(strAccessInsert, connection);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from insertdb: " + ex.Message);
            }
        }

        public int findlastkod(string dbaddress, string str)
        {
            dbwork db = new dbwork();

            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
            OleDbCommand cmd = new OleDbCommand("SELECT Код FROM " + str, connection);
            int lastnum = 0;

            try
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
            catch (Exception ex)
            {
                Console.WriteLine("error from findlastkod: " + ex.Message);
                return 1;
            }
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
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from tableexist: " + ex.Message);
                return false;
            }
        }

        public void droptdforscandb(string dbaddress, string str)
        {
            str = "DROP TABLE " + str;
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
            OleDbCommand cmd = new OleDbCommand(str, connection);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from droptdforscandb: " + ex.Message);
            }
        }
        public void addtbforscandb(string dbaddress, string str)
        {
            str = "CREATE TABLE " + str + "(Код Integer, ip VARCHAR)";
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
            OleDbCommand cmd = new OleDbCommand(str, connection);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error from addtbforscandb: " + ex.Message);
            }
        }
    }
}

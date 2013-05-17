using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mssupport
{
    class dbwork
    {
        public string[] getdbparam(string filename)
        {
            try
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
            catch (Exception ex) { Console.Write(ex); return null; }
        }

        public void setdbparam(string filename,int i, string param)
        {
            try
            {
                StreamReader reader = new StreamReader(filename);
                string content=null, temp=null;

                for (int j = 0; j != i+1; j++)
                {
                    temp = reader.ReadLine();
                    content = content+ temp;
                    content = content + '\n';
                }

                reader.Close();

                content = Regex.Replace(content,temp,param);

                StreamWriter writer = new StreamWriter(filename);
                writer.Write(content);
                writer.Close();                 
            }
            catch (Exception) {}
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

        public void readdbclose(string dbaddress, string strAccessSelect)
        {
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbaddress);
            OleDbCommand cmd = new OleDbCommand("SELECT Код,ip FROM forscan", connection);
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("error from readdb");
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
            catch (Exception)
            {
                Console.WriteLine("error from updatedb");
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
            catch (Exception)
            {
                Console.WriteLine("error from insertdb");
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
            catch (Exception)
            {
                Console.WriteLine("error from findlastkod");
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
            catch (Exception)
            {
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
            catch (Exception)
            {
                Console.WriteLine("error from droptdforscandb");
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
            catch (Exception)
            {
                Console.WriteLine("error from addtbforscandb:");
            }
        }
    }
}

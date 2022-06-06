using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace MovieDB_Info_Library.ViewModel
{
    internal class AddUser
    {
        public static bool CreateUser(string login, string Username, string password)
        {
            //Var
            int UID = 0;
            string salt = HashPassword.CreateSalt(16);
            var sqlstatment = "";

            //Login to DB And Check Mail
            var Connection = new MySqlConnection(login);
            Connection.Open();
            sqlstatment = "select * from user";
            var getmail = new MySqlCommand(sqlstatment, Connection);
            MySqlDataReader mailreader = getmail.ExecuteReader();
            while (mailreader.Read())
            {
                if (String.Equals(mailreader["username"], Username))
                {
                    MessageBox.Show("Username is already in use!", "error");
                    Connection.Close();
                    return false;
                }
            }
            mailreader.Close();


            //Password To SHA256 Generator
            string hPassword = HashPassword.ComputeHash(password, salt);

            //https://www.codegrepper.com/code-examples/csharp/select+mysql+c%23
            //https://zetcode.com/csharp/mysql/
            //Login to DB And Get New UID
            sqlstatment = "select * from user";
            var getuid = new MySqlCommand(sqlstatment, Connection);
            MySqlDataReader reader = getuid.ExecuteReader();
            while (reader.Read()) { UID = (int)reader["uid"]; }
            UID++;
            reader.Close();

            //Login To DB And Add New User
            var cmd = new MySqlCommand();
            cmd.Connection = Connection;

            cmd.CommandText = $"INSERT INTO user(uid, username,password,  salt) VALUES({UID},\"{Username}\",\"{hPassword}\",\"{salt}\")";
            cmd.ExecuteNonQuery();
            Connection.Close();
            MessageBox.Show("User was added!", "Suc");
            return true;
        }
    }
}

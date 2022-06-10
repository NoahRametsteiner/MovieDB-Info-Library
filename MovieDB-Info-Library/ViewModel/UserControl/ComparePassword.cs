using System;
using MySql.Data.MySqlClient;
using System.Windows;

namespace MovieDB_Info_Library.ViewModel
{
    class ComparePassword
    {
        public static int PasswordCompare(string DBLogin, string Username, string EnterdPassword)
        {

            var Connection = new MySqlConnection(DBLogin);
            Connection.Open();
            var sqlstatment = $"select * from user where username=\"{Username}\"";
            var getemail = new MySqlCommand(sqlstatment, Connection);
            MySqlDataReader reader = getemail.ExecuteReader();

            if (reader.Read())
            {
                string HashedEnterdPassword = HashPassword.ComputeHash(EnterdPassword, (string)reader["salt"]);

                //Console.WriteLine($"HashedEnterdPassword: {HashedEnterdPassword} DBPassword: {(string)reader["password"]}");

                if (String.Equals(HashedEnterdPassword, (string)reader["password"]))
                {
                    sqlstatment = $"select uid from user where username=\"{Username}\"";
                    var getUID = new MySqlCommand(sqlstatment, Connection);
                    reader.Close();
                    reader = getUID.ExecuteReader();
                    reader.Read();
                    return (int)reader["uid"];
                }
            }
            MessageBox.Show("Wrong password or email!", "error");
            Connection.Close();
            return 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using MovieDB_Info_Library.ViewModel;

namespace MovieDB_Info_Library.ViewModel
{
    class ComparePassword
    {
        public static int PasswordCompare(string DBLogin, string Email, string EnterdPassword)
        {

            var Connection1 = new MySqlConnection(DBLogin);
            Connection1.Open();
            var sqlstatment = $"select * from user where email=\"{Email}\"";
            var getemail = new MySqlCommand(sqlstatment, Connection1);
            MySqlDataReader reader = getemail.ExecuteReader();

            if (reader.Read())
            {
                string HashedEnterdPassword = HashPassword.ComputeHash(EnterdPassword, (string)reader["salt"]);

                //Console.WriteLine($"HashedEnterdPassword: {HashedEnterdPassword} DBPassword: {(string)reader["password"]}");

                if (String.Equals(HashedEnterdPassword, (string)reader["password"]))
                {
                    sqlstatment = $"select uid from user where email=\"{Email}\"";
                    var getUID = new MySqlCommand(sqlstatment, Connection1);
                    reader.Close();
                    reader = getUID.ExecuteReader();
                    reader.Read();
                    return (int)reader["uid"];
                }
            }
            MessageBox.Show("Wrong password or email!", "error");
            return 0;
        }
    }
}

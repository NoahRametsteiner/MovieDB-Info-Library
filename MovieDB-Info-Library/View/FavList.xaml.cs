using MovieDB_Info_Library.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MovieDB_Info_Library.View
{
    /// <summary>
    /// Interaktionslogik für FavList.xaml
    /// </summary>
    public partial class FavList : UserControl
    {

        public FavList()
        {
            InitializeComponent();
            ListView1.Items.Clear();

            List<User> users = new List<User>();

            var Connection = new MySqlConnection(MovieViewModel.DBLogin);
            Connection.Open();
            var sqlstatment = $"select movies.mid,moviename from movies join user join favlist where movies.mid=favlist.mid and id={LoginViewModel.UID} group by movies.mid";
            var getemail = new MySqlCommand(sqlstatment, Connection);
            MySqlDataReader reader = getemail.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                users.Add(new User() { Id = i, ImdbID = (string)reader["mid"], Title = (string)reader["moviename"] });
                i++;
            }
            Connection.Close();
            ListView1.ItemsSource = users;
        }

        public class User
        {
            public int Id { get; set; }

            public string Title { get; set; }
            public string ImdbID { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}

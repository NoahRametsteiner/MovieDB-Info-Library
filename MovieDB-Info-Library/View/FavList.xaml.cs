using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MovieDB_Info_Library.ViewModel;

namespace MovieDB_Info_Library.View
{
    /// <summary>
    /// Interaktionslogik für FavList.xaml
    /// </summary>
    public partial class FavList : UserControl
    {

        public FavList()
        {
            //ListView1.Items.Clear();

            var Connection = new MySqlConnection(MovieViewModel.DBLogin);
            Connection.Open();
            var sqlstatment = $"select movies.mid,moviename from movies join user join favlist where movies.mid=favlist.mid and id={ParentViewModel.CurrentUserID} group by movies.mid";
            var getemail = new MySqlCommand(sqlstatment, Connection);
            MySqlDataReader reader = getemail.ExecuteReader();

            if (reader.Read())
            {
                string[] row = { (string)reader["mid"], (string)reader["moviename"] };

                string[] arr = new string[3];
                ListViewItem itm;

                arr[0] = "product_1";
                arr[1] = "100";


                //Fix this futur me, i dont know why this does not work
                itm = new ListViewItem();
                ListView1.Items.Add(itm);

            }
            ListView1.Items.Add("List item text");

            Connection.Close();

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}

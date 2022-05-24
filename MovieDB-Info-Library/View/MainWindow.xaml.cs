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

namespace MovieDB_Info_Library.View
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Search u1 = new Search();
            ContentControl1.Content = u1;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == FavButton)
            {
                FavList FavWindow = new FavList();
                ContentControl1.Content = FavWindow;
            }
            if(sender == SearchButton)
            {
                Search u1 = new Search();
                ContentControl1.Content = u1;

            }
        }
    }
}

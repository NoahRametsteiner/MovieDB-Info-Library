using MovieDB_Info_Library.Model;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows;
using MovieDB_Info_Library.API;

using static System.Net.Mime.MediaTypeNames;
using MySql.Data.MySqlClient;

namespace MovieDB_Info_Library.ViewModel
{
    class DetailViewModel : INotifyPropertyChanged 

    {
        public ICommand MainPageCommand { get; set; }
        public ICommand CallFav { get; set; }

        private Detail newDetail;
        public Detail NewDetail
        {
            get => newDetail;
            set
            {
                newDetail = value;
                RaisePropertyChanged(nameof(NewDetail));
            }
        }


        public DetailViewModel(){

            NewDetail = new Detail();
            NewDetail = MovieViewModel.newDetail;

            try
            {
                using (WebClient client = new WebClient())
                {
                    if(NewDetail!=null)
                    {
                    
                            NewDetail.MovieBanner = client.DownloadData(NewDetail.MoviePoster);
                    
                    }

                }
                if (NewDetail != null)
                {
                    using (var stream = new MemoryStream(NewDetail.MovieBanner))
                    {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                        bitmap.Freeze();
                        newDetail.movieBild = bitmap;
                    }
                }
            }
            catch { }

            MainPageCommand = new RelayCommand(e =>
            {
                //System.Windows.Application.Current.Windows[1].Close();
            }
            );

            //Call Favourites
            CallFav = new RelayCommand(e =>
            {
                MovieViewModel.ResultMovie = Call.APICall(MovieViewModel.SearchTitle);
                AddFav(MovieViewModel.ResultMovie.imdbID, MovieViewModel.ResultMovie.Title);
            }
            );
        }
        public bool AddFav(string imdbID, string title)
        {

            if (title == "" | title == null) { return false; }

            string sqlstatment = "";
            var Connection = new MySqlConnection(MovieViewModel.DBLogin);
            Connection.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = Connection;


            //Gets all movies and if its not in the database add it
            try
            {
                cmd.CommandText = $"INSERT INTO movies(mid, moviename) VALUES(\"{imdbID}\",\"{title}\")";
                cmd.ExecuteNonQuery();
            }
            catch { }

            //Add movie do favlist and check if movie is already fav by user.
            try
            {
                cmd.CommandText = $"INSERT INTO favlist(id, mid) VALUES(\"{LoginViewModel.UID}\",\"{imdbID}\")";
                cmd.ExecuteNonQuery();

            }
            catch { MessageBox.Show("Movie already in your favorite list", "Error"); }

            Connection.Close();
            return true;
        }



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }
}

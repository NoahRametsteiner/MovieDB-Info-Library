using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MovieDB_Info_Library.ViewModel;
using MovieDB_Info_Library.API;
using MovieDB_Info_Library.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MovieDB_Info_Library.View;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace MovieDB_Info_Library.ViewModel
{
    class MovieViewModel : INotifyPropertyChanged
    {
        #region Declarations

        public ICommand CallCommand { get; set; }
        public ICommand CallFav { get; set; }
        public ICommand MainPageCommand { get; set; }
        public ICommand FavPageCommand { get; set; }
        public ICommand DetailCommand { get; set; }
        public ICommand Fav { get; set; }
        
        public FavListe favList;
        public FavListe FavList {
            get => favList;
            set
            {
                favList = value;
                RaisePropertyChanged(nameof(FavList));
            }
        }
        public Boolean flag;
        public string SearchTitle { get; set; }
        Movie Result { get; set; }
        private string resultimdbID;
        private string resultTitle;
        private int resultYear;
        private string resultRated;
        private string resultRuntime;
        private string resultGenre;
        private string resultDirector;
        private string resultActors;
        private string resultPlot;
        private string resultLanguage;
        public static string DBLogin = @"server=sql3.freesqldatabase.com;userid=sql3496579;password=zQdQ2FdWqU;database=sql3496579";

        public string ResultimdbID
        {
            get => resultimdbID;
            set
            {
                resultimdbID = value;
                RaisePropertyChanged(nameof(ResultimdbID));
            }
        }
        public string ResultTitle {
            get => resultTitle;
            set
            {
                resultTitle = value;
                RaisePropertyChanged(nameof(ResultTitle));
            }
        }
        public int ResultYear
        {
            get => resultYear;
            set
            {
                resultYear = value;
                RaisePropertyChanged(nameof(ResultYear));
            }
        }
        public string ResultRated
        {
            get => resultRated;
            set
            {
                resultRated = value;
                RaisePropertyChanged(nameof(ResultRated));
            }
        }
        public string ResultRuntime
        {
            get => resultRuntime;
            set
            {
                resultRuntime = value;
                RaisePropertyChanged(nameof(ResultRuntime));
            }
        }
        public string ResultGenre
        {
            get => resultGenre;
            set
            {
                resultGenre = value;
                RaisePropertyChanged(nameof(ResultGenre));
            }
        }
        public string ResultDirector
        {
            get => resultDirector;
            set
            {
                resultDirector = value;
                RaisePropertyChanged(nameof(ResultDirector));
            }
        }
        public string ResultActors
        {
            get => resultActors;
            set
            {
                resultActors = value;
                RaisePropertyChanged(nameof(ResultActors));
            }
        }
        public string ResultPlot
        {
            get => resultPlot;
            set
            {
                resultPlot = value;
                RaisePropertyChanged(nameof(ResultPlot));
            }
        }
        public string ResultLanguage
        {
            get => resultLanguage;
            set
            {
                resultLanguage = value;
                RaisePropertyChanged(nameof(ResultLanguage));
            }
        }


        public Movie ResultMovie { get; set; }

       
        #endregion



        public MovieViewModel()
        {

            var ctx = new FavContext();
            FavList = FavListe.ConvertFromList(ctx.Favs.ToList());

            //Call API
            CallCommand = new RelayCommand(e =>
                {
                    ResultMovie = Call.APICall(SearchTitle);      //API Call with Movie Title; Expect Movie
                    ResultTitle = ResultMovie.Title;
                    ResultYear = ResultMovie.Year;
                    resultRated = ResultMovie.Rated;
                    ResultRuntime = ResultMovie.Runtime;
                    ResultGenre = ResultMovie.Genre;
                    ResultDirector = ResultMovie.Director;
                    ResultActors = ResultMovie.Actors;
                    ResultPlot = ResultMovie.Plot;
                    ResultLanguage = ResultMovie.Language;
                }
            );
            //Call Favourites
            CallFav = new RelayCommand(e =>
            {

                ResultMovie = Call.APICall(SearchTitle);
                AddFav(ResultMovie.imdbID, ResultMovie.Title);

            }
            ); ;
            MainPageCommand = new RelayCommand(e =>
            {

            });
            Fav = new RelayCommand(e =>
            {
                Favl();
            });
            DetailCommand = new RelayCommand(e =>
            {
                
            });
        }
        //Call this functino to add Favourite to List
        
        public void AddFav(string imdbID, string title)
        {
            bool isalreadyindb = false;

            var Connection = new MySqlConnection(DBLogin);
            Connection.Open();
            var cmd = new MySqlCommand();
            cmd.Connection = Connection;

            string sqlstatment = "select * from movies";
            var getmail = new MySqlCommand(sqlstatment, Connection);
            MySqlDataReader mailreader = getmail.ExecuteReader();
            while (mailreader.Read())
            {
                if (String.Equals(mailreader["mid"], imdbID))
                {
                    isalreadyindb = true;
                }
            }

            mailreader.Close();

            if (isalreadyindb = false)
            {
                cmd.CommandText = $"INSERT INTO movies(mid, moviename) VALUES('{imdbID}','{title}')";
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = $"INSERT INTO favlist(id, mid) VALUES({ParentViewModel.CurrentUserID},'{imdbID}')";
            
            cmd.ExecuteNonQuery();
            Connection.Close();
        }

        public void Favl()
        {

            
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

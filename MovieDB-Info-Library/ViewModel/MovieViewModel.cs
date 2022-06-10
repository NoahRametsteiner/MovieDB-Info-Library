using System;
using System.Linq;
using System.Windows.Input;
using MovieDB_Info_Library.API;
using MovieDB_Info_Library.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MovieDB_Info_Library.View;

namespace MovieDB_Info_Library.ViewModel
{
    class MovieViewModel : INotifyPropertyChanged
    {
        #region Declarations

        //IComands
        public ICommand CallCommand { get; set; }
        public ICommand CallDetail { get; set; }
        public ICommand CallFavDetail { get; set; }

        //
        public Boolean flag;
        private string resultimdbID;
        private string resultTitle;
        private string resultYear;
        private string resultRated;
        private string resultRuntime;
        private string resultGenre;
        private string resultDirector;
        private string resultActors;
        private string resultPlot;
        private string resultLanguage;
        private string resultPoster;
        private static Detail NewDetail;
        public static string DBLogin = @"server=sql3.freesqldatabase.com;userid=sql3496579;password=zQdQ2FdWqU;database=sql3496579";

        //GetterSetter
        Movie Result { get; set; }
        public static string selectedMovie { get; set; }
        public static Movie ResultMovie { get; set; }
        public static string SearchTitle { get; set; }


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
        public string ResultYear
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
        public string ResultPoster
        {
            get => resultPoster;
            set
            {
                resultPoster = value;
                RaisePropertyChanged(nameof(ResultPoster));
            }
        }
        public static Detail newDetail
        {
            get => NewDetail;
            set
            {
                NewDetail = value;
              
            }
        }
        #endregion

        public MovieViewModel()
        {
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
                    ResultPoster = ResultMovie.Poster;
                }
            );

            CallDetail = new RelayCommand(e =>
            {
                if(SearchTitle != null)
                {
                    ResultMovie = Call.APICall(SearchTitle);

                    AddDetail(ResultMovie.Title, ResultMovie.Year, ResultMovie.Rated, ResultMovie.Runtime, ResultMovie.Genre,
                    ResultMovie.Director, ResultMovie.Actors, ResultMovie.Plot, ResultMovie.Language, ResultMovie.Poster);
                }
                MovieDeatail DeatailWindow = new MovieDeatail();
                DeatailWindow.Show();
            });

            CallFavDetail = new RelayCommand(e =>
            {
                if (selectedMovie !=null)
                {
                    ResultMovie = Call.APICall(selectedMovie);

                    AddDetail(ResultMovie.Title, ResultMovie.Year, ResultMovie.Rated, ResultMovie.Runtime, ResultMovie.Genre,
                    ResultMovie.Director, ResultMovie.Actors, ResultMovie.Plot, ResultMovie.Language, ResultMovie.Poster);
                }
                MovieDeatail DeatailWindow = new MovieDeatail();
                DeatailWindow.Show();
            });

        }
        //Call this functino to add Favourite to List

        

        public static void AddDetail(string title, string year,string rated,string runtime,string genre,string director,string actors,string plot,string language,string poster)
        {
            newDetail = new Detail()
            {
                MovieTitle = title,
                MovieYear = year,
                MovieRated = rated,
                MovieRuntime = runtime,
                MovieGenre = genre,
                MovieDirector = director,
                MovieActors = actors,
                MoviePlot = plot,
                MoviePoster = poster
            };

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

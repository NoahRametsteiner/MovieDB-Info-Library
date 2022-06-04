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
using System.Windows;
using System.Collections.ObjectModel;
using MovieDB_Info_Library.View;

namespace MovieDB_Info_Library.ViewModel
{
    class MovieViewModel : INotifyPropertyChanged
    {
        #region Declarations

        public ICommand CallCommand { get; set; }
        public ICommand CallFav { get; set; }
        public ICommand MainPageCommand { get; set; }
        public ICommand FavPageCommand { get; set; }
        public ICommand CallDetail { get; set; }

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
        private string resultPoster;

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
        public string ResultPoster
        {
            get => resultPoster;
            set
            {
                resultPoster = value;
                RaisePropertyChanged(nameof(ResultPoster));
            }
        }
        private Detail NewDetail;
        public Detail newDetail
        {
            get => NewDetail;
            set
            {
                NewDetail = value;
                RaisePropertyChanged();
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
                    ResultPoster = ResultMovie.Poster;

                }
            );
            //Call Favourites
            CallFav = new RelayCommand(e =>
                {
                    
                    ResultMovie = Call.APICall(SearchTitle);
                    AddFav(ResultMovie.imdbID, ResultMovie.Title);
                    
                }
            );
            MainPageCommand = new RelayCommand(e =>
            {

            });
            FavPageCommand = new RelayCommand(e =>
            {

            });
            CallDetail = new RelayCommand(e =>
            {
                ResultMovie = Call.APICall(SearchTitle);
                AddDetail(ResultMovie.Title, ResultMovie.Year, ResultMovie.Rated, ResultMovie.Runtime, ResultMovie.Genre, 
                ResultMovie.Director, ResultMovie.Actors, ResultMovie.Plot, ResultMovie.Language, ResultMovie.Poster);

                MovieDeatail DeatailWindow = new MovieDeatail();
                DeatailWindow.Show();
            });
        }
        //Call this functino to add Favourite to List
        
        public void AddFav(string imdbID, string title)
        {
            Fav newFav = new Fav()
            {
                ImdbID = imdbID,
                Title = title
            };
            try
            {
                using (var ctx = new FavContext())
                {
                    ctx.Favs.Add(newFav);
                    ctx.SaveChanges();

                    FavList = FavListe.ConvertFromList(ctx.Favs.ToList());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddDetail(string title,int year,string rated,string runtime,string genre,string director,string actors,string plot,string language,string poster)
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
                MovieLanguage = language,
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

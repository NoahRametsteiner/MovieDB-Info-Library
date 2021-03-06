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
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace MovieDB_Info_Library.Model
{
    class Detail : INotifyPropertyChanged
    {
        [Key]
        public string MovieTitle { get; set; }
        public string MovieYear { get; set; }
        public string MovieRated { get; set; }
        public string MovieRuntime { get; set; }
        public string MovieGenre { get; set; }
        public string MovieDirector { get; set; }
        public string MovieActors { get; set; }
        public string MoviePlot { get; set; }
        public string MoviePoster { get; set; }

        public byte[] MovieBanner { get; set; }

        public BitmapImage MovieBild;
        public BitmapImage movieBild
        {
            get => MovieBild;
            set
            {
                MovieBild = value;
                RaisePropertyChanged(nameof(movieBild));
            }
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

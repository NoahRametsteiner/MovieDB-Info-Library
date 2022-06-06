using MovieDB_Info_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MovieDB_Info_Library.ViewModel
{
    class DetailViewModel : INotifyPropertyChanged 
    {
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

            using (WebClient client = new WebClient())
            {
                NewDetail.MovieBanner = client.DownloadData(NewDetail.MoviePoster);
            }

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




    #region PropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }
}

using MovieDB_Info_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB_Info_Library.ViewModel
{
    class DetailViewModel : INotifyPropertyChanged
    {
        private Detail NewDetail;
        public Detail newDetail
        {
            get => NewDetail;
            set
            {
                NewDetail = value;
                RaisePropertyChanged(nameof(newDetail));
            }
        }

        public DetailViewModel(){

            newDetail = MovieViewModel.newDetail;

            using (WebClient client = new WebClient())
            {
                try
                {
                    client.DownloadFileAsync(new Uri(newDetail.MoviePoster), @"..\image\banner.jpg");
                }
                catch { }
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

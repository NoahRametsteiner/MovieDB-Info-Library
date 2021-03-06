using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MovieDB_Info_Library.View;
using System.Windows;

namespace MovieDB_Info_Library.ViewModel
{
    class ParentViewModel : INotifyPropertyChanged
    {
        public ICommand Search { get; set; }
        public ICommand Logout { get; set; }
        public ICommand Exit { get; set; }

        private string userLogedIn;
        private object _currentPage;

        public static int CurrentUserID { get; set; }



        public string UserLogedIn
        {
            get => userLogedIn;
            set
            {
                userLogedIn = value;
                RaisePropertyChanged(nameof(UserLogedIn));
            }
        }
        public object CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                RaisePropertyChanged(nameof(CurrentPage));
            }
        }

        

        public ParentViewModel()
        {
            CurrentPage = new MovieViewModel();
            CurrentUserID = LoginViewModel.UID;

            Logout = new RelayCommand(e =>
            {
                LoginScreen signIn = new LoginScreen();
                Application.Current.Windows[0].Close();
                signIn.ShowDialog();
            });
            Exit = new RelayCommand(e =>
            {

            });
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

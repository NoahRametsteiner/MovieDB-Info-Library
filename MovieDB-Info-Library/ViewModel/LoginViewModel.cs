using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MovieDB_Info_Library.View;

namespace MovieDB_Info_Library.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand Login { get; set; }
        public ICommand Register { get; set; }

        public static int UID { get; set; }
        public string Email { get; set; }
        public string Pw { get; set; }

        public LoginViewModel()
        {
            Login = new RelayCommand(e =>
            {
                int i = 0;
                i = ComparePassword.PasswordCompare(MovieViewModel.DBLogin, Email, Pw);
                if (i != 0)
                {
                    UID = i;
                    MainWindow main = new MainWindow();
                    Application.Current.Windows[0].Close();
                    main.ShowDialog();
                   
                }
            });

            Register = new RelayCommand(e =>
            {
                AddUser.CreateUser(MovieViewModel.DBLogin, Email, Pw);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}

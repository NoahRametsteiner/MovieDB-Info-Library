﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Diagnostics;
using MovieDB_Info_Library.ViewModel;
using System.Security;
using MovieDB_Info_Library.View;

namespace MovieDB_Info_Library.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        public ICommand Login { get; set; }
        public ICommand Register { get; set; }

        public static int UID { get; set; }

        private string DBLogin = @"server=sql3.freesqldatabase.com;userid=sql3496579;password=zQdQ2FdWqU;database=sql3496579";
        public string Email { get; set; }
        public string Pw { get; set; }

        public LoginViewModel()
        {
            Login = new RelayCommand(e =>
            {
                int i = 0;
                i = ComparePassword.PasswordCompare(DBLogin, Email, Pw);
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
                AddUser.CreateUser(DBLogin, Email, Pw);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
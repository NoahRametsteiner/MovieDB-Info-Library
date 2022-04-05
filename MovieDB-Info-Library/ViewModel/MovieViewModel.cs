using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MovieDB_Info_Library.ViewModel;
using MovieDB_Info_Library.API;
using MovieDB_Info_Library.Model;
using Rechnungsverwaltung.ViewModel;

namespace MovieDB_Info_Library.ViewModel
{
    class MovieViewModel
    {
        #region Declarations

        public ICommand CallCommand { get; set; }

        string SearchTitle { get; set; }
        Movie Result { get; set; }

        #endregion

        public MovieViewModel()
        {

            CallCommand = new RelayCommand(e =>
                {
                    Result = Call.APIcall(SearchTitle);

                }

            );
        }
    }

}

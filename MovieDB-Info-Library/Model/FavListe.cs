using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB_Info_Library.Model;

namespace MovieDB_Info_Library.Model
{
    class FavListe
    {
        public ObservableCollection<Fav> FavList { get; set; } = new ObservableCollection<Fav>();
        public static FavListe ConvertFromList(List<Fav> list)
        {
            return new FavListe
            {
                FavList = new ObservableCollection<Fav>(list)
            };
        }


    }
}

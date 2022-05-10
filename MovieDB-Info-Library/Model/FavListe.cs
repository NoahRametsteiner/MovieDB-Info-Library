using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB_Info_Library.Model;

namespace MovieDB_Info_Library.Model
{
    class FavListe
    {
        public List<Fav> favList;

        public FavListe()
        {
            favList = new List<Fav>();
        }

        public void AddFav(string imDB, string Title)
        {
            Fav newFav = new Fav();
            newFav.ImdbID = imDB;
            newFav.Title = Title;
            int i = 0;
            for (i = 0; i <= favList.Count; i++)
            {
                if (i == favList.Count)
                {
                    favList.Add(newFav);
                    break;
                }
                if (favList[i].ImdbID == newFav.ImdbID)
                {
                    Console.WriteLine("Removed: " + favList[i]);
                    favList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}

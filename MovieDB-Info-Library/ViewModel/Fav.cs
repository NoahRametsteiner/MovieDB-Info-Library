using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB_Info_Library.Model;
using MovieDB_Info_Library.ViewModel;

namespace MovieDB_Info_Library.ViewModel
{
    class Fav
    {
        public string Title { get; set; }

        public string ImdbID { get; set; }

        static List<string> favList = new List<string>();

        public static void addFav(string title, string imdbID)
        {
            int i=0;
            for (i = 0; i <= favList.Count; i++)
            {
                if (i == favList.Count)
                {
                    favList.Add(imdbID);
                    break;
                }
                if (favList[i] == imdbID)
                {
                    Console.WriteLine("Removed: " + favList[i]);
                    favList.RemoveAt(i);
                    break;
                }
            }
           

            for (int a = 0; a < favList.Count; a++)
            {
                Console.WriteLine(favList[a]);
            }
        }

    }
}

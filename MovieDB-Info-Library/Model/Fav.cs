using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieDB_Info_Library.Model;
using MovieDB_Info_Library.ViewModel;

namespace MovieDB_Info_Library.Model
{
    class Fav
    {
        [Key]
        public string ImdbID { get; set; }
        public string Title { get; set; }

        

        

       

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB_Info_Library.Model
{
    class FavContext : DbContext
    {
        public FavContext()
        {
            Database.SetInitializer<FavContext>(new FavInitializer());

        }
        public DbSet<Fav> Favs { get; set; }
    }
}

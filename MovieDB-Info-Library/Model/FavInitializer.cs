using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace MovieDB_Info_Library.Model
{
    class FavInitializer : CreateDatabaseIfNotExists<FavContext>
    {
    }
}

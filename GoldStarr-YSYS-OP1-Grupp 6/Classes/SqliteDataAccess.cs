using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.Sqlite;

namespace GoldStarr_YSYS_OP1_Grupp_6.Classes
{
    class SqliteDataAccess
    {
        static string cs = "Data Source=:memory:";

        SqliteConnection con = new SqliteConnection(cs);

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ttxy.DAL
{   
    public class MyDataContext
    {
        //public const string db_resourse = "Data Source=192.168.0.2;Initial Catalog=yxg_landata;Persist Security Info=True;User ID=sa;Password=Fire!!(";
        //public const string db_monitor = "Data Source=192.168.0.2;Initial Catalog=yxg_firecon;Persist Security Info=True;User ID=sa;Password=Fire!!(";
        public const string db_resourse = "Data Source=localhost;Initial Catalog=yxg_landata;Persist Security Info=True;User ID=sa;Password=20202425";
        public const string db_monitor = "Data Source=localhost;Initial Catalog=yxg_firecon;Persist Security Info=True;User ID=sa;Password=20202425";

        public static LinqDataContext GetConnection ()
        {
            return new LinqDataContext(db_resourse);//视图部分
        }
    }
}
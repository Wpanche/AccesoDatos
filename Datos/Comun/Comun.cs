using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Datos
{
    public class Comun
    {
        protected IDbConnection Connection
        {
            get
            {
                return new SqlConnection("User Id=dev;Password=Agosto2018.;Server=192.168.0.6;Database=Desarrollo;");
            }
        }

        
        //Remainder of file is unchanged
    }
}

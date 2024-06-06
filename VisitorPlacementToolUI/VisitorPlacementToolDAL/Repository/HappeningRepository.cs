using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPlacementToolDAL.Repository
{
    public class HappeningRepository
    {
        private readonly SqlConnection _conn = new DbConn().ConnString;

        public HappeningRepository() 
        {

        }
    }
}

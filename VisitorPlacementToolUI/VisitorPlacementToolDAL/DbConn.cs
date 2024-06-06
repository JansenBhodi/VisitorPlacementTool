using System.Data.SqlClient;

namespace VisitorPlacementToolDAL
{
    public class DbConn
    {
        public SqlConnection ConnString = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb; Initial Catalog=VisitorPlacement; Integrated Security=True");
    }
}

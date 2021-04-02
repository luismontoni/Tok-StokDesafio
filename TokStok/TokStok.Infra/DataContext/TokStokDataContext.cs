using System.Data;
using System.Data.SqlClient;
using TokStok.Shared;

namespace TokStok.Infra.DataContext
{
    public class TokStokDataContext
    {
        public SqlConnection Connection { get; set; }

        public TokStokDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}

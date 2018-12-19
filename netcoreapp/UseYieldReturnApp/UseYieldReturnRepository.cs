using SharedData;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UseYieldReturnApp
{
    public sealed class UseYieldReturnRepository : DataAccessProvider
    {
        public override IEnumerable<SalesOrderDetailColumnStore> GetItems()
        {
            using (SqlConnection _conn = new SqlConnection())
            {
                _conn.ConnectionString = ConnectionString;

                SqlCommand _cmd;

                _cmd = new SqlCommand();
                _cmd.Connection = _conn;
                _cmd.CommandText = this.SelectCommand;

                _conn.Open();
                var _reader = _cmd.ExecuteReader();
                while (_reader.Read())
                {
                    yield return this.MapToClass(_reader);
                }
                _conn.Close();
            }
        }
    }
}

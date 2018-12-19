using SharedData;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UseListReturnApp
{
    public sealed class UseListReturnRepository : DataAccessProvider
    {
        public override IEnumerable<SalesOrderDetailColumnStore> GetItems()
        {
            List<SalesOrderDetailColumnStore> _items;

            _items = new List<SalesOrderDetailColumnStore>();

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
                    var _item = this.MapToClass(_reader);
                    _items.Add(_item);
                }
                _conn.Close();

                return _items.ToArray();
            }
        }
    }

}

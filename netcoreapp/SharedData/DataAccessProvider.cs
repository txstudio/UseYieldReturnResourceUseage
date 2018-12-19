using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SharedData
{
    public abstract class DataAccessProvider
    {
        protected const string ConnectionString = @"Server=192.168.0.90;Database=YieldReturnDb;User Id=sa;Password=Pa$$w0rd;";


        public abstract IEnumerable<SalesOrderDetailColumnStore> GetItems();


        protected string SelectCommand
        {
            get
            {
                return @"SELECT [SalesOrderID]
    ,[SalesOrderDetailID]
    ,[CarrierTrackingNumber]
    ,[OrderQty]
    ,[ProductID]
    ,[SpecialOfferID]
    ,[UnitPrice]
    ,[UnitPriceDiscount]
    ,[LineTotal]
    ,[rowguid]
    ,[ModifiedDate]
FROM [dbo].[SalesOrderDetailFromAdventureWorks2017]";
            }
        }

        protected SalesOrderDetailColumnStore MapToClass(IDataReader reader)
        {
            SalesOrderDetailColumnStore _item;

            _item = new SalesOrderDetailColumnStore();
            _item.SalesOrderID = reader.GetInt32(0);
            _item.SalesOrderDetailID = reader.GetInt32(1);
            _item.CarrierTrackingNumber = reader.IsDBNull(2) == true ? string.Empty : reader.GetString(2);
            _item.OrderQty = reader.GetInt16(3);
            _item.ProductID = reader.GetInt32(4);
            _item.SpecialOfferID = reader.GetInt32(5);
            _item.UnitPrice = reader.GetDecimal(6);
            _item.UnitPriceDiscount = reader.GetDecimal(7);
            _item.LineTotal = reader.GetDecimal(8);
            _item.rowguid = reader.GetGuid(9);
            _item.ModifiedDate = reader.GetDateTime(10);

            return _item;
        }

    }
}

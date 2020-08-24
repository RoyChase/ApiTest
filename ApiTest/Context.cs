using System.Data;
using System.Xml.Serialization;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SQLite;
using LinqToDB.Mapping;

namespace ApiTest
{
    public class Context : DataConnection
    {
        public Context(IDbConnection connection)
        : base(new SQLiteDataProvider(ProviderName.SQLiteMS), connection)
        {
        }
    }
}
using LinqToDB.Data;

namespace Orm.Task.LinqToDb
{
    public class LinqToDbDataContext : DataConnection
    {
        public LinqToDbDataContext(string providerName, string connectionString)
            : base(providerName, connectionString)
        { }
    }
}

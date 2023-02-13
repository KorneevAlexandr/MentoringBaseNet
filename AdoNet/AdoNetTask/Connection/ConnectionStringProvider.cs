namespace AdoNetTask.Connection
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public ConnectionStringProvider(string connectionString) 
        {
            ConnectionString= connectionString;
        }

        public string ConnectionString { get; }
    }
}

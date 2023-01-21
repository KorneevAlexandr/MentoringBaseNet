using Microsoft.Data.SqlClient;
using System.Text;

namespace AdoNetTask.QueryBuilders
{
    internal class QueryConditionBuilder
    {
        private StringBuilder _queryBuilder;
        private SqlCommand _command;
        private bool _hasCondition;

        public QueryConditionBuilder(string baseQuery) 
        {
            _queryBuilder = new StringBuilder(baseQuery);
            _command = new SqlCommand();
            _hasCondition = false;
        }

        public QueryConditionBuilder AddCondition(string paramName, object value)
        {
            if (value != null)
            {
                var condition = _hasCondition ? " AND " : " WHERE ";
                _hasCondition = true;

                _queryBuilder.AppendLine($"{condition}{paramName.ToUpperInvariant()} = @{paramName}");
                _command.Parameters.AddWithValue(paramName, value);
            }

            return this;
        }

        public QueryConditionBuilder AddSpecificCondition(string condition, string paramName, object value)
        {
            if (value != null)
            {
                var preCondition = _hasCondition ? " AND " : " WHERE ";
                _hasCondition = true;

                _queryBuilder.AppendLine($"{preCondition}{condition} = @{paramName}");
                _command.Parameters.AddWithValue(paramName, value);
            }

            return this;
        }

        public SqlCommand Build()
        {
            _command.CommandText = _queryBuilder.ToString();

            return _command;
        }
    }
}

using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sentry;
using Sentry.Extensibility;

namespace Demo.Api
{
    internal class SqlExceptionProcessor :  SentryEventExceptionProcessor<SqlException>
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SqlExceptionProcessor> _logger;

        public SqlExceptionProcessor(
            IConfiguration configuration,
            ILogger<SqlExceptionProcessor> logger
        )
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected override void ProcessException(SqlException exception, SentryEvent sentryEvent)
        {
            using (_logger.BeginScope(new
            {
                ExceptionCode = exception.Number
            }))
            {
                if (exception.Number == 18456)
                {
                    var connString = _configuration.GetConnectionString("MoviesDB");
                    var builder = new SqlConnectionStringBuilder(connString);
                    sentryEvent.Contexts["sql_exception"] = 
                    new
                    {
                        Login = builder["secret"].ToString().Substring(0, 4),
                        Secret = builder["login"]
                    };
                }
            }
        }
    }
}
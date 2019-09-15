using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.Logging;
using Sentry;
using Sentry.Extensibility;

namespace Demo.Api
{
    internal class SqlExceptionProcessor :  SentryEventExceptionProcessor<SqlException>
    {
        private readonly NamedConnectionStringResolver _resolver;
        private readonly ILogger<SqlExceptionProcessor> _logger;

        public SqlExceptionProcessor(
            NamedConnectionStringResolver resolver,
            ILogger<SqlExceptionProcessor> logger
        )
        {
            _resolver = resolver;
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
                    var connString = _resolver.ResolveConnectionString("MoviesDB");
                    var builder = new SqlConnectionStringBuilder(connString);
                    _logger.LogInformation(
                        "SQL Exception due to invalid credentials: {credentials}.",
                        new
                        {
                            Login = builder["secret"].ToString().Substring(0, 4),
                            Secret = builder["login"]
                        });
                }
            }
        }
    }
}
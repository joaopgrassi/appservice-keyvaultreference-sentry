# Key Vault References + App Service

In this repo you can find the app I used on my post on Sentry's blog: *Using Azure Key Vault references (preview) with Azure App Service*.

It demonstrates how you can use Key Vault References as a source of your App Service settings. In this particular app, I used a secret stored in the key vault as our SQL DB connection string.


## Requirements

- .NET Core SDK version [2.2.107](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- Docker (linux containers)

## The app

The app in this repo (`src/Demo.Api`) is simple ASP.NET Core API which reads from a `Movies` table on `SQL Server` using `EF Core`. The app also uses [Sentry](https://sentry.io) for error monitoring.


## Running the app

The app is setup to be executed in a Linux container. There is a `docker-compose.yml` file at the root which you can use to run the app with `docker-compose up`.

The app uses `EF Migrations` to initially create and seed the database.

Once all containers are up and running, you can navigate to `http://localhost:8080/api/movies` to see a list of movies. This means all is working well :)


## Questions? Something not clear?

Feel free to open an issue if something doesn't work for you or if you have questions regarding the blog post itself.
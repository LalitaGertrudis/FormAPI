# FormAPI

Manage form data using C# Web API

## Learning Path

- Follow the guide from [Create a web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code)
- Tutorial [ASP.NET Core Web API .NET 6 2022](https://www.youtube.com/watch?v=_8nLSsK5NDo&list=PL82C6-O4XrHdiS10BLh23x71ve9mQCln0)

## Development

Run `dotnet run --launch-profile https` to launch API locally

## Secrets

How to setup a connection string with `user-secrets`

``` bash
dotnet user-secrets init
dotnet user-secrets set ConnectionStrings:YourDatabaseAlias "Connection String"

# Add this in Program.cs -> 
# builder.Services.AddDbContext<MyDBContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("YourDatabaseAlias")));
```
## Database

[Manage database schemas docs](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

Install the tools
`dotnet tool install --global dotnet-ef`
Create migration
`dotnet ef migrations add InitialCreate`
Update your database
`dotnet ef database update`

using Microsoft.Extensions.Configuration;
using CodingTracker.Golvi1124.Data;

IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

string connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];

var dataAccess = new DataAccess(connectionString);

dataAccess.CreateDatabase();
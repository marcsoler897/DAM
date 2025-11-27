using Microsoft.Extensions.Configuration;
using DAW.Services;
using Microsoft.Data.SqlClient;
using DAW.EndPoints;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

string connectionString = builder.Configuration.GetConnectionString("DAWDBConnection") ?? "";
DAWDBConnection dbConn = new DAWDBConnection(connectionString);

WebApplication DAWApp = builder.Build();


DAWApp.MapGet("/", () =>
{
    try
    {
        bool connState = dbConn.Open();
        return $"Database connection: {connState}";
    }
    catch (SqlException ex)
    {
        return $"Database connection failed: {ex.Message}";
    }
});

DAWApp.MapObjectesPartidaEndpoints(dbConn);

DAWApp.Run();
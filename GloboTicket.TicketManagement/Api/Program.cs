using GloboTicket.TicketManagement.Api;
using Serilog;

Log.Logger = new LoggerConfiguration()
	.WriteTo.Console()
	.CreateBootstrapLogger();

Log.Information("GloboTicket Api is starting up...");


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context ,LoggerConfiguration) => LoggerConfiguration.
WriteTo.Console()
.ReadFrom.Configuration(context.Configuration));

var app = builder.ConfigureServices().ConfigurePipeline();


app.UseSerilogRequestLogging();

app.Run();

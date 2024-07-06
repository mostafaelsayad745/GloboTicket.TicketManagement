using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Persistence;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Identity;
using Microsoft.OpenApi.Models;
using GloboTicket.TicketManagement.Api.Middleware;
using GloboTicket.TicketManagement.Identity.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace GloboTicket.TicketManagement.Api
{
	public static class StartupExtensions 
	{
		public static WebApplication ConfigureServices (this WebApplicationBuilder builder)
		{
			AddSwagger(builder.Services);
			builder.Services.AddApplicationServices();
			builder.Services.AddInfrastructureServices(builder.Configuration);
			builder.Services.AddPersistenceServices(builder.Configuration);
			builder.Services.AddIdentityServices(builder.Configuration);

			builder.Services.AddControllers();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", builder =>
				{
					builder.AllowAnyOrigin();
					builder.AllowAnyMethod();
					builder.AllowAnyHeader();
				});
			});

			builder.Services.AddEndpointsApiExplorer();

			return builder.Build();

		}

		public static WebApplication ConfigurePipeline (this WebApplication app)
		{
			app.MapIdentityApi<ApplicationUser>();

			app.MapPost("/Logout", async (ClaimsPrincipal user , SignInManager<ApplicationUser> signInManager) =>
			{
				await signInManager.SignOutAsync();
				return TypedResults.Ok();
			});


			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();
			app.UseCustomExceptionHandler();

			app.UseCors("AllowAll");

			app.MapControllers();

			return app;
		}

		private static void AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "GloboTicket Ticket Management API", Version = "v1" });
				//c.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request", false);
			});
		}

		
	}
}

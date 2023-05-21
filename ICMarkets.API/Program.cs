using System.Reflection;
using CMarkets.Core.Repositories.Command;
using ICMarkets.Application.Handlers.CommandHandlers;
using ICMarkets.Core.Repositories.Command;
using ICMarkets.Core.Repositories.Command.Base;
using ICMarkets.Core.Repositories.Query;
using ICMarkets.Core.Repositories.Query.Base;
using ICMarkets.Infrastructure;
using ICMarkets.Infrastructure.Repositories.Command;
using ICMarkets.Infrastructure.Repositories.Command.Base;
using ICMarkets.Infrastructure.Repositories.Query;
using ICMarkets.Infrastructure.Repositories.Query.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.

services.AddControllers();

services.AddAutoMapper(typeof(Program));

//Chnage for other db
//services.AddDbContext<ICMarketsContext>(options => options.UseSqlite(System.Configuration.GetConnectionString("DefaultConnection")));


// configure strongly typed settings object

services.AddHttpClient("ICMarkets.Api", c => c.BaseAddress = new Uri("https://api.blockcypher.com/v1/eth/main"));
services.AddHttpClient("ICMarkets.Api", c => c.BaseAddress = new Uri("https://api.blockcypher.com/v1/dash/main"));
services.AddHttpClient("ICMarkets.Api", c => c.BaseAddress = new Uri("https://api.blockcypher.com/v1/btc/main"));
//services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
//services.AddTransient<IBtcQueryRepository, BtcQueryRepository>();
//services.AddTransient<IEthQueryRepository, EthQueryRepository>();
//services.AddTransient<DashQueryRepository, DashQueryRepository>();
//services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
//services.AddTransient<IBtcCommandRepository, CommandBtcRepository>();
//services.AddTransient<IDashCommandRepository, CommandDashRepository>();
//services.AddTransient<IEthCommandRepository, CommandEthRepository>();


services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ICMarkets.API", Version = "v1" });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


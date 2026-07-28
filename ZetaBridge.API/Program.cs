using Microsoft.EntityFrameworkCore;
using ZetaBridge.API.Data;
using ZetaBridge.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ZetaBridge.Core.TwitchOptions>(builder.Configuration.GetSection("Twitch"));
builder.Services.AddSingleton<TwitchHelixDriver>();
builder.Services.AddSingleton<TwitchConnections>();

builder.Services.AddDbContext<ZetaBridgeContext>(options =>
    options.UseSqlite("Data Source=db/zetabridge.db"));

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

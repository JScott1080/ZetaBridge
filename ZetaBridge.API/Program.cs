using Microsoft.EntityFrameworkCore;
using ZetaBridge.API.Data;
using ZetaBridge.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(sp =>
    new TwitchConnections(
        username: "your_bot_username",
        accessToken: "your_access_token",
        channel: "your_channel_name"
    ));

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

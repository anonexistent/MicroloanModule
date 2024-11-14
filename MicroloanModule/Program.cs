using DatabaseCore;
using MicroloanModule.Controllers;
using MicroloanModule.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<MicroloanDbContext>(o => 
        o.UseSqlite("Data Source=microloan.db"))
    .AddScoped<GiveMeMoneyMonthService>()
    .AddScoped<MicroloanService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<MicroloanDbContext>();
    dbContext?.Database.Migrate();
}

app.Run();

using ServerApp.Repository;
using Microsoft.Extensions.Options;
using ServerApp.Repository;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddSingleton<IAnnonceRepository, AnnonceMongoDB>();
builder.Services.AddSingleton<IBrugerRepository, BrugerMongoDB>();
builder.Services.AddSingleton<ILokaleRepository, LokaleMongoDB>();
builder.Services.AddOpenApi();


builder.Services.AddCors(options =>
{
    options.AddPolicy("policy", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
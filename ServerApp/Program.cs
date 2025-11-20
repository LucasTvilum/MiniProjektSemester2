using ServerApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IAnnonceRepository, AnnonceMongoDB>();
builder.Services.AddSingleton<IBrugerRepository, BrugerMongoDB>();
builder.Services.AddSingleton<ILokaleRepository, LokaleMongoDB>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor",
        policy => policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowBlazor");

app.UseAuthorization();

app.MapControllers();

app.MapPost("/api/purchases", (PurchaseRequest req) =>
{
    return Results.Ok(new PurchaseCreated(Guid.NewGuid().ToString("N")));
});

app.MapPost("/api/purchases/cancel", (CancelRequest req) =>
{
    return Results.Ok();
});

app.Run();

public sealed record PurchaseRequest(string ProductId, int Quantity);
public sealed record CancelRequest(string RequestId);
public sealed record PurchaseCreated(string RequestId);
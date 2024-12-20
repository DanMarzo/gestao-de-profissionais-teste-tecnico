var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfraServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddExceptionHandler<ExceptionGlobalHandler>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", buider => buider
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.AutoMigrate();
var contentFile = File.ReadAllText("./default_entities_especialidades.json");
await app.ApplyDefaultEntities(contentFile);
app.UseAuthorization();

app.MapGet("/", async () =>
{
    try
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<ApplicationDataContext>();
        var especialidades = await context.Set<EspecialidadeEntity>().ToListAsync();
        return Results.Ok(new { status = especialidades.Any(), message = !especialidades.Any() ? "Nenhuma especialidade localizada" : "" });
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { status = false, message = ex.Message });
    }
});
app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();

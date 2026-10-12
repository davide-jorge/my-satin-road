using Infra;

var builder = WebApplication.CreateBuilder(args);

// ---------- Services (everything before Build()) ----------
builder.Services.AddControllers();
builder.Services.AddOpenApi();   // generates the document at /openapi/v1.json
builder.Services.AddInfra(builder.Configuration.GetConnectionString("Default")!);

var app = builder.Build();

// ---------- Startup work and middleware (everything after Build()) ----------
if (app.Environment.IsDevelopment())
{
    // Direct (non-pooled) connection: migrations should not go through the pooler.
    DbMigrator.Run(builder.Configuration.GetConnectionString("Direct")!);

    app.MapOpenApi();
    app.UseSwaggerUI(options =>
        options.SwaggerEndpoint("/openapi/v1.json", "Satin Road v1"));
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

public partial class Program;   // lets integration tests reference Program later
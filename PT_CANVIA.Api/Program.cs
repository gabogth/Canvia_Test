using PT_CANVIA.Core.Entidades;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
List<AppsRegistradas> lsAppsRegistradas = new List<AppsRegistradas>();
lsAppsRegistradas.Add(new AppsRegistradas { cPolitica = "TEST_CANVIA", cHttpOrigin = "http://localhost:44351", cHttpsOrigin = "https://localhost:4200" });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

foreach (AppsRegistradas oApp in lsAppsRegistradas)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: oApp.cPolitica,
            builder =>
            {
                builder.WithOrigins(oApp.cHttpOrigin, oApp.cHttpsOrigin)
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
            });
    });
}

Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc
    .ReadFrom.Configuration(ctx.Configuration))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
foreach (AppsRegistradas oApp in lsAppsRegistradas)
    app.UseCors(oApp.cPolitica);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.Run();

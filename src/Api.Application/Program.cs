using Api.CrossCutting.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // Para o método UseMySql ou UseSqlServer
                                // Para encontrar a sua classe MyContext

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers(); // Adiciona suporte a controllers MVC e Web
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Curso de API com AspNetCore 9.0 - Na Prática",
        Description = "Arquitetura DDD",
        TermsOfService = new Uri("https://www.github.com/viniciustmota"),
        Contact = new OpenApiContact
        {
            Name = "Vinícius Tavares Mota",
            Email = "motaviny140@gmail.com",
            Url = new Uri("https://www.github.com/viniciustmota")
        },
        License = new OpenApiLicense
        {
            Name = "Termo de Licença de Uso",
            Url = new Uri("https://www.github.com/viniciustmota")
        }
    });
});
ConfigureService.ConfigureDependenciesService(builder.Services);
ConfigureRepository.ConfigureDependenciesRepository(builder.Services, connectionString);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API com AspNetCore 9.0");
    c.RoutePrefix = string.Empty;
});
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

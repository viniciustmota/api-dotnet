using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsEnvironment("Testing"))
{
    Environment.SetEnvironmentVariable("MYSQL_CONNECTION", "Persist Security Info=True;Server=172.23.0.1;Port=3306;Database=dbAPI_Integration;Uid=viniciustmota;Pwd=1234;");
    Environment.SetEnvironmentVariable("SQLSERVER_CONNECTION", "Persist Security Info=True;Server=.\\SQLEXPRESS2022;Initial Catalog=dbapi_integration;MultipleActiveResultSets=true;User ID=sa;Password=DevSysth2025@;TrustServerCertificate=True;");
    Environment.SetEnvironmentVariable("DATABASE", "MYSQL");
    Environment.SetEnvironmentVariable("Audience", "ExemploAudience");
    Environment.SetEnvironmentVariable("Issuer", "ExemploIssuer");
    Environment.SetEnvironmentVariable("Seconds", "28800");
    Environment.SetEnvironmentVariable("MIGRATION", "APLICAR");
}

string? selectedDatabase = Environment.GetEnvironmentVariable("DATABASE"); 
string? finalConnectionString = "";

Action<DbContextOptionsBuilder> dbContextOptionsAction = null; 

if (string.IsNullOrEmpty(selectedDatabase))
{
    throw new InvalidOperationException("A flag 'DATABASE' não foi configurada na seção env do launch.json. Deve ser 'MYSQL' ou 'SQLSERVER'.");
}

switch (selectedDatabase.ToLower())
{
    case "mysql":
        finalConnectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION");
        if (string.IsNullOrEmpty(finalConnectionString))
        {
            throw new InvalidOperationException("A string de conexão 'MYSQL_CONNECTION' não foi encontrada no env do launch.json.");
        }
        dbContextOptionsAction = options => options.UseMySql(finalConnectionString, ServerVersion.AutoDetect(finalConnectionString));
        break;
    case "sqlserver":
        finalConnectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION");
        if (string.IsNullOrEmpty(finalConnectionString))
        {
            throw new InvalidOperationException("A string de conexão 'SQLSERVER_CONNECTION' não foi encontrada no env do launch.json.");
        }
        dbContextOptionsAction = options => options.UseSqlServer(finalConnectionString);
        break;
    default:
        throw new InvalidOperationException($"Banco de dados '{selectedDatabase}' não suportado. Use 'MYSQL' ou 'SQLSERVER'.");
}

if (string.IsNullOrEmpty(finalConnectionString))
{
    throw new InvalidOperationException("A string de conexão final está vazia após a seleção do banco de dados.");
}

builder.Services.AddDbContext<MyContext>(dbContextOptionsAction);


var signingConfigurations = new SigningConfigurations();
builder.Services.AddSingleton(signingConfigurations);

builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(bearerOptions =>
{
    var serviceProvider = builder.Services.BuildServiceProvider();

    var paramsValidation = bearerOptions.TokenValidationParameters;
    paramsValidation.IssuerSigningKey = signingConfigurations.Key;
    paramsValidation.ValidAudience = Environment.GetEnvironmentVariable("Audience");
    paramsValidation.ValidIssuer = Environment.GetEnvironmentVariable("Issuer");
    paramsValidation.ValidateIssuerSigningKey = true;
    paramsValidation.ValidateLifetime = true;
    paramsValidation.ClockSkew = TimeSpan.Zero;
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

builder.Services.AddControllers();
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

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Entre com o Token JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            }, new List<string>()
        }
    });
});

ConfigureService.ConfigureDependenciesService(builder.Services);

ConfigureRepository.ConfigureDependenciesRepository(builder.Services, finalConnectionString);

// AutoMapper
var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new DtoToModelProfile());
    cfg.AddProfile(new EntityToDtoProfile());
    cfg.AddProfile(new ModelToEntityProfile());
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (Environment.GetEnvironmentVariable("MIGRATION").ToLower() == "APLICAR".ToLower())
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Tentando aplicar migrações do banco de dados...");

    using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetService<MyContext>();
        if (context != null)
        {
            logger.LogInformation("MyContext resolvido. Aplicando migrações...");
            context.Database.Migrate();
            logger.LogInformation("Migrações aplicadas com sucesso!");
            
            // Exemplo de seeding de usuário ADMINISTRADOR fixo após migrações, se a tabela estiver vazia
            if (!context.Users.Any())
            {
                logger.LogInformation("Semeando usuário administrador...");
                context.Users.Add(new Api.Domain.Entities.UserEntity
                {
                    Id = new Guid("c3f0b2a1-e4d5-4f67-890a-1234567890ab"), // Use um GUID estático
                    Name = "Administrador",
                    Email = "mfrinfo@mail.com",
                    CreateAt = new DateTime(2025, 6, 13, 10, 0, 0, DateTimeKind.Utc),
                    UpdateAt = new DateTime(2025, 6, 13, 10, 0, 0, DateTimeKind.Utc)
                });
                context.SaveChanges();
                logger.LogInformation("Usuário administrador semeado.");
            }
        }
        else
        {
            logger.LogError("ERRO: MyContext não pôde ser resolvido para a migração.");
        }
    }
}
else
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Flag 'ApplyMigrations' é FALSE. Migrações automáticas desabilitadas.");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
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

public partial class Program { }
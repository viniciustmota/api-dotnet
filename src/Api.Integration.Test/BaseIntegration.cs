using System.Net.Http.Headers;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Dtos;
using Api.Integration.Test;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Api.Service.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }
        public HttpClient client { get; private set; }
        public IMapper mapper { get; private set; }
        public string hostApi { get; set; }

        public HttpResponseMessage response { get; set; }

        private readonly WebApplicationFactory<Program> _factory;

        public BaseIntegration()
        {
            hostApi = "http://localhost:5093/api/";
            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.UseEnvironment("Testing");

                    builder.ConfigureServices(services =>
                    {
                        // Exemplo para usar banco em memória no teste:
                        // var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<MyContext>));
                        // if (descriptor != null) services.Remove(descriptor);
                        // services.AddDbContext<MyContext>(options => options.UseInMemoryDatabase("TestDb"));
                    });
                });

            client = _factory.CreateClient();

            var scope = _factory.Services.CreateScope();
            myContext = scope.ServiceProvider.GetRequiredService<MyContext>();
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();
        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto()
            {
                Email = "vinicius@mail.com"
            };

            var responseLogin = await PostJsonAsync(loginDto, $"{hostApi}login", client);
            responseLogin.EnsureSuccessStatusCode();

            var jsonLogin = await responseLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", loginObject.accessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object data, string url, HttpClient client)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            return await client.PostAsync(url, content);
        }

        public void Dispose()
        {
            myContext?.Dispose();
            client?.Dispose();
            _factory?.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            // config.AssertConfigurationIsValid(); // opcional

            return config.CreateMapper();
        }

        public void Dispose() { }
    }
}

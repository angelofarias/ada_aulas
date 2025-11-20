using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Repositories;

namespace TodoApp
{
    internal class Program // 1:35:56
    {
        static void Main(string[] args)
        {
            // Criar um Builder de uma Web Application (Web Application é complexa -> Então usados o padrão
            //  Builder)
            var builder = WebApplication.CreateBuilder();

            // Configurar serviços (Injeção de Dependência)
            builder.Services.AddControllers();
            builder.Services.AddScoped<ITodoRepository, TodoRepository>();

            // Constroi a aplicação (builder.Build())
            var app = builder.Build();

            app.MapControllers();

            // teste local
            app.Run();
        }
    }
}
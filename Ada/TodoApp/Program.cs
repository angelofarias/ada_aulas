using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar um Builder de uma Web Application (Web Application é complexa -> Então usados o padrão
            //  Builder)
            var builder = WebApplication.CreateBuilder();

            // Configurar serviços (Injeção de Dependência)
            builder.Services.AddControllers();

            // Constroi a aplicação (builder.Build())
            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }
    }
}
using MediatR;
using Camada.InfraStructure.Repository.interfaces.Usuarios;
using Camada.InfraStructure.Repository.implementations.Usuarios;
using Camada.structure.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CamadaAPI.Utils
{
    public static class Di
    {
        public static void DoInjections(this IServiceCollection services)
        {
            //  Winke recomendou separar as Dis base das Dis padrão
            //BASE? injeções de dependência base
            services.AddMediatR(AppDomain.CurrentDomain.Load("CamadaAPI"));
            services.AddScoped<IDatabaseConnection, DatabaseConnection>();

            //toda interface implementação precisa ser apontada na di
            // repositorios
            services.AddScoped<IUsersRepository, UsersRepository>();
        }

    }
}

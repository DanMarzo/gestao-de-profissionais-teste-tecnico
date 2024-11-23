﻿using Gestao.Profissionais.API.Application.Contracts;
using Gestao.Profissionais.API.Infra.Database;

namespace Gestao.Profissionais.API.Application;

public static class ApplicationServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();
        return services;
    }
}

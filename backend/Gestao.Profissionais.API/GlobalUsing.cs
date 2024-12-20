﻿global using MediatR;
global using Gestao.Profissionais.Application;
global using Gestao.Profissionais.Application.Middleware;
global using Gestao.Profissionais.Domain.Entities;
global using Gestao.Profissionais.Infra;
global using Gestao.Profissionais.Infra.Database;
global using Microsoft.EntityFrameworkCore;
global using Gestao.Profissionais.Application.DTOs.ProfissionalDTOs;
global using Gestao.Profissionais.Application.Features.ProfissionalFeatures.AtualizarProfissional;
global using Gestao.Profissionais.Application.Features.ProfissionalFeatures.ExcluirProfissional;
global using Gestao.Profissionais.Application.Features.ProfissionalFeatures.ListarProfissionais;
global using Gestao.Profissionais.Application.Features.ProfissionalFeatures.ProfissionalPorId;
global using Gestao.Profissionais.Application.Features.ProfissionalFeatures.RegistrarProfissional;
global using Microsoft.AspNetCore.Mvc;
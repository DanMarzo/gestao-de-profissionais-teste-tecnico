﻿using Gestao.Profissionais.API.Application.DTOs.EspecialidadeDTOs;
using MediatR;

namespace Gestao.Profissionais.API.Application.Features.EspecialidadeFeatures.ObterEspecialidades;

public class ObterEspecialidadesRequest : IRequest<IEnumerable<EspecialidadeDTO>>
{

}
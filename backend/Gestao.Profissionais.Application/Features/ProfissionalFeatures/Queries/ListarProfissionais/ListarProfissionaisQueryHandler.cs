﻿namespace Gestao.Profissionais.Application.Features.ProfissionalFeatures.Queries.ListarProfissionais;

public class ListarProfissionaisQueryHandler : IRequestHandler<ListarProfissionaisQueryRequest, ResponseListModel<ProfissionalDetalhesDTO>>
{
    private readonly IRepository repository;
    private readonly IMapper mapper;
    private readonly ILogger<ListarProfissionaisQueryHandler> logger;
    public ListarProfissionaisQueryHandler(IRepository repository, IMapper mapper, ILogger<ListarProfissionaisQueryHandler> logger)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.logger = logger;
    }

    public async Task<ResponseListModel<ProfissionalDetalhesDTO>> Handle(ListarProfissionaisQueryRequest request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Request {JsonSerializer.Serialize(request)}");
        //Efetuar validacoes
        request.ExecutarValidacoes<ValidateException>();

        var totalItens = 0;

        Expression<Func<ProfissionalEntity, bool>>? where = null;

        if (request.EspecialidadeId is not null)
        {
            where = x => x.EspecialidadeId == request.EspecialidadeId;
            var especialidadeExiste = await repository.EntityExists<EspecialidadeEntity>(x => x.Id == request.EspecialidadeId);

            if (!especialidadeExiste)
                throw new ValidateException($"Especialidade Id {request.EspecialidadeId} não localizada.", HttpStatusCode.NotFound);

            totalItens = await repository.CountAsync(where);
        }
        else
            totalItens = await repository.CountAsync<ProfissionalEntity>();

        var result = new ResponseListModel<ProfissionalDetalhesDTO>(request, totalItens);
        if (totalItens == 0)
            return result;

        var profissionais = await repository
            .ListEntities(request, includes: [inc => inc.Especialidade], where: where);

        var profissionaisDTO = mapper.Map<IEnumerable<ProfissionalDetalhesDTO>>(profissionais);

        result.IncluirItens(profissionaisDTO);
        logger.LogInformation($"Response {JsonSerializer.Serialize(result)}");
        return result;
    }
}

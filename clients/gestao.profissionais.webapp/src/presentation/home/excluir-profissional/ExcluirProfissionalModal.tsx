//import { nomeTipoDocEspecialidadeEnum } from "../../../models/especialidade.model";
import { nomeTipoDocEspecialidadeEnum } from "../../../models/especialidade.model";
import { useExcluirProssionalViewModel } from "./ExcluirProssionalModal.view-model";

const ExcluirProfissionalModal = () => {
  //Carregar especialidades ao iniciar
  const { handleModal, modalExcluirRef, profissionalParaExcluir } =
    useExcluirProssionalViewModel();

  return (
    <>
      <div
        ref={modalExcluirRef}
        className="modal fade"
        id={`atualizarProfissionalModal`}
        tabIndex={-1}
        aria-labelledby={`atualizarProfissionalModalLabel`}
        aria-hidden="true"
      >
        <div className="modal-dialog modal-dialog-centered">
          <div className="modal-content needs-validation">
            <div className="modal-header">
              <h1
                className="modal-title fs-5"
                id={`atualizarProfissionalModalLabel`}
              >
                Excluir Profissional
              </h1>
              <button
                type="button"
                className="btn-close"
                data-bs-dismiss="modal"
                aria-label="Close"
              ></button>
            </div>
            <div className="modal-body">
              {profissionalParaExcluir && (
                <>
                  Tem certeza que deseja excluir o profissional{" "}
                  {profissionalParaExcluir!.nome} (
                  {`${nomeTipoDocEspecialidadeEnum(
                    profissionalParaExcluir!.especialidade.tipoDocumento
                  )} ${profissionalParaExcluir!.numeroDocumento}`}
                  )? Essa ação não poderá ser desfeita!
                </>
              )}
            </div>
            <div className="modal-footer">
              <button
                type="reset"
                className="btn text-white bg-tertiary"
                onClick={() => handleModal(true)}
              >
                Cancelar
              </button>
              <button className="btn btn-danger">Sim, excluir</button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};

export { ExcluirProfissionalModal };

using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class SexoModel
    {
        public SexoTransfer Incluir(SexoTransfer sexoTransfer)
        {
            SexoDataModel sexoDataModel;
            SexoBusiness sexoBusiness;
            SexoTransfer sexoValidacao;
            SexoTransfer sexoInclusao;

            try {
                sexoBusiness = new SexoBusiness();
                sexoDataModel = new SexoDataModel();

                sexoTransfer.Sexo.Criacao = DateTime.Today;
                sexoTransfer.Sexo.Alteracao = DateTime.Today;

                sexoValidacao = sexoBusiness.Validar(sexoTransfer);

                if (!sexoValidacao.Erro) {
                    if (sexoValidacao.Validacao) {
                        sexoInclusao = sexoDataModel.Incluir(sexoValidacao);
                    } else {
                        sexoInclusao = new SexoTransfer(sexoValidacao);
                    }
                } else {
                    sexoInclusao = new SexoTransfer(sexoValidacao);
                }
            } catch (Exception ex) {
                sexoInclusao = new SexoTransfer();

                sexoInclusao.Validacao = false;
                sexoInclusao.Erro = true;
                sexoInclusao.IncluirMensagem("Erro em SexoModel Incluir [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
                sexoBusiness = null;
                sexoValidacao = null;
            }

            return sexoInclusao;
        }

        public SexoTransfer Alterar(SexoTransfer sexoTransfer)
        {
            SexoDataModel sexoDataModel;
            SexoBusiness sexoBusiness;
            SexoTransfer sexoValidacao;
            SexoTransfer sexoAlteracao;

            try {
                sexoBusiness = new SexoBusiness();
                sexoDataModel = new SexoDataModel();

                sexoTransfer.Sexo.Alteracao = DateTime.Today;

                sexoValidacao = sexoBusiness.Validar(sexoTransfer);

                if (!sexoValidacao.Erro) {
                    if (sexoValidacao.Validacao) {
                        sexoAlteracao = sexoDataModel.Alterar(sexoValidacao);
                    } else {
                        sexoAlteracao = new SexoTransfer(sexoValidacao);
                    }
                } else {
                    sexoAlteracao = new SexoTransfer(sexoValidacao);
                }
            } catch (Exception ex) {
                sexoAlteracao = new SexoTransfer();

                sexoAlteracao.Validacao = false;
                sexoAlteracao.Erro = true;
                sexoAlteracao.IncluirMensagem("Erro em SexoModel Alterar [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
                sexoBusiness = null;
                sexoValidacao = null;
            }

            return sexoAlteracao;
        }

        public SexoTransfer Excluir(int id)
        {
            SexoDataModel sexoDataModel;
            SexoTransfer sexo;

            try {
                sexoDataModel = new SexoDataModel();

                sexo = sexoDataModel.Excluir(id);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoModel Excluir [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
            }

            return sexo;
        }

        public SexoTransfer ConsultarPorId(int id)
        {
            SexoDataModel sexoDataModel;
            SexoTransfer sexo;
            
            try {
                sexoDataModel = new SexoDataModel();

                sexo = sexoDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                sexo = new SexoTransfer();

                sexo.Validacao = false;
                sexo.Erro = true;
                sexo.IncluirMensagem("Erro em SexoModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
            }

            return sexo;
        }

        public SexoTransfer Consultar(SexoTransfer sexoListaTransfer)
        {
            SexoDataModel sexoDataModel;
            SexoBusiness sexoBusiness;
            SexoTransfer sexoValidacao;
            SexoTransfer sexoLista;

            try {
                sexoBusiness = new SexoBusiness();
                sexoDataModel = new SexoDataModel();

                sexoValidacao = sexoBusiness.ValidarConsulta(sexoListaTransfer);

                if (!sexoValidacao.Erro) {
                    if (sexoValidacao.Validacao) {
                        sexoLista = sexoDataModel.Consultar(sexoValidacao);

                        if (sexoLista != null) {
                            if (sexoLista.Paginacao.TotalRegistros > 0) {
                                if (sexoLista.Paginacao.RegistrosPorPagina < 1) {
                                    sexoLista.Paginacao.RegistrosPorPagina = 30;
                                } else if (sexoLista.Paginacao.RegistrosPorPagina > 200) {
                                    sexoLista.Paginacao.RegistrosPorPagina = 30;
                                }
                                sexoLista.Paginacao.PaginaAtual = (sexoListaTransfer.Paginacao.PaginaAtual < 1 ? 1 : sexoListaTransfer.Paginacao.PaginaAtual);
                                sexoLista.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(sexoLista.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(sexoLista.Paginacao.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        sexoLista = new SexoTransfer(sexoValidacao);
                    }
                } else {
                    sexoLista = new SexoTransfer(sexoValidacao);
                }
            } catch (Exception ex) {
                sexoLista = new SexoTransfer();

                sexoLista.Validacao = false;
                sexoLista.Erro = true;
                sexoLista.IncluirMensagem("Erro em SexoModel Consultar [" + ex.Message + "]");
            } finally {
                sexoDataModel = null;
                sexoBusiness = null;
                sexoValidacao = null;
            }

            return sexoLista;
        }
    }
}

using System;
using rcDominiosBusiness;
using rcDominiosDataModels;
using rcDominiosTransfers;

namespace rcDominiosApi.Models
{
    public class ContaBancariaModel
    {
        public ContaBancariaTransfer Incluir(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaBusiness contaBancariaBusiness;
            ContaBancariaTransfer contaBancariaValidacao;
            ContaBancariaTransfer contaBancariaInclusao;

            try {
                contaBancariaBusiness = new ContaBancariaBusiness();
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancariaTransfer.ContaBancaria.Criacao = DateTime.Today;
                contaBancariaTransfer.ContaBancaria.Alteracao = DateTime.Today;

                contaBancariaValidacao = contaBancariaBusiness.Validar(contaBancariaTransfer);

                if (!contaBancariaValidacao.Erro) {
                    if (contaBancariaValidacao.Validacao) {
                        contaBancariaInclusao = contaBancariaDataModel.Incluir(contaBancariaValidacao);
                    } else {
                        contaBancariaInclusao = new ContaBancariaTransfer(contaBancariaValidacao);
                    }
                } else {
                    contaBancariaInclusao = new ContaBancariaTransfer(contaBancariaValidacao);
                }
            } catch (Exception ex) {
                contaBancariaInclusao = new ContaBancariaTransfer();

                contaBancariaInclusao.Validacao = false;
                contaBancariaInclusao.Erro = true;
                contaBancariaInclusao.IncluirMensagem("Erro em ContaBancariaModel Incluir [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
                contaBancariaBusiness = null;
                contaBancariaValidacao = null;
            }

            return contaBancariaInclusao;
        }

        public ContaBancariaTransfer Alterar(ContaBancariaTransfer contaBancariaTransfer)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaBusiness contaBancariaBusiness;
            ContaBancariaTransfer contaBancariaValidacao;
            ContaBancariaTransfer contaBancariaAlteracao;

            try {
                contaBancariaBusiness = new ContaBancariaBusiness();
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancariaTransfer.ContaBancaria.Alteracao = DateTime.Today;

                contaBancariaValidacao = contaBancariaBusiness.Validar(contaBancariaTransfer);

                if (!contaBancariaValidacao.Erro) {
                    if (contaBancariaValidacao.Validacao) {
                        contaBancariaAlteracao = contaBancariaDataModel.Alterar(contaBancariaValidacao);
                    } else {
                        contaBancariaAlteracao = new ContaBancariaTransfer(contaBancariaValidacao);
                    }
                } else {
                    contaBancariaAlteracao = new ContaBancariaTransfer(contaBancariaValidacao);
                }
            } catch (Exception ex) {
                contaBancariaAlteracao = new ContaBancariaTransfer();

                contaBancariaAlteracao.Validacao = false;
                contaBancariaAlteracao.Erro = true;
                contaBancariaAlteracao.IncluirMensagem("Erro em ContaBancariaModel Alterar [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
                contaBancariaBusiness = null;
                contaBancariaValidacao = null;
            }

            return contaBancariaAlteracao;
        }

        public ContaBancariaTransfer Excluir(int id)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaTransfer contaBancaria;

            try {
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancaria = contaBancariaDataModel.Excluir(id);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaModel Excluir [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
            }

            return contaBancaria;
        }

        public ContaBancariaTransfer ConsultarPorId(int id)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaTransfer contaBancaria;
            
            try {
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancaria = contaBancariaDataModel.ConsultarPorId(id);
            } catch (Exception ex) {
                contaBancaria = new ContaBancariaTransfer();

                contaBancaria.Validacao = false;
                contaBancaria.Erro = true;
                contaBancaria.IncluirMensagem("Erro em ContaBancariaModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
            }

            return contaBancaria;
        }

        public ContaBancariaTransfer Consultar(ContaBancariaTransfer contaBancariaListaTransfer)
        {
            ContaBancariaDataModel contaBancariaDataModel;
            ContaBancariaBusiness contaBancariaBusiness;
            ContaBancariaTransfer contaBancariaValidacao;
            ContaBancariaTransfer contaBancariaLista;

            try {
                contaBancariaBusiness = new ContaBancariaBusiness();
                contaBancariaDataModel = new ContaBancariaDataModel();

                contaBancariaValidacao = contaBancariaBusiness.ValidarConsulta(contaBancariaListaTransfer);

                if (!contaBancariaValidacao.Erro) {
                    if (contaBancariaValidacao.Validacao) {
                        contaBancariaLista = contaBancariaDataModel.Consultar(contaBancariaValidacao);

                        if (contaBancariaLista != null) {
                            if (contaBancariaLista.Paginacao.TotalRegistros > 0) {
                                if (contaBancariaLista.Paginacao.RegistrosPorPagina < 1) {
                                    contaBancariaLista.Paginacao.RegistrosPorPagina = 30;
                                } else if (contaBancariaLista.Paginacao.RegistrosPorPagina > 200) {
                                    contaBancariaLista.Paginacao.RegistrosPorPagina = 30;
                                }
                                contaBancariaLista.Paginacao.PaginaAtual = (contaBancariaListaTransfer.Paginacao.PaginaAtual < 1 ? 1 : contaBancariaListaTransfer.Paginacao.PaginaAtual);
                                contaBancariaLista.Paginacao.TotalPaginas = 
                                    Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(contaBancariaLista.Paginacao.TotalRegistros) 
                                    / @Convert.ToDecimal(contaBancariaLista.Paginacao.RegistrosPorPagina)));
                            }
                        }
                    } else {
                        contaBancariaLista = new ContaBancariaTransfer(contaBancariaValidacao);
                    }
                } else {
                    contaBancariaLista = new ContaBancariaTransfer(contaBancariaValidacao);
                }
            } catch (Exception ex) {
                contaBancariaLista = new ContaBancariaTransfer();

                contaBancariaLista.Validacao = false;
                contaBancariaLista.Erro = true;
                contaBancariaLista.IncluirMensagem("Erro em ContaBancariaModel Consultar [" + ex.Message + "]");
            } finally {
                contaBancariaDataModel = null;
                contaBancariaBusiness = null;
                contaBancariaValidacao = null;
            }

            return contaBancariaLista;
        }
    }
}

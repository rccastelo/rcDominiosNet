﻿using System;
using rcDominiosDatas;
using rcDominiosDataTransfers;
using rcDominiosEntities;

namespace rcDominiosDataModels
{
    public class PessoaTipoDataModel : DataModel
    {
        public PessoaTipoDataTransfer Incluir(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            Data<PessoaTipoEntity> pessoaTipoData;
            PessoaTipoDataTransfer PessoaTipoRetorno;

            try {
                pessoaTipoData = new Data<PessoaTipoEntity>(_contexto);
                PessoaTipoRetorno = new PessoaTipoDataTransfer(pessoaTipoDataTransfer);

                pessoaTipoData.Incluir(pessoaTipoDataTransfer.PessoaTipo);

                _contexto.SaveChanges();

                PessoaTipoRetorno.PessoaTipo = new PessoaTipoEntity(pessoaTipoDataTransfer.PessoaTipo);
                PessoaTipoRetorno.Validacao = true;
                PessoaTipoRetorno.Erro = false;
            } catch (Exception ex) {
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                PessoaTipoRetorno.Validacao = false;
                PessoaTipoRetorno.Erro = true;
                PessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoDataModel Incluir [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return PessoaTipoRetorno;
        }

        public PessoaTipoDataTransfer Alterar(PessoaTipoDataTransfer pessoaTipoDataTransfer)
        {
            Data<PessoaTipoEntity> pessoaTipoData;
            PessoaTipoDataTransfer PessoaTipoRetorno;

            try {
                pessoaTipoData = new Data<PessoaTipoEntity>(_contexto);
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                pessoaTipoData.Alterar(pessoaTipoDataTransfer.PessoaTipo);

                _contexto.SaveChanges();

                PessoaTipoRetorno.PessoaTipo = new PessoaTipoEntity(pessoaTipoDataTransfer.PessoaTipo);
                PessoaTipoRetorno.Validacao = true;
                PessoaTipoRetorno.Erro = false;
            } catch (Exception ex) {
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                PessoaTipoRetorno.Validacao = false;
                PessoaTipoRetorno.Erro = true;
                PessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoDataModel Alterar [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return PessoaTipoRetorno;
        }

        public PessoaTipoDataTransfer Excluir(int id)
        {
            Data<PessoaTipoEntity> pessoaTipoData;
            PessoaTipoDataTransfer PessoaTipoRetorno;

            try {
                pessoaTipoData = new Data<PessoaTipoEntity>(_contexto);
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                PessoaTipoRetorno.PessoaTipo = pessoaTipoData.ConsultarPorId(id);
                pessoaTipoData.Excluir(PessoaTipoRetorno.PessoaTipo);

                _contexto.SaveChanges();

                PessoaTipoRetorno.Validacao = true;
                PessoaTipoRetorno.Erro = false;
            } catch (Exception ex) {
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                PessoaTipoRetorno.Validacao = false;
                PessoaTipoRetorno.Erro = true;
                PessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoDataModel Excluir [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return PessoaTipoRetorno;
        }

        public PessoaTipoDataTransfer Listar()
        {
            Data<PessoaTipoEntity> pessoaTipoData;
            PessoaTipoDataTransfer PessoaTipoRetorno;

            try {
                pessoaTipoData = new Data<PessoaTipoEntity>(_contexto);
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                PessoaTipoRetorno.PessoaTipoLista = pessoaTipoData.Listar();
                PessoaTipoRetorno.Validacao = true;
                PessoaTipoRetorno.Erro = false;
            } catch (Exception ex) {
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                PessoaTipoRetorno.Validacao = false;
                PessoaTipoRetorno.Erro = true;
                PessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoDataModel Listar [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return PessoaTipoRetorno;
        }

        public PessoaTipoDataTransfer ConsultarPorId(int id)
        {
            Data<PessoaTipoEntity> pessoaTipoData;
            PessoaTipoDataTransfer PessoaTipoRetorno;

            try {
                pessoaTipoData = new Data<PessoaTipoEntity>(_contexto);
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                PessoaTipoRetorno.PessoaTipo = pessoaTipoData.ConsultarPorId(id);
                PessoaTipoRetorno.Validacao = true;
                PessoaTipoRetorno.Erro = false;
            } catch (Exception ex) {
                PessoaTipoRetorno = new PessoaTipoDataTransfer();

                PessoaTipoRetorno.Validacao = false;
                PessoaTipoRetorno.Erro = true;
                PessoaTipoRetorno.ErroMensagens.Add("Erro em PessoaTipoDataModel ConsultarPorId [" + ex.Message + "]");
            } finally {
                pessoaTipoData = null;
            }

            return PessoaTipoRetorno;
        }
    }
}

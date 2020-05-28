﻿using System;
using rcDominiosTransfers;
using rcDominiosUtils;

namespace rcDominiosBusiness
{
    public class TelefoneTipoBusiness
    {
        public TelefoneTipoTransfer Validar(TelefoneTipoTransfer telefoneTipoTransfer) 
        {
            TelefoneTipoTransfer telefoneTipoValidacao;

            try  {
                telefoneTipoValidacao = new TelefoneTipoTransfer(telefoneTipoTransfer);
                telefoneTipoValidacao.TelefoneTipo.Descricao = Tratamento.TratarStringNuloBranco(telefoneTipoValidacao.TelefoneTipo.Descricao);
                telefoneTipoValidacao.TelefoneTipo.Codigo = Tratamento.TratarStringNuloBranco(telefoneTipoValidacao.TelefoneTipo.Codigo);

                //-- Descrição do Tipo de Pessoa
                if (string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    telefoneTipoValidacao.IncluirMensagem("Necessário informar a Descrição do tipo de Telefone");
                } else if (telefoneTipoValidacao.TelefoneTipo.Descricao.Length > 100) {
                    telefoneTipoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                } else if (!Validacao.ValidarCharAaBCcNT(telefoneTipoValidacao.TelefoneTipo.Descricao)) {
                    telefoneTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                    telefoneTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                }

                //-- Código do Tipo de Pessoa
                if (!string.IsNullOrEmpty(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                    if (telefoneTipoValidacao.TelefoneTipo.Codigo.Length > 10) {
                        telefoneTipoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                    } else if(!Validacao.ValidarCharAaNT(telefoneTipoValidacao.TelefoneTipo.Codigo)) {
                        telefoneTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                        telefoneTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                    }
                }

                telefoneTipoValidacao.Validacao = true;

                if (telefoneTipoValidacao.Mensagens != null) {
                    if (telefoneTipoValidacao.Mensagens.Count > 0) {
                        telefoneTipoValidacao.Validacao = false;
                    }
                }

                telefoneTipoValidacao.Erro = false;
            } catch (Exception ex) {
                telefoneTipoValidacao = new TelefoneTipoTransfer();

                telefoneTipoValidacao.IncluirMensagem("Erro em TelefoneTipoBusiness Validar [" + ex.Message + "]");
                telefoneTipoValidacao.Validacao = false;
                telefoneTipoValidacao.Erro = true;
            }

            return telefoneTipoValidacao;
        }

        public TelefoneTipoTransfer ValidarConsulta(TelefoneTipoTransfer telefoneTipoTransfer) 
        {
            TelefoneTipoTransfer telefoneTipoValidacao;

            try  {
                telefoneTipoValidacao = new TelefoneTipoTransfer(telefoneTipoTransfer);

                if (telefoneTipoValidacao != null) {
                    telefoneTipoValidacao.Descricao = Tratamento.TratarStringNuloBranco(telefoneTipoValidacao.Descricao);
                    telefoneTipoValidacao.Codigo = Tratamento.TratarStringNuloBranco(telefoneTipoValidacao.Codigo);

                    //-- Id
                    if ((telefoneTipoValidacao.IdDe <= 0) && (telefoneTipoValidacao.IdAte > 0)) {
                        telefoneTipoValidacao.IncluirMensagem("Informe apenas o Id (De) para consultar um Id específico, ou os valores De e Até para consultar uma faixa de Id");
                    } else if ((telefoneTipoValidacao.IdDe > 0) && (telefoneTipoValidacao.IdAte > 0)) {
                        if (telefoneTipoValidacao.IdDe >= telefoneTipoValidacao.IdAte) {
                            telefoneTipoValidacao.IncluirMensagem("O valor mínimo (De) do Id deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Descrição do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(telefoneTipoValidacao.Descricao)) {
                        if (telefoneTipoValidacao.Descricao.Length > 100) {
                            telefoneTipoValidacao.IncluirMensagem("Descrição deve ter no máximo 100 caracteres");
                        } else if (!Validacao.ValidarCharAaBCcNT(telefoneTipoValidacao.Descricao)) {
                            telefoneTipoValidacao.IncluirMensagem("Descrição possui caracteres inválidos");
                            telefoneTipoValidacao.IncluirMensagem("Caracteres válidos: letras, acentos, números, traço e espaço em branco");
                        }
                    }

                    //-- Código do Tipo de Pessoa
                    if (!string.IsNullOrEmpty(telefoneTipoValidacao.Codigo)) {
                        if (telefoneTipoValidacao.Codigo.Length > 10) {
                            telefoneTipoValidacao.IncluirMensagem("Código deve ter no máximo 10 caracteres");
                        } else if(!Validacao.ValidarCharAaNT(telefoneTipoValidacao.Codigo)) {
                            telefoneTipoValidacao.IncluirMensagem("Código possui caracteres inválidos");
                            telefoneTipoValidacao.IncluirMensagem("Caracteres válidos: letras, números e traço");
                        }
                    }

                    //-- Data de Criação
                    if ((telefoneTipoValidacao.CriacaoDe == DateTime.MinValue) && (telefoneTipoValidacao.CriacaoAte != DateTime.MinValue)) {
                        telefoneTipoValidacao.IncluirMensagem("Informe apenas a Data de Criação (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((telefoneTipoValidacao.CriacaoDe > DateTime.MinValue) && (telefoneTipoValidacao.CriacaoAte > DateTime.MinValue)) {
                        if (telefoneTipoValidacao.CriacaoDe >= telefoneTipoValidacao.CriacaoAte) {
                            telefoneTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Criação deve ser menor que o valor máximo (Até)");
                        }
                    }

                    //-- Data de Alteração
                    if ((telefoneTipoValidacao.AlteracaoDe == DateTime.MinValue) && (telefoneTipoValidacao.AlteracaoAte != DateTime.MinValue)) {
                        telefoneTipoValidacao.IncluirMensagem("Informe apenas a Data de Alteração (De) para consultar uma data específica, ou os valores De e Até para consultar uma faixa de datas");
                    } else if ((telefoneTipoValidacao.AlteracaoDe > DateTime.MinValue) && (telefoneTipoValidacao.AlteracaoAte > DateTime.MinValue)) {
                        if (telefoneTipoValidacao.AlteracaoDe >= telefoneTipoValidacao.AlteracaoAte) {
                            telefoneTipoValidacao.IncluirMensagem("O valor mínimo (De) da Data de Alteração deve ser menor que o valor máximo (Até)");
                        }
                    }
                } else {
                    telefoneTipoValidacao = new TelefoneTipoTransfer();
                    telefoneTipoValidacao.IncluirMensagem("É necessário informar os dados do Tipo de Telefone");
                }

                telefoneTipoValidacao.Validacao = true;

                if (telefoneTipoValidacao.Mensagens != null) {
                    if (telefoneTipoValidacao.Mensagens.Count > 0) {
                        telefoneTipoValidacao.Validacao = false;
                    }
                }

                telefoneTipoValidacao.Erro = false;
            } catch (Exception ex) {
                telefoneTipoValidacao = new TelefoneTipoTransfer();

                telefoneTipoValidacao.IncluirMensagem("Erro em TelefoneTipoBusiness Validar [" + ex.Message + "]");
                telefoneTipoValidacao.Validacao = false;
                telefoneTipoValidacao.Erro = true;
            }

            return telefoneTipoValidacao;
        }
    }
}

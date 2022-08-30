﻿using BitHelp.Core.Validation;
using TemplateApi.Compartilhado.Extensoes;
using System.ComponentModel.DataAnnotations;

namespace TemplateApi.Api.ValuesObject
{
    public class NotificacaoAvisos
    {
        public NotificacaoAvisos(string mensagem, string referencia)
        {
            Id = Guid.NewGuid().ToString("N");
            Data = DateTime.Now;
            Mensagem = mensagem;
            Referencia = referencia ?? string.Empty;
            Tipo = TipoAvisos.Erro;
        }

        public NotificacaoAvisos(ValidationMessage dados)
        {
            Id = dados.Id.ToString("N");
            Data = dados.Date;
            Mensagem = dados.Message;
            Referencia = dados.Reference ?? string.Empty;
            Tipo = InterpretarTipo(dados.Type);
            Excecao = dados.Exception;
        }

        public string Id { get; set; }

        public DateTime Data { get; set; }

        public string Mensagem { get; set; }

        private string _referencia;
        [Display(Name = "Referência")]
        public string Referencia
        {
            get { return _referencia ??= string.Empty; }
            set { _referencia = (value ?? string.Empty).ToJsonReference(); }
        }

        public TipoAvisos Tipo { get; set; }

        [Display(Name = "Exceção")]
        public ExcecaoAvisos Excecao { get; set; }

        public bool EhValido()
        {
            return !(Tipo == TipoAvisos.Erro
                || Tipo == TipoAvisos.NaoAutorizado
                || Tipo == TipoAvisos.NaoEncontrado);
        }

        private TipoAvisos InterpretarTipo(ValidationType dados)
        {
            TipoAvisos resultado;
            switch (dados)
            {
                case ValidationType.Success:
                    resultado = TipoAvisos.Sucesso;
                    break;
                case ValidationType.Info:
                    resultado = TipoAvisos.Sucesso;
                    break;
                case ValidationType.Alert:
                    resultado = TipoAvisos.Atencao;
                    break;
                case ValidationType.Unauthorized:
                    resultado = TipoAvisos.NaoAutorizado;
                    break;
                case ValidationType.NotFound:
                    resultado = TipoAvisos.NaoEncontrado;
                    break;
                default:
                    resultado = TipoAvisos.Erro;
                    break;
            }

            return resultado;
        }
    }
}
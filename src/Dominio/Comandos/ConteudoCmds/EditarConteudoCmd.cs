﻿using BitHelp.Core.Validation;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using DotNetCore.API.Template.Dominio.Escopos;
using DotNetCore.API.Template.Dominio.Entidades;
using DotNetCore.API.Template.Dominio.ObjetosDeValor;

namespace DotNetCore.API.Template.Dominio.Comandos.ConteudoCmds
{
    public class EditarConteudoCmd 
        : Comum.EditarBaseCmd, ISelfValidation
    {
        public EditarConteudoCmd()
        {
            _escopo = new ConteudoEscp<EditarConteudoCmd>(this);
        }

        private int? _Conteudo;
        /// <summary>
        /// Identificador de conteúdo
        /// </summary>
        [Display(Name = "Conteúdo")]
        public int? Conteudo
        {
            get => _Conteudo;
            set
            {
                _Conteudo = value;
                RegistrarCampo(nameof(Conteudo));
                _escopo.IdEhValido(x => x.Conteudo);
            }
        }

        private string _titulo;
        /// <summary>
        /// Título de conteúdo
        /// </summary>
        [Display(Name = "Título")]
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                RegistrarCampo(nameof(Titulo));
                _escopo.TituloEhValido(x => x.Titulo);
            }
        }

        private string _alias;
        /// <summary>
        /// Alias de conteúdo
        /// </summary>
        public string Alias
        {
            get => _alias;
            set
            {
                _alias = value;
                RegistrarCampo(nameof(Alias));
                _escopo.AliasEhValido(x => x.Alias);
            }
        }

        private string _texto;
        /// <summary>
        /// Texto de conteúdo
        /// </summary>
        public string Texto
        {
            get => _texto;
            set
            {
                _texto = value;
                RegistrarCampo(nameof(Texto));
                _escopo.TextoEhValido(x => x.Texto);
            }
        }

        private Status? _status;
        /// <summary>
        /// Status de conteúdo
        /// </summary>
        public Status? Status
        {
            get => _status;
            set
            {
                _status = value;
                RegistrarCampo(nameof(Status));
                _escopo.StatusEhValido(x => x.Status);
            }
        }

        public void Aplicar(ref Conteudo dados)
        {
            if (CampoFoiRegistrado(nameof(Titulo)))
            {
                dados.Titulo = Titulo;
            }

            if (CampoFoiRegistrado(nameof(Alias)))
            {
                dados.Alias = Alias;
            }

            if (CampoFoiRegistrado(nameof(Texto)))
            {
                dados.Texto = Texto;
            }

            if (CampoFoiRegistrado(nameof(Status)))
            {
                dados.Status = Status;
            }
        }

        public void Desfazer(ref Conteudo dados) => dados = null;

        #region Auto validação

        protected ConteudoEscp<EditarConteudoCmd> _escopo;

        [JsonIgnore]
        public ValidationNotification Notifications { get; set; } = new ValidationNotification();

        public virtual bool IsValid()
        {
            _escopo.EhRequerido(x => x.Conteudo);

            return Notifications.IsValid();
        }

        #endregion
    }
}

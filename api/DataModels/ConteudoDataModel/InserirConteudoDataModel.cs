﻿using System.ComponentModel.DataAnnotations;
using TemplateApi.Compartilhado.ObjetosDeValor;
using TemplateApi.Dominio.ObjetosDeValor;

namespace TemplateApi.Api.DataModels.ConteudoDataModel
{
    public class InserirConteudoDataModel
        : Common.BaseDataModel<InserirConteudoDataModel>
    {
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
                RegistrarPropriedade();
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
                RegistrarPropriedade();
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
                RegistrarPropriedade();
            }
        }

        private EnumInput<Status> _status;
        /// <summary>
        /// Status de conteúdo
        /// </summary>
        public EnumInput<Status> Status
        {
            get => _status;
            set
            {
                _status = value;
                RegistrarPropriedade();
            }
        }
    }
}

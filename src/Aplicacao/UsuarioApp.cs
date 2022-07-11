﻿using System;
using System.Reflection;
using DotNetCore.API.Template.Dominio.Servicos;
using DotNetCore.API.Template.Dominio.Entidades;
using DotNetCore.API.Template.Dominio.ObjetosDeValor;
using DotNetCore.API.Template.Dominio.Comandos.UsuarioCmds;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DotNetCore.API.Template.Aplicacao
{
    public class UsuarioApp : Comum.BaseApp
    {
        public UsuarioApp(
            UsuarioServ servUsuario)
        {
            _servUsuario = servUsuario;
        }

        protected readonly UsuarioServ _servUsuario;

        /// <summary>
        /// Permite filtrar os usuários.
        /// </summary>
        [Display(Name = "Filtrar usuário")]
        [Description("Permite filtrar os usuários.")]
        public ResultadoBusca<Usuario> Filtrar(FiltrarUsuarioCmd comando)
        {
            Notifications.Clear();
            ResultadoBusca<Usuario> resultado = new ResultadoBusca<Usuario>();

            if (EhAutorizado(MethodBase.GetCurrentMethod()))
            {
                resultado = _servUsuario.Filtrar(comando);
                Validate(_servUsuario);
            }

            return resultado;
        }

        /// <summary>
        /// Permite inserir um novo usuário.
        /// </summary>
        [Display(Name = "Inserir usuário")]
        [Description("Permite inserir um novo usuário.")]
        public Usuario Inserir(InserirUsuarioCmd comando)
        {
            Notifications.Clear();
            Usuario resultado = null;

            if (EhAutorizado(MethodBase.GetCurrentMethod()))
            {
                resultado = _servUsuario.Inserir(comando);
                Validate(_servUsuario);
            }

            return resultado;
        }

        /// <summary>
        /// Permite editar um usuário específico.
        /// </summary>
        [Display(Name = "Editar usuário")]
        [Description("Permite editar um usuário específico.")]
        public Usuario Editar(EditarUsuarioCmd comando)
        {
            Notifications.Clear();
            Usuario resultado = null;

            if (EhAutorizado(MethodBase.GetCurrentMethod()))
            {
                resultado = _servUsuario.Editar(comando);
                Validate(_servUsuario);
            }

            return resultado;
        }

        /// <summary>
        /// Permite excluir um ou mais usuários.
        /// </summary>
        [Display(Name = "Excluir usuário")]
        [Description("Permite excluir um ou mais usuários.")]
        public void Excluir(ExcluirUsuarioCmd comando)
        {
            Notifications.Clear();

            if (EhAutorizado(MethodBase.GetCurrentMethod()))
            {
                _servUsuario.Excluir(comando);
                Validate(_servUsuario);
            }
        }
    }
}

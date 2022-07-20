﻿using System;
using Dapper;
using System.Collections.Generic;
using TemplateApi.Dominio.Interfaces;
using TemplateApi.Repositorio.Contexto;
using TemplateApi.Repositorio.Adaptadores;
using TemplateApi.Repositorio.Mapeamentos;
using TemplateApi.Dominio.ObjetosDeValor;
using TemplateApi.Dominio.Comandos.UsuarioCmds;
using System.Linq;

namespace TemplateApi.Repositorio.Persistencias.UsuarioPers
{
    internal class ExcluirUsuarioPers : Comum.SimplesRepositorio
    {
        public ExcluirUsuarioPers(
            Conexao conexao,
            IUnidadeTrabalho udt)
            : base(conexao, udt) { }

        public void Excluir(ExcluirUsuarioCmd comando)
        {
            Notifications.Clear();
            UsuarioMap map = new UsuarioMap();

            string sqlString = @$"
                    UPDATE [dbo].[{map.Tabela}] SET
                            [{map.Col(x => x.AlteradoEm)}] = @AlteradoEm
                           ,[{map.Col(x => x.Status)}] = @Status
                    WHERE {map.Col(x => x.Id)} IN @Id
                ";

            object sqlObject = new
            {
                Id = comando.Usuario,
                Status = new DbString { Value = StatusAdapt.EnumParaSql(Status.Excluido), IsAnsi = true },
                AlteradoEm = DateTime.Now
            };

            Conexao.Sessao.Execute(
                sqlString, sqlObject, Conexao.Transicao);
        }
    }
}

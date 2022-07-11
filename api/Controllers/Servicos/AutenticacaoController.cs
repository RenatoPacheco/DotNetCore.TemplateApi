﻿using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DotNetCore.API.Template.Aplicacao;
using Swashbuckle.AspNetCore.Annotations;
using DotNetCore.API.Template.Site.ViewsData;
using DotNetCore.API.Template.Dominio.Notacoes;
using DotNetCore.API.Template.Site.DataAnnotations;
using DotNetCore.API.Template.Dominio.Entidades;
using DotNetCore.API.Template.Site.ApiApplications;
using DotNetCore.API.Template.Site.ValuesObject;

namespace DotNetCore.API.Template.Site.Controllers.Servicos
{
    [ApiController, AcessoLivre]
    [Route("Servico/[controller]")]
    public class AutenticacaoController : Common.BaseController
    {
        public AutenticacaoController(
            AutenticacaoApiApp apiServAutenticacao,
            ILogger<AutenticacaoController> logger)
        {
            _logger = logger;
            _apiServAutenticacao = apiServAutenticacao;
        }

        private readonly ILogger<AutenticacaoController> _logger;
        private readonly AutenticacaoApiApp _apiServAutenticacao;

        /// <summary>
        /// Obter os dados da autenticação atual
        /// </summary>
        [HttpGet]
        [ReferenciarApp(typeof(AutenticacaoApp), nameof(AutenticacaoApp.Obter))]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(ComumViewsData<Autenticacao>))]
        public IActionResult Get()
        {
            AutenticacaoApi resultado = _apiServAutenticacao.Obter();
            Validate(_apiServAutenticacao);

            return CustomResponse(resultado);
        }
    }
}

﻿using System.Net;
using TemplateApi.Aplicacao;
using Microsoft.AspNetCore.Mvc;
using TemplateApi.Api.ViewsData;
using Microsoft.Extensions.Logging;
using TemplateApi.Dominio.Notacoes;
using TemplateApi.Api.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;
using TemplateApi.Dominio.Comandos.TesteCmds;
using TemplateApi.Api.Extensions;
using AutoMapper;
using TemplateApi.Api.DataModel.TesteDataModel;

namespace TemplateApi.Api.Controllers.Servicos
{
    [ApiController, NaoRequerAutorizacao]
    [Route("Servico/[controller]")]
    public class TesteController : Common.BaseController
    {
        public TesteController(
            IMapper mapper,
            TesteApp appTeste,
            ILogger<TesteController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _appTeste = appTeste;
        }

        private readonly ILogger<TesteController> _logger;
        private readonly TesteApp _appTeste;
        private readonly IMapper _mapper;

        /// <summary>
        /// Recebendo os dados por FromQuery
        /// </summary>
        [Route("FromQuery")]
        [HttpGet, HttpPost, HttpPut, HttpPatch, HttpDelete]
        [ReferenciarApp(typeof(TesteApp), nameof(TesteApp.Formatos))]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(ComumViewsData<FormatosTesteCmd>))]
        public IActionResult FromQuery([FromQuery] FormatosTesteDataModel bory)
        {
            InvocarSeNulo(ref bory);

            FormatosTesteCmd cmd = _mapper.Map<FormatosTesteCmd>(bory);
            cmd.ExtrairModelState(ModelState);

            FormatosTesteCmd resultado = _appTeste.Formatos(cmd);
            Validate(_appTeste);

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Recebendo os dados por FromBody
        /// </summary>
        [Route("FromBody")]
        [HttpGet, HttpPost, HttpPut, HttpPatch, HttpDelete]
        [ReferenciarApp(typeof(TesteApp), nameof(TesteApp.Formatos))]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(ComumViewsData<FormatosTesteCmd>))]
        public IActionResult FromBody([FromBody] FormatosTesteDataModel form)
        {
            InvocarSeNulo(ref form);

            FormatosTesteCmd cmd = _mapper.Map<FormatosTesteCmd>(form);
            cmd.ExtrairModelState(ModelState);

            FormatosTesteCmd resultado = _appTeste.Formatos(cmd);
            Validate(_appTeste);

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Recebendo os dados por FromForm
        /// </summary>
        [Route("FromForm")]
        [HttpGet, HttpPost, HttpPut, HttpPatch, HttpDelete]
        [ReferenciarApp(typeof(TesteApp), nameof(TesteApp.Formatos))]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(ComumViewsData<FormatosTesteCmd>))]
        public IActionResult FromForm([FromForm] FormatosTesteDataModel form)
        {
            InvocarSeNulo(ref form);

            FormatosTesteCmd cmd = _mapper.Map<FormatosTesteCmd>(form);
            cmd.ExtrairModelState(ModelState);

            FormatosTesteCmd resultado = _appTeste.Formatos(cmd);
            Validate(_appTeste);

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Recebendo os dados por FromHeader
        /// </summary>
        [Route("FromHeader")]
        [HttpGet, HttpPost, HttpPut, HttpPatch, HttpDelete]
        [ReferenciarApp(typeof(TesteApp), nameof(TesteApp.Formatos))]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(ComumViewsData<FormatosTesteCmd>))]
        public IActionResult FromHeader([FromHeader] FormatosTesteDataModel headre)
        {
            InvocarSeNulo(ref headre);

            FormatosTesteCmd cmd = _mapper.Map<FormatosTesteCmd>(headre);
            cmd.ExtrairModelState(ModelState);

            FormatosTesteCmd resultado = _appTeste.Formatos(cmd);
            Validate(_appTeste);

            return CustomResponse(resultado);
        }

        /// <summary>
        /// Recebendo os dados ser usar nenhum dos tipos From
        /// </summary>
        [Route("WithoutFrom")]
        [HttpGet, HttpPost, HttpPut, HttpPatch, HttpDelete]
        [ReferenciarApp(typeof(TesteApp), nameof(TesteApp.Formatos))]
        [SwaggerResponse((int)HttpStatusCode.OK, "", typeof(ComumViewsData<FormatosTesteCmd>))]
        public IActionResult WithoutFrom(FormatosTesteDataModel without)
        {
            InvocarSeNulo(ref without);

            FormatosTesteCmd cmd = _mapper.Map<FormatosTesteCmd>(without);
            cmd.ExtrairModelState(ModelState);

            FormatosTesteCmd resultado = _appTeste.Formatos(cmd);
            Validate(_appTeste);

            return CustomResponse(resultado);
        }
    }
}

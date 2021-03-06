﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Locadora.Domain.Commands.Equipamentos.Inputs;
using Locadora.Domain.Handlers;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Interfaces.Commands;
using Locadora.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    public class EquipamentoController : ControllerBase
    {
        //private readonly IEquipamentoRepository _repository;

        private readonly IUnitOfWork _unitofwork;
        private readonly EquipamentoHandler _handler;
        private readonly IMapper _mapper;

        public EquipamentoController(IUnitOfWork unitofwork, EquipamentoHandler handler, IMapper mapper)
        {
            _unitofwork = unitofwork;
            _handler = handler;
            _mapper = mapper;
        }

        /// <summary>
        /// Equipamentos
        /// </summary>                
        /// <remarks><h2><b>Lista todos os Equipamentos.</b></h2></remarks>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/Equipamentos")]
        [AllowAnonymous]
        public IEnumerable<EquipamentoQueryResult> Equipamentos()
        {
            try
            {
                var equipamento = _unitofwork.Equipamentos.ListarAsync().Result;
                return _mapper.Map<IEnumerable<EquipamentoQueryResult>>(equipamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Equipamentos
        /// </summary>                
        /// <remarks><h2><b>Consulta o equipamento.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Cliente</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("v1/Equipamentos/{id}")]
        [Authorize(Roles = "Cliente,Administrador")]
        public EquipamentoQueryResult Equipamento(Guid id)
        {
            try
            {
                var equipamento = _unitofwork.Equipamentos.ObterPorIdAsync(id).Result;
                return _mapper.Map<EquipamentoQueryResult>(equipamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Incluir equipamento 
        /// </summary>                
        /// <remarks><h2><b>Incluir novo Equipamento na base de dados.</b></h2></remarks>
        /// <param name="command">Parâmetro requerido command de Insert</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost]
        [Route("v1/Equipamentos")]
        [Authorize(Roles = "Administrador")]
        public ICommandResult EquipamentoInserir([FromBody] AdicionarEquipamentoCommand command)
        {
            try
            {
                return  _handler.Handler(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Alterar Equipamento
        /// </summary>        
        /// <remarks><h2><b>Alterar equipamento na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Cliente</param>        
        /// <param name="command">Parâmetro requerido command de Update</param>
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPut]
        [Route("v1/Equipamentos/{id}")]
        [Authorize(Roles = "Administrador")]
        public ICommandResult EquipamentoAlterar(Guid id, [FromBody] AtualizarEquipamentoCommand command)
        {
            try
            {
                command.Id = id;
                return _handler.Handler(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Excluir Equipamento
        /// </summary>                
        /// <remarks><h2><b>Excluir equipamento na base de dados.</b></h2></remarks>
        /// <param name="id">Parâmetro requerido id do Cliente</param>        
        /// <response code="200">OK Request</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [HttpDelete]
        [Route("v1/Equipamentos/{id}")]
        [Authorize(Roles = "Administrador")]
        public ICommandResult EquipamentoApagar(Guid id)
        {
            try
            {
                ApagarEquipamentoCommand command = new ApagarEquipamentoCommand() { Id = id };
                return _handler.Handler(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
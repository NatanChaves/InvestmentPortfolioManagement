using InvestmentPortfolioManagement.Data.DTOs;
using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using InvestmentPortfolioManagement.Services.App.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InvestmentPortfolioManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeusInvestimentosController : ControllerBase
    {
        private readonly IInvestimentoService _service;

        public MeusInvestimentosController(IInvestimentoService service)
        {
            _service = service;
        }

        [HttpPost("comprar")]
        public IActionResult ComprarInvestimento(CompraFundo fundo)
        {
            try
            {
                _service.Comprar(fundo.Id, fundo.Quantidade);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao comprar investimento, por favor contactar o administrador do sistema.");
            }
        }

        [HttpPost("vender")]
        public IActionResult VenderInvestimento(int id, int quantidadeVenda, decimal precoVenda)
        {
            try
            {
                _service.Vender(id, quantidadeVenda, precoVenda);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao vender investimento, por favor contactar o administrador do sistema.");
            }
        }

        [HttpGet("extrato_investimentos")]
        public IActionResult ExtratoInvestimentos(DateTime dataInicio, DateTime dataFim, int iniciarDe, int tamanhoPagina)
        {
            try
            {
                return Ok(_service.ConsultarInvestimentosPorData(dataInicio, dataFim, iniciarDe, tamanhoPagina));

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar investimentos, por favor contactar o administrador do sistema.");
            }
        }

        [HttpGet("consultar_investimento/{id}")]
        public IActionResult ConsultarInvestimento(int id)
        {
            try
            {
                Investimento investimento = _service.ConsultarInvestimento(id);

                return Ok(investimento);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar investimento, por favor contactar o administrador do sistema.");
            }
           
        }
    }
}

using InvestmentPortfolioManagement.Data.Models;
using InvestmentPortfolioManagement.Services.App.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InvestmentPortfolioManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IFundoImobiliarioService _service;

        public ProdutosController(IFundoImobiliarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult ListarProdutosDisponiveis(int iniciarDe, int tamanhoPagina)
        {
            try
            {
                Pagination pagination = new Pagination() { TamanhoPagina = tamanhoPagina, IniciarDe = iniciarDe };
                var produtos = _service.ListarProdutosDisponiveis(pagination);
                return Ok(produtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao consultar produtos disponiveis, por favor contactar o administrador do sistema.");
            }
        }
    }
}

using InvestmentPortfolioManagement.Data.Models;
using InvestmentPortfolioManagement.Notification.Email;
using InvestmentPortfolioManagement.Services.App.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestaoProdutosController : Controller
    {
        private readonly IFundoImobiliarioService _service;

        public GestaoProdutosController(IFundoImobiliarioService service)
        {
            _service = service;
        }

        [HttpPost("criar_produto")]
        public IActionResult CriarProduto(FundoImobiliarioDTO produto)
        {
            try
            {
                _service.CriarProduto(produto);
                return CreatedAtAction(nameof(_service.CriarProduto), produto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar produto, por favor contactar o administrador do sistema.");
            }
        }


        [HttpPut("atualizar_produto/{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] FundoImobiliarioDTO produto)
        {
            try
            {
                _service.AtualizarInformacoesFundoImobiliario(id, produto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar produto, por favor contactar o administrador do sistema.");
            }
        }

        [HttpDelete("remover_produto/{id}")]
        public IActionResult ExcluirProduto(int id)
        {
            try
            {
                _service.ExcluirFundoImobiliario(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar produto, por favor contactar o administrador do sistema.");
            }
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

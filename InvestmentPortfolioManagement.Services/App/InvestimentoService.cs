using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using InvestmentPortfolioManagement.Data.Repository;
using InvestmentPortfolioManagement.Services.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioManagement.Services.App
{
    public class InvestimentoService : IInvestimentoService
    {
        private readonly IFundoImobiliarioService _fundoImobiliarioService;
        private readonly IInvestimentoRepository _investimentoRepository;

        public InvestimentoService(IFundoImobiliarioService fundoImobiliarioService, IInvestimentoRepository investimentoRepository)
        {
            _fundoImobiliarioService = fundoImobiliarioService;
            _investimentoRepository = investimentoRepository;
        }

        public void Comprar(int id, int quantidadeCompra)
        {
            FundoImobiliario fundo = _fundoImobiliarioService.ConsultarFundoImobiliario(id);
            fundo.SubtrairQuantidade(quantidadeCompra);
            
            _fundoImobiliarioService.AlterarFundoImobiliarioOperado(fundo);

            Investimento investimento = new Investimento() { DataOperacao = DateTime.Now, FundoImobiliarioId = id, CorretoraExcutora = 114, CodigoCliente = 123, Quantidade = quantidadeCompra, Preco = fundo.Preco, TipoOperacao = 'C' };
            investimento.CalculaPrecoOperacao(quantidadeCompra);

            _investimentoRepository.RegistrarInvestimento(investimento);
        }

        public void Vender(int id, int quantidadeVenda, decimal precoVenda)
        {
            FundoImobiliario fundo = _fundoImobiliarioService.ConsultarFundoImobiliario(id);

            fundo.SomarQuantidade(quantidadeVenda);

            _fundoImobiliarioService.AlterarFundoImobiliarioOperado(fundo);

            Investimento investimento = new Investimento() { DataOperacao = DateTime.Now, FundoImobiliarioId = id, CorretoraExcutora = 114, CodigoCliente = 123,  Quantidade = quantidadeVenda, Preco = precoVenda, TipoOperacao = 'V' };
            investimento.CalculaPrecoOperacao(quantidadeVenda);

            _investimentoRepository.RegistrarInvestimento(investimento);
        }

        public List<Investimento> ConsultarInvestimentosPorData(DateTime dataInicioExtrato, DateTime dataFimExtrato, int iniciarDe, int tamanhoPagina)
        {
            return _investimentoRepository.RetornaTodosInvestimentosPorData(dataInicioExtrato, dataFimExtrato, iniciarDe, tamanhoPagina);
        }

        public Investimento ConsultarInvestimento(int id)
        {
            return _investimentoRepository.ConsultarInvestimento(id);
        }
        
        public List<Investimento> ConsultarInvestimentosProximoVencimento()
        {
            return _investimentoRepository.ConsultarInvestimentosProximoVencimento();
        }


    }
}

using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioManagement.Services.App.Interfaces
{
    public interface IInvestimentoService
    {
        void Comprar(int id, int quantidadeCompra);
        Investimento ConsultarInvestimento(int id); 
        List<Investimento> ConsultarInvestimentosPorData(DateTime dataInicioExtrato, DateTime dataFimExtrato, int iniciarDe, int tamanhoPagina);
        public void Vender(int id, int quantidadeVenda, decimal precoVenda);

        List<Investimento> ConsultarInvestimentosProximoVencimento();
    }
}

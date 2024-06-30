using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioManagement.Data.Repository
{
    public interface IInvestimentoRepository
    {
        void RegistrarInvestimento(Investimento investimento);
        List<Investimento> RetornaTodosInvestimentosPorData(DateTime dataInicio, DateTime dataFim, int iniciarDe, int tamanhoPagina);
        List<Investimento> ConsultarInvestimentosProximoVencimento();
        Investimento ConsultarInvestimento(int id);
    }
}

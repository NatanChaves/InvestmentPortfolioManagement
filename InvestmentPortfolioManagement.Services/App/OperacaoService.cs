using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using InvestmentPortfolioManagement.Data.Repository;
using InvestmentPortfolioManagement.Services.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioManagement.Services.App
{
    public class OperacaoService: IOperacaoService
    {
        private readonly IOperacaoRepository _operacaoRepository;

        public OperacaoService(IOperacaoRepository operacaoRepository)
        {
            _operacaoRepository = operacaoRepository;
        }

    }
}

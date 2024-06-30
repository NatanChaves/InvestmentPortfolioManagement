using InvestmentPortfolioManagement.Data.Context;
using InvestmentPortfolioManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioManagement.Data.Repository
{
    public class OperacaoRepository: IOperacaoRepository
    {
        private readonly DataBaseContextApplication _context;

        public OperacaoRepository(DataBaseContextApplication context)
        {
            _context = context;
        }
    }
}

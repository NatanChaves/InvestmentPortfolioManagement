using InvestmentPortfolioManagement.Data.Context;
using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvestmentPortfolioManagement.Data.Repository
{
    public class InvestimentoRepository : IInvestimentoRepository
    {
        private readonly DataBaseContextApplication _context;

        public InvestimentoRepository(DataBaseContextApplication context)
        {
            _context = context;
        }

        public void RegistrarInvestimento(Investimento investimento)
        {
            _context.Add(investimento);
            _context.SaveChanges();
        }

        public List<Investimento> RetornaTodosInvestimentosPorData(DateTime dataInicio, DateTime dataFim, int iniciarDe, int tamanhoPagina)
        {
            return _context.Investimentos
                .AsNoTracking()
                .Skip(iniciarDe * tamanhoPagina)
                .Take(tamanhoPagina)
                .Where(x => x.DataOperacao >= dataInicio & x.DataOperacao <= dataFim)
                .ToList();
        }

        public Investimento ConsultarInvestimento(int id)
        {
            return _context.Investimentos.AsNoTracking().Where(x => x.InvestimentoId == id).FirstOrDefault();
        }

        public List<Investimento> ConsultarInvestimentosProximoVencimento()
        {
            return _context.Investimentos.AsNoTracking().Where(x => x.DataVencimento <= DateTime.Now.AddDays(5)).ToList();
        }
    }
}

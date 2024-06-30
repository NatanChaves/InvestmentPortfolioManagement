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
    public class FundoImobiliarioRepository : IFundoImobiliarioRepository
    {
        private readonly DataBaseContextApplication _context;

        public FundoImobiliarioRepository(DataBaseContextApplication context)
        {
            _context = context;
        }

        public void AdicionarProduto(FundoImobiliario produto)
        {
            try
            {
                _context.Add(produto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AlterarFundoImobiliario(FundoImobiliario fundo)
        {
            _context.Update(fundo);
            _context.SaveChangesAsync();
        }
        public FundoImobiliario ConsultarFundoImobiliarioPorCodigoNegociacao(int codigoNegociacao)
        {
            return _context.FundosImobiliarios.Where(x => x.CodigoNegociacao == codigoNegociacao).FirstOrDefault();
        }
        public FundoImobiliario ConsultarFundoImobiliarioPorId(int id)
        {
            return _context.FundosImobiliarios.Find(id);
        }

        public List<FundoImobiliario> ListarProdutosDisponiveis(Pagination pagination)
        {
            return _context.FundosImobiliarios
            .AsNoTracking()
            .Where(x => x.Quantidade > 0)
            .Skip(pagination.IniciarDe * pagination.TamanhoPagina)
            .Take(pagination.TamanhoPagina)
            .ToList();
        }

        public void ExcluirFundoImobiliario(int id)
        {
            FundoImobiliario fundo = _context.FundosImobiliarios.Find(id);

            _context.FundosImobiliarios.Remove(fundo);
            _context.SaveChanges();
        }
    }
}

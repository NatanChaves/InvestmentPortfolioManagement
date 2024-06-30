using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioManagement.Data.Repository
{
    public interface IFundoImobiliarioRepository
    {
        void AdicionarProduto(FundoImobiliario produto);

        List<FundoImobiliario> ListarProdutosDisponiveis(Pagination pagination);

        FundoImobiliario ConsultarFundoImobiliarioPorId(int id);

        void AlterarFundoImobiliario(FundoImobiliario fundo);

        FundoImobiliario ConsultarFundoImobiliarioPorCodigoNegociacao(int codigoNegociacao);
        
        void ExcluirFundoImobiliario(int id);
    }
}

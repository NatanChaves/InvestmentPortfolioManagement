using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioManagement.Services.App.Interfaces
{
    public interface IFundoImobiliarioService
    {
        void CriarProduto(FundoImobiliarioDTO produto);

        List<FundoImobiliario> ListarProdutosDisponiveis(Pagination pagination);

        void AlterarFundoImobiliarioOperado(FundoImobiliario fundo);

        void AtualizarInformacoesFundoImobiliario(int id, FundoImobiliarioDTO fundo);

        FundoImobiliario ConsultarFundoImobiliario(int id);

        void ExcluirFundoImobiliario(int id);
    }
}

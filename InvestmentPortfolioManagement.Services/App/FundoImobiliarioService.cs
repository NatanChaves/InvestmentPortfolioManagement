using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Data.Models;
using InvestmentPortfolioManagement.Data.Repository;
using InvestmentPortfolioManagement.Services.App.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace InvestmentPortfolioManagement.Services.App
{
    public class FundoImobiliarioService: IFundoImobiliarioService
    {
        private readonly IFundoImobiliarioRepository _fundoImobiliarioRepository;
        private readonly IMapper _mapper;

        public FundoImobiliarioService(IFundoImobiliarioRepository produtoFinanceiroRepository, IMapper mapper)
        {
            _fundoImobiliarioRepository = produtoFinanceiroRepository;
            _mapper = mapper;
        }

        public void CriarProduto(FundoImobiliarioDTO produto)
        {
            var produtoMap = new FundoImobiliario() { Preco = produto.Preco, NomeFundo = produto.NomeFundo, Descricao = produto.Descricao, Quantidade = produto.Quantidade };
            _fundoImobiliarioRepository.AdicionarProduto(produtoMap);
        }

        public void AlterarFundoImobiliarioOperado(FundoImobiliario fundo)
        {
            _fundoImobiliarioRepository.AlterarFundoImobiliario(fundo);
        }

        public void AtualizarInformacoesFundoImobiliario(int id, FundoImobiliarioDTO fundo)
        {
            FundoImobiliario fundoAtualizado = _mapper.Map<FundoImobiliario>(fundo);

            FundoImobiliario fundoDb = _fundoImobiliarioRepository.ConsultarFundoImobiliarioPorId(id);

            if (fundoDb == null)
            {
                throw new ApplicationException($"Fundo imobiliário com ID {id} não encontrado.");
            }

            fundoDb.Descricao = fundoAtualizado.Descricao;
            fundoDb.CodigoNegociacao = fundoAtualizado.CodigoNegociacao;
            fundoDb.Quantidade = fundoAtualizado.Quantidade;
            fundoDb.CorretoraExcutora = fundoAtualizado.CorretoraExcutora;
            fundoDb.Preco = fundoAtualizado.Preco;
            fundoDb.NomeFundo = fundoAtualizado.NomeFundo;

            _fundoImobiliarioRepository.AlterarFundoImobiliario(fundoDb);
        }

        public void ExcluirFundoImobiliario(int id)
        {
            _fundoImobiliarioRepository.ExcluirFundoImobiliario(id);
        }

        public FundoImobiliario ConsultarFundoImobiliario(int id)
        {
            return _fundoImobiliarioRepository.ConsultarFundoImobiliarioPorId(id);
        }

        public List<FundoImobiliario> ListarProdutosDisponiveis(Pagination pagination)
        {
            return _fundoImobiliarioRepository.ListarProdutosDisponiveis(pagination);
        }
    }
}

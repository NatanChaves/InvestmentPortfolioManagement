using InvestmentPortfolioManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestmentPortfolioManagement.Data.Models
{
    public class FundoImobiliarioDTO 
    {
        public string NomeFundo { get; set; }
        public int CodigoNegociacao { get; set; }
        public int CorretoraExcutora { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestmentPortfolioManagement.Data.Entities
{
    public class Investimento 
    {
        public int InvestimentoId { get; set; }
        public DateTime DataOperacao { get; set; }

        public DateTime DataVencimento { get; set; }
        
        public int CodigoCliente { get; set; }
        public int CorretoraExcutora { get; set; }

        public int Quantidade { get; set; }
        
        public char TipoOperacao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoTotal { get; set; }

        public int FundoImobiliarioId { get; set; }
        public FundoImobiliario FundoImobiliario { get; set; }

        public void CalculaPrecoOperacao(int quantidade)
        {
            PrecoTotal = Preco * quantidade;
        }
    }
}

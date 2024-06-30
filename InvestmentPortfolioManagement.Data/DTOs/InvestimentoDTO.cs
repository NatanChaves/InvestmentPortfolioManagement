using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InvestmentPortfolioManagement.Data.Models
{
    public class InvestimentoDTO
    {
        public int InvestimentoId { get; set; }
        public DateTime DataOperacao { get; set; }

        public DateTime DataVencimento { get; set; }

        public int CodigoCliente { get; set; }
        public int CorretoraExcutora { get; set; }

        public int Quantidade { get; set; }

        public char TipoOperacao { get; set; }

        public decimal Preco { get; set; }

        public decimal PrecoTotal { get; set; }
    }
}

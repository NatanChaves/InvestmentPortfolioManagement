using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InvestmentPortfolioManagement.Data.Entities
{
    public class FundoImobiliario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FundoImobiliarioId { get; set; }
        public string NomeFundo { get; set; }
        public int CodigoNegociacao { get; set; }
        public int CorretoraExcutora { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Descricao { get; set; }
        public Investimento Investimento { get; set; }

        public void SubtrairQuantidade(int quantidade)
        {
            Quantidade = Quantidade - quantidade;
        }
        public void SomarQuantidade(int quantidade)
        {
            Quantidade = Quantidade + quantidade;
        }

    }

}

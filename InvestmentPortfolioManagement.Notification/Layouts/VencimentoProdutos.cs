using InvestmentPortfolioManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPortfolioManagement.Notification.Layouts
{
    public class VencimentoProdutos
    {
        public static string LayoutEmailVencimentoProdutos(List<Investimento> investimentosProximoAoVentimento)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html lang=\"en\">");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta charset=\"UTF-8\">");
            sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            sb.AppendLine("<title>Produtos com Vencimento Próximo</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: Arial, sans-serif; line-height: 1.6; padding: 20px; }");
            sb.AppendLine(".product { border: 1px solid #ccc; border-radius: 5px; padding: 10px; margin-bottom: 10px; }");
            sb.AppendLine(".product h3 { margin-top: 0; }");
            sb.AppendLine(".product .fund-name { font-style: italic; color: #666; }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<h2>Produtos com Vencimento Próximo</h2>");

            sb.AppendLine("<div class=\"product-list\">");
            foreach (var investimento in investimentosProximoAoVentimento)
            {
                sb.AppendLine("<div class=\"product\">");
                sb.AppendLine($"<h3>{investimento.CodigoCliente}</h3>");
                sb.AppendLine($"<p><span class=\"fund-name\">Nome do Fundo: </span>{investimento.FundoImobiliario.NomeFundo}</p>");
                sb.AppendLine($"<p>Data de Vencimento: {investimento.DataVencimento}</p>");
                sb.AppendLine("</div>");
            }
            sb.AppendLine("</div>");

            sb.AppendLine("</body>");
            sb.AppendLine("</html>");

            return sb.ToString();
        }
    }
}

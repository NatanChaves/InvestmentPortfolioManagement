using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPortfolioManagement.Notification.Email.Interfaces
{
    public interface IEmailSender
    {
         Task SendEmail(string toEmail, string subject, string body);
    }
}

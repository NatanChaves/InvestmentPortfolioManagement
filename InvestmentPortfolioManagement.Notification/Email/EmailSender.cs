using InvestmentPortfolioManagement.Notification.Email.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using InvestmentPortfolioManagement.Notification.Layouts;
using InvestmentPortfolioManagement.Data.Entities;
using InvestmentPortfolioManagement.Services.App.Interfaces;

namespace InvestmentPortfolioManagement.Notification.Email
{
    public class EmailSender: IJob
    {
        public readonly IInvestimentoService _investimentoService;

        public EmailSender(IInvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("Enviando email...");
                string admEmail = "XXXX";
                var smtpServer = "localhost"; 
                var smtpPort = 25; 

                var fromAddress = new MailAddress("natan@localhost.localdomain", "Natan");
                var toAddress = new MailAddress(admEmail, "Recipient Name");

                using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.Credentials = CredentialCache.DefaultNetworkCredentials;

                    var mailMessage = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = "remetente",
                        Body = VencimentoProdutos.LayoutEmailVencimentoProdutos(_investimentoService.ConsultarInvestimentosProximoVencimento())
                    };

                    try
                    {
                        smtpClient.SendMailAsync(mailMessage);

                        return Task.CompletedTask;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

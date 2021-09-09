using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace MWSFBlazorFrontEnd.Areas.Services
{
    public class IdentityEmailSender : IEmailSender
    {
        private readonly string _host;
        private readonly string _fromAddress;
        private readonly string _password;
        private readonly int _port;

        public IdentityEmailSender(IConfiguration config)
        {
            var noReplyConfig = config.GetSection("Email:NoReply");

            _host = noReplyConfig["Host"];
            _fromAddress = noReplyConfig["Username"];
            _password = noReplyConfig["Password"];
            _port = int.Parse(noReplyConfig["Port"]);
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            MailMessage message = new MailMessage()
            {
                From = new MailAddress(_fromAddress),
                Subject = subject,
                To = { new MailAddress(email)},
                Body = $"<html><body>{htmlMessage}</body><html>",
                IsBodyHtml = true
            };

            var smtpClient = new SmtpClient(_host)
            {
                Port = _port,
                Credentials = new NetworkCredential(_fromAddress, _password)
            };

            smtpClient.Send(message);
        }
    }
}

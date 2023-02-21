﻿using GoodRead.Service.DTOs.Common;
using GoodRead.Service.Interfaces.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GoodRead.Service.Services.Common
{
    public class EmailService : IEmailService
    {
        private readonly IConfigurationSection _config;

        public EmailService(IConfiguration configuration)
        {
            _config = configuration.GetSection("Email");
        }

        public async Task SendAsync(EmailMessage message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["EmailAddress"]));
            email.To.Add(MailboxAddress.Parse(message.To));
            email.Subject = message.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message.Body.ToString() };

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["Host"], 587, SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_config["EmailAddress"], _config["Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }
}

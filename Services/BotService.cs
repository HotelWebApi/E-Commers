using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using System.Net.Mail;
using System.Net;

namespace Trainers.Services;
//Xatoliklaar bor !!!!!!!!!!!!!!!!!!!!!
public class BotService
{
    private static readonly string TelegramBotToken = "7084182840:AAED416hYE51RxlghOvfUjCEtYFH3j7f_7c";
    private static readonly string EmailFrom = "leadersacademy187@gmail.com";
    private static readonly string EmailPassword = "";
    private TelegramBotClient _botClient;

    public BotService()
    {
        _botClient = new TelegramBotClient(TelegramBotToken);
    }

    
    private async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using (var client = new SmtpClient("smtp.gmail.com", 587))
        {
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(EmailFrom, EmailPassword);

            var mailMessage = new MailMessage
            {
                From = new MailAddress(EmailFrom),
                Subject = subject,
                Body = body
            };
            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}
//////////////////
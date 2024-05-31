using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;

namespace Trainers.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BotController : ControllerBase
{
    private readonly TelegramBotClient _botClient;
    private const string TelegramBotToken = "7084182840:AAED416hYE51RxlghOvfUjCEtYFH3j7f_7c";
    private const string AdminEmail = "murodilovshahriyor761@gmail.com";
    private const string EmailFrom = "leadersacademy187@gmail.com";
    private const string EmailPassword = "btij wwta hxkj agto";
    private const string AdminChatId = "5795093154";

    public BotController()
    {
        _botClient = new TelegramBotClient(TelegramBotToken);
    }

    [HttpPost("ToAdmin")]
    public async Task<IActionResult> SendMessage(string gmail, string message)
    {
        try
        {
            string userData = $"Message: {message}";
            string usergmail = $"The gmail: {gmail}";

            using (var client = new HttpClient())
            {
                string telegramAPI = $"https://api.telegram.org/bot{TelegramBotToken}/sendMessage";

                var messageData = new
                {
                    chat_id = AdminChatId,
                    text = $"{usergmail}\n{userData}"
                };
                var response = await client.PostAsJsonAsync(telegramAPI, messageData);
                if (response.IsSuccessStatusCode)
                {
                    //await SendEmailAsync(AdminEmail, "User Message", $"{usergmail}\n{userData}");
                    return Ok(new { Message = "Message sent successfully." });
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return BadRequest(new { Error = errorMessage });
                }
            }
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = $"An error occurred: {ex.Message}" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> SendMessageToUser(string gmail, string message)
    {
        try
        {
            await SendEmailAsync(gmail, "Response from a admin", message);
            return Ok(new { Message = "Message sent successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
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
    private void SendMessageFromBotByAdmin(string gmail, string message)
    {
        _botClient.SendTextMessageAsync(gmail, message);

    }
}
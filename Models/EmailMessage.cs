using System;
using System.ComponentModel.DataAnnotations;
using MimeKit;
using MailKit.Net.Smtp;
using System.Collections.Generic;


namespace EmailService.Models
{

  public class EmailMessage
  {
    [Required(ErrorMessage = "Email should have a list with a least one receiver")]
    [MinLength(1, ErrorMessage = "Email should have at least one receiver")]
    public List<MailboxAddress> To { get; set; }

    [Required(ErrorMessage = "This email should have a subject")]
    [MinLength(3, ErrorMessage = "This field should have 3 to 1024 characters")]
    [MaxLength(1024, ErrorMessage = "This field should have 3 to 1024 characters")]
    public string Subject { get; set; }

    [Required(ErrorMessage = "The email should have a body")]
    public string Body { get; set; }

    private MimeMessage CreateMessage()
    {
      MimeMessage msg = new MimeMessage();
      msg.From.Add(new MailboxAddress(Environment.GetEnvironmentVariable("SENDER_NAME"),
        Environment.GetEnvironmentVariable("SENDER_AUTH_NAME")
      ));
      msg.To.AddRange(this.To);
      msg.Subject = this.Subject;
      msg.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = this.Body };

      return msg;
    }

    public void Send()
    {
      string clientName = Environment.GetEnvironmentVariable("SMTP_CLIENT");
      int clientPort = Int16.Parse(Environment.GetEnvironmentVariable("CLIENT_PORT"));
      string userAuth = Environment.GetEnvironmentVariable("SENDER_AUTH_NAME");
      string passAuth = Environment.GetEnvironmentVariable("SENDER_AUTH_PASS");

      using (SmtpClient client = new SmtpClient())
      {
        client.Connect(clientName, clientPort, false);
        client.Authenticate(userAuth, passAuth);
        client.Send(this.CreateMessage());
        client.Disconnect(true);
      }
    }
  }
}
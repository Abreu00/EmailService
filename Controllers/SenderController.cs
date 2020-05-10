using Microsoft.AspNetCore.Mvc;
using EmailService.Models;
using EmailService.ViewModels;
using EmailService.ViewModels.EmailMessageViewModel;
using System.Linq;
using MimeKit;
using System.Collections.Generic;
using System;

namespace EmailService.Controllers
{
  [ApiController]
  [Route("api/v1")]
  public class SenderController : ControllerBase
  {
    [HttpPost]
    [Route("send")]
    public ResultViewModel sendEmail([FromBody] EditorEmailMessageViewModel model)
    {
      EmailMessage message = new EmailMessage();
      message.Subject = model.Subject;
      message.Body = model.Body;
      message.To = new List<MailboxAddress>();
      message.To.AddRange(model.To.Select(x => new MailboxAddress(x.Name, x.Address)));

      message.Send();

      return new ResultViewModel
      {
        Success = true,
        message = message.To.Count > 1 ? "Emails enviados com sucesso" : "Email enviado com sucesso"
      };
    }
  }
}
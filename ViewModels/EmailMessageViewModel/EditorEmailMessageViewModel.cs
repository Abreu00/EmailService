using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EmailService.ViewModels.EmailMessageViewModel
{
  public class EditorEmailMessageViewModel
  {
    [Required(ErrorMessage = "Email should have a list with a least one receiver")]
    [MinLength(1, ErrorMessage = "Email should have at least one receiver")]
    public IEnumerable<Receiver> To { get; set; }

    [Required(ErrorMessage = "This email should have a subject")]
    [MinLength(3, ErrorMessage = "This field should have 3 to 1024 characters")]
    [MaxLength(1024, ErrorMessage = "This field should have 3 to 1024 characters")]
    public string Subject { get; set; }

    [Required(ErrorMessage = "The email should have a body")]
    public string Body { get; set; }

  }
}
using System.ComponentModel.DataAnnotations;

namespace EmailService.ViewModels.EmailMessageViewModel
{
  public class Receiver
  {
    [Required(ErrorMessage = "'To' field object should have a name")]
    [MinLength(3, ErrorMessage = "Name should have from 3 to 256 characters")]
    [MaxLength(256, ErrorMessage = "Name should have from 3 to 256 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "'To' field object should have a address")]
    [EmailAddress(ErrorMessage = "'Address' field should be a valid email address")]
    public string Address { get; set; }
  }
}
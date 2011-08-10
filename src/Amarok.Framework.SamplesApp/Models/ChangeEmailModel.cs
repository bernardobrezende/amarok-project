using System.ComponentModel.DataAnnotations;
using Amarok.Framework.Validation;

namespace Amarok.Framework.SamplesApp.Models
{
    public class ChangeEmailModel
    {
        [Required]
        [EmailAddress("deve ser email!")]
        public string Email { get; set; }
    }
}
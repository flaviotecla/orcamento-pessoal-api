using System.ComponentModel.DataAnnotations;

namespace orcamento_pessoal_api.Models.Dto
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
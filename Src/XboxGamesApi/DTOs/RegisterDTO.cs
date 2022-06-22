using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XboxGamesApi.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$"
        , ErrorMessage = "A senha deve ter 1 maiúscula, 1 minúscula, 1 número, 1 não alfanumérico e pelo menos 6 caracteres.")]
        public string Password { get; set; }
    }
}

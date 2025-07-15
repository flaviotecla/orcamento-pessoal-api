using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orcamento_pessoal_api.Models.Dto
{
    public class LoginUserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
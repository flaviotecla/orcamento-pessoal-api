using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace orcamento_pessoal_api.Models.Dto
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public string UserName { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
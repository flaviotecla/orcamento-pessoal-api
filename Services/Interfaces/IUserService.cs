using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using orcamento_pessoal_api.Models.Dto;

namespace orcamento_pessoal_api.Services.Interfaces
{
    public interface IUserService
    {
        void CreateUser(CreateUserRequest request);
        bool ValidateLogin(LoginUserRequest request);
    }
}
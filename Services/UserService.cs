using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using orcamento_pessoal_api.Models.Dto;
using orcamento_pessoal_api.Repositories.Interfaces;
using orcamento_pessoal_api.Services.Interfaces;

namespace orcamento_pessoal_api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(CreateUserRequest request)
        {
            _userRepository.CreateUser(request);
        }

        public bool ValidateLogin(LoginUserRequest request)
        {
            return _userRepository.ValidateLogin(request);
        }
    }
}
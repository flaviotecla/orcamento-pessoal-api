using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using orcamento_pessoal_api.Data;
using orcamento_pessoal_api.Helpers;
using orcamento_pessoal_api.Models.Dto;
using orcamento_pessoal_api.Models.Entities;
using orcamento_pessoal_api.Repositories.Interfaces;

namespace orcamento_pessoal_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(CreateUserRequest request)
        {
            var salt = SenhaHelper.GenerateSalt();
            var hash = SenhaHelper.GenerateHash(request.Password, salt);

            var model = new Usuario
            {
                Name = request.Name,
                Login = request.Login,
                Salt = salt,
                HashSenha = hash
            };

            _context.Usuarios.Add(model);
            _context.SaveChanges();
        }

        public bool ValidateLogin(LoginUserRequest request)
        {
            var user = _context.Usuarios.Where(u => u.Login == request.Login).FirstOrDefault();
            var salt = user.Salt;
            var hash = user.HashSenha;

            var validateHash = SenhaHelper.GenerateHash(request.Password, salt);
            
            return (hash == validateHash);
        }
    }
}
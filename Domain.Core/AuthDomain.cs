using Aplication.Dto;
using Domain.Interface;
using Entity;
using Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.Auth;

namespace Domain.Core
{
    public class AuthDomain : IAuthDomain
    {
        private readonly IConfiguration _config;
        private readonly IUser _repository;
        public AuthDomain(IConfiguration config,IUser repository)
        {
            _config = config;
            _repository = repository;
        }

        public Task<string> GenerarToken(UserDto user)
        {
            string token = JWT.GetToken(user,_config);
            return Task.FromResult(token);
        }

        public async Task<User> GetUserForNameUser(string nameUser)
        {
            User user = await _repository.Get_UserAsync(nameUser);
            return user;
        }

        public async Task<bool> SaveUser(User user)
        {
            return  await _repository.SaveUserAsync(user);
        }
    }
}

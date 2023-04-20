using Aplication.Dto;
using Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IAuthDomain
    {
        Task<User> GetUserForNameUser(string user);
        Task<string> GenerarToken(UserDto user);
        Task<bool> SaveUser(User user);
    }
}

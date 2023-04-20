using Aplication.Dto;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.common;

namespace Aplication.Interface
{
    public interface IAuthAplication
    {
        Task<Response<bool>> ValidateCredentials(UserDto user);
        Task<Response<string>> GenerarToken(UserDto user);
        Task<Response<bool>> SaveUser(UserDto user);
    }
}

using Aplication.Dto;
using Aplication.Interface;
using AutoMapper;
using Domain.Interface;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.common;

namespace Aplication.main
{
    public class AuthAplication : IAuthAplication
    {
        private readonly IAuthDomain _authDomain;
        private readonly IMapper _mapper;
        public AuthAplication(IAuthDomain authDomain, IMapper mapper)
        {
            _authDomain = authDomain;
            _mapper = mapper;
        }

        public async Task<Response<string>> GenerarToken(UserDto user)
        {
            Response<string> response = new();
            response.Data = await _authDomain.GenerarToken(user);
            return response;
        }

        public async Task<Response<bool>> SaveUser(UserDto userDto)
        {
            Response<bool> response = new();
            User user = _mapper.Map<User>(userDto);
            string encritarPasswd = this.Encriptar(user.Password);
            user.Password = encritarPasswd;

            response.Data = await _authDomain.SaveUser(user);
            if(response.Data == true)
            {
                response.IsSuccess = true;
                response.RMessage = "Registro guardado con exito!";
            }
            else
            {
                response.IsSuccess = false;
                response.RMessage = "fail no se logro guardar el registro!";
            }
            return response;
        }

        public async Task<Response<bool>> ValidateCredentials(UserDto user)
        {
            Response<bool> response = new();
            var Getuser = await _authDomain.GetUserForNameUser(user.Usuario);
            string DesenPasswd = this.DesEncriptar(Getuser.Password);
            if(user.Usuario ==Getuser.Usuario && user.Password == DesenPasswd)
            {
                response.Data = true;
                response.IsSuccess = true;
                response.RMessage = "verificacion Correcta!!";
            }
            else
            {
                response.Data = false;
                response.IsSuccess = false;
                response.RMessage = "usuario o password incorrecta!!";
            }
            return response;
        }


        private  string Encriptar( string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }

       
        private  string DesEncriptar( string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

    }
}

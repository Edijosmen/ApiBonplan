using Dapper;
using Data;
using Entity;
using Infrastructure.Interface;
using System.Data;

namespace Infrastructure.Repository
{
    public class UserRepository : IUser
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<User> Get_UserAsync(string USERNAME)
        {
            using (var conn = _context.CrearConnecion())
            {
                var parameter = new { USERNAME = USERNAME };
                var resultado = await conn.QueryAsync<User>("SP_GetUserForUserName", param:parameter, commandType: CommandType.StoredProcedure);
                if (resultado.Count() == 0)
                {
                    return new User();
                }
                var user = resultado.ToList();
                return user[0];
            }
        }

        public Task<bool> SaveUserAsync(User user)
        {
            using (var conn = _context.CrearConnecion()) {
                var parametros = new { NameUSer = user.Usuario, Password = user.Password };
                var resultado = conn.Execute("SP_InserUser", parametros, commandType: CommandType.StoredProcedure);
                if (resultado > 0)
                {
                    return Task.FromResult(true);
                    Console.WriteLine("Los datos se guardaron con éxito.");
                }
                else
                {
                    return Task.FromResult(false);
                    Console.WriteLine("Ocurrió un error al guardar los datos.");
                }
            }
          
        }
    }
}

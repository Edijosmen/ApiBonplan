using Data;
using Entity;
using Infrastructure.Interface;
using Dapper;

namespace Infrastructure.Repository
{
    public class DepartamentoRespository : IDepartamento
    {
        private readonly DapperContext _context;
        public DepartamentoRespository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            using (var connection= _context.CrearConnecion())
            {
                var query = @"SELECT * FROM Departamentos";
                var result = await connection.QueryAsync<Departamento>(query);
                return result;
            }
        }
    }
}

using Data;
using Entity;
using Infrastructure.Interface;
using System;
using Dapper;

namespace Infrastructure.Repository
{
    public class MunicipioRepository : IMunicipio
    {
        private readonly DapperContext _context;
        public MunicipioRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Municipio>> GetMunicipio()
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = @"SELECT Mcip_Id,Mcip_Name
                                FROM Municipio";
                var result   = await connection.QueryAsync<Municipio>(query);
                return result;
            }
        }

        public async Task<IEnumerable<Municipio>> GetMunicipioByDpart(int Dpart_Id)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = @"SELECT Mcip_Id,Mcip_Name
                                FROM Municipio
                                    WHERE Dpart_Id=@Dpart_Id";
                var param = new { Dpart_Id = Dpart_Id };
                var result = await connection.QueryAsync<Municipio>(query,param);
                return result;
            }
        }

        public async Task<Municipio> GetMunicipioByName(string Mcip_Name)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = @"SELECT Mcip_Id,Mcip_Name
                                FROM Municipio
                                    WHERE Mcip_Name=@Mcip_Name";
                var param = new { Mcip_Name = Mcip_Name };
                var result = await connection.QueryFirstAsync<Municipio>(query, param);
                return result;
            }
        }
    }
}

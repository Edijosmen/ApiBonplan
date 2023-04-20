using Dapper;
using Data;
using Entity;
using Infrastructure.Interface;

namespace Infrastructure.Repository
{
    public class PropertyByMunicipioRepository : IPropertyByMuncipio
    {
        private readonly DapperContext _context;
        public PropertyByMunicipioRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> DeleteAsync(string idReferencia)
        {
            using (var connection = _context.CrearConnecion())
            {
                string query = $"Delete from Db_Bonplan.dbo.PropertyByMunicipio where PropertyId = @PropertyId";
                var parameters = new { PropertyId = idReferencia };

                // Ejecutar la consulta
                int rowsAffected = await connection.ExecuteAsync(query, parameters);

                //if (rowsAffected > 0)
                //{
                //    // La eliminación fue exitosa
                //    //return $"Se eliminaron {rowsAffected} filas.";

                //}
                //else
                //{
                //    // No se encontraron filas para eliminar
                //    return "No se encontraron filas para eliminar.";
                //}
                return rowsAffected;
            }
        }

        public Task<IEnumerable<Property>> FilterByDepartamento(int dpart_Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> FilterByMunicipio(int mcip_id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(PropertyByMunicipio entity)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = @"INSERT INTO PropertyByMunicipio ( Mcip_Id,PropertyId,Dpart_Id) 
                                     VALUES(@Mcip_Id, @PropertyId, @Dpart_Id)";
                var result = await connection.ExecuteAsync(query, entity);
                return result > 0;
            }
        }
    }
}

using Aplication.Dto;
using Dapper;
using Data;
using Domain.Models;
using Entity;
using Infrastructure.Interface;

namespace Infrastructure.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly DapperContext _context;

        public PropertyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> InsertAsync(Property entity)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = "INSERT INTO Property (PropertyId,Description,Prece,TypeContract,State,Dimencion,TypPropertyId)" +
                            "              VALUES(@PropertyId,@Description,@Prece,@TypeContract,@State,@Dimencion,@TypPropertyId);          ";

                var result = await connection.ExecuteAsync(query, entity);
                return result > 0;
            }
        }
        public async Task<bool> UpdateAsync(string PropertyId, Property entity)
        {
            entity.PropertyId = PropertyId;
            using (var connection = _context.CrearConnecion())
            {
                var query = "UPDATE Property SET " +
                                            "Description=@Description," +
                                            "Prece=@Prece," +
                                            "TypeContract=@TypeContract," +
                                            "State=@State," +
                                            "Dimencion=@Dimencion," +
                                            "TypPropertyId=@TypPropertyId " +
                                            "WHERE " +
                                            "PropertyId=@PropertyId";
                var result = await connection.ExecuteAsync(query, entity);
                return result > 0;
            }
        }
        public async Task<bool> DeleteAsync(string id)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = "Delete Property WHERE " +
                                            "Property.PropertyId=@PropertyId";
                var param = new { PropertyId = id };
                var result = await connection.ExecuteAsync(query, param);
                return result > 0;
            }
        }
        public async Task<Property> GetAsync(string id)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = "Select p.PropertyId,p.Description,p.Prece,p.TypeContract,p.Dimencion,p.State,tc.PropertyName " +
                              "from Property p " +
                              "join TypProperty tc " +
                               "on p.TypPropertyId = tc.TypPropertyId " +
                               "and p.PropertyId = @PropertyId order by p.PropertyId ";
                var param = new { PropertyId=id };
                Property result =await connection.QuerySingleOrDefaultAsync<Property>(query, param);
                return result;
            }
        }
        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            IEnumerable < Property >d = new List<Property>();
            using (var connection = _context.CrearConnecion())
            {
                var query = @"SELECT p.PropertyId,p.Description,p.Prece,p.TypeContract,p.Dimencion,p.State,tc.PropertyName
                                FROM Property p 
                                JOIN TypProperty tc ON p.TypPropertyId = tc.TypPropertyId

                                select *  
                                from ImgStore

                                

                                  select Mcip_Name,d.Dpart_Name, mp.PropertyId
                                      from PropertyByMunicipio mp
                                      JOIN Municipio m on mp.Mcip_Id= m.Mcip_Id
                                      JOIN Departamentos d on mp.Dpart_Id = d.Dpart_Id";

                var multiResult = connection.QueryMultipleAsync(query);
                var property = multiResult.Result.Read<Property>().ToList();
                var storeImg = multiResult.Result.Read<ImageStore>().ToList();
                //var type = multiResult.Result.Read<TypProperty>().ToList();
                var localidad = multiResult.Result.Read<LocalidadDto>().ToList();
                foreach (var item in property)
                {
                    
                    item.Mcip_Name = localidad.Where(x=>x.PropertyId== item.PropertyId).Select(x=>x.Mcip_Name).First();
                    item.Dpart_Name = localidad.Where(x => x.PropertyId == item.PropertyId).Select(x => x.Dpart_Name).First();
                    item.ImageStores = storeImg.Where(x => x.Property_Id == item.PropertyId).ToList();
                }
                //var result = await connection.QueryAsync<Property>(query);
                return property;
            }
        }

        public async Task<int> CountAsync()
        {
            using(var connection = _context.CrearConnecion())
            {
                var query = "SELECT COUNT(*) FROM Property";
                var count = await connection.ExecuteScalarAsync<int>(query);
                return count;
            }
        }
        public async Task<IEnumerable<Property>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = "GetAllPropertyPagination";
                var parameters = new DynamicParameters();
                parameters.Add("PageNumber",pageNumber);
                parameters.Add("PageSize",pageSize);

                var result = await connection.QueryAsync<Property>(query,param:parameters,commandType:System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<PropertyMdl>> GetPropertyAllAsync()
        {
            using (var connection = _context.CrearConnecion())
            {
                //var query = "SELECT p.PropertyId,p.Description,p.Prece,p.TypeContract,p.Dimencion,p.State,tc.PropertyName FROM Property p JOIN TypProperty tc ON p.TypPropertyId = tc.TypPropertyId";
                var query = "GetPropertyAll";

                var result = await connection.QueryAsync<PropertyMdl>(query, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<Property> GetPropertyByIdAsync(string propertyId)
        {
            using (var connection = _context.CrearConnecion())
            {
                var param = new { PropertyId = propertyId };
                var query = @"SELECT p.PropertyId,p.Description,p.Prece,p.TypeContract,p.Dimencion,p.State,tc.PropertyName
                                FROM Property p
                                JOIN TypProperty tc ON p.TypPropertyId = tc.TypPropertyId

                                WHERE p.PropertyId = @PropertyId

                                select*
                                from ImgStore

                                  select Mcip_Name,d.Dpart_Name, mp.PropertyId
                                      from PropertyByMunicipio mp
                                      JOIN Municipio m on mp.Mcip_Id = m.Mcip_Id
                                      JOIN Departamentos d on mp.Dpart_Id = d.Dpart_Id";

                var multiResult = connection.QueryMultipleAsync(query,param);
                var property = multiResult.Result.Read<Property>().First();
                var storeImg = multiResult.Result.Read<ImageStore>().ToList();
                //var type = multiResult.Result.Read<TypProperty>().ToList();
                var localidad = multiResult.Result.Read<LocalidadDto>().ToList();


                property.Mcip_Name = localidad.Where(x => x.PropertyId == property.PropertyId).Select(x => x.Mcip_Name).First();
                property.Dpart_Name = localidad.Where(x => x.PropertyId == property.PropertyId).Select(x => x.Dpart_Name).First();
                property.ImageStores = storeImg.Where(x => x.Property_Id == property.PropertyId).ToList();
                
                //var paramerts = new DynamicParameters();
                //paramerts.Add("PropertyId", propertyId);
                //var result = await connection.QuerySingleOrDefaultAsync<PropertyMdl>(query,paramerts, commandType: System.Data.CommandType.StoredProcedure);
                return property;
            }
        }
    }
}
using Data;
using Entity;
using Infrastructure.Interface;
using Dapper;

namespace Infrastructure.Repository
{
    public class ImageStoreRepository : IImageStore
    {
        private readonly DapperContext _context;
        public ImageStoreRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateImageStoreAsync(ImageStore imageStore)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = @"INSERT INTO ImgStore (ImgUrl,Property_Id)
                                            VALUES(@ImgUrl,@Property_Id)";
                var param = new {ImgUrl =imageStore.ImgUrl, Property_Id=imageStore.Property_Id };
                var result = await connection.ExecuteAsync(query, param);
                return result > 0;
            }
        }

        public async Task<int> DeleteAsync(string idReferencia)
        {
            using (var connection = _context.CrearConnecion())
            {
                string query = "Delete from Db_Bonplan.dbo.ImgStore where Property_Id =@PropertyId";
                var param = new { PropertyId = idReferencia };
                int rowfileAfect = await connection.ExecuteAsync(query,param);
                return rowfileAfect;
            }
        }

        public async Task<IEnumerable<ImageStore>> GetImageStoresByProperIdAsync(string propertyId)
        {
            using (var connection = _context.CrearConnecion())
            {
                var query = @"SELECT * FROM ImgStore
                                        WHERE Property_Id = @Property_Id ";
                var param = new { Property_Id = propertyId };
                var result = await connection.QueryAsync<ImageStore>(query, param);
                return result;
            }
        }
    }
}

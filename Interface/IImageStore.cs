using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IImageStore
    {
        Task<bool> CreateImageStoreAsync(ImageStore image);
        Task<IEnumerable<ImageStore>> GetImageStoresByProperIdAsync(string propertyId);
        Task<int> DeleteAsync( string idReferencia);
    }
}

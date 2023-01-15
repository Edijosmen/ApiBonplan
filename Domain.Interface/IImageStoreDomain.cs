using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IImageStoreDomain
    {
        Task<bool> CreateImageStoreAsync(ImageStore image);
        Task<IEnumerable<ImageStore>> GetImageStoresByProperIdAsync(string propertyId);
    }
}

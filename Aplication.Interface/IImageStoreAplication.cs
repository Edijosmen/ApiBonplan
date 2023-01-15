using Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.common;

namespace Aplication.Interface
{
    public interface IImageStoreAplication
    {
        Task<Response<bool>> CreateImageStoreAsync(ImageStoreDto image);
        Task<Response<ImageStoreDto>> GetImageStoresByProperIdAsync(string propertyId);
    }
}

using Aplication.Dto;
using Entity;
using Infrastructure.Interface;
using System;
using Transversal.common;

namespace Aplication.Interface
{
    public interface IPropertyAplication
    {
        #region Métodos ASíncronico
        Task<Response<bool>> InsertAsync(PropertyDto propertyDto);
        Task<Response<bool>> UpdateAsync(string propertyId ,PropertyDto propertyDto);
        Task<Response<bool>> DeleteAsync(string propertyId);
        Task<Response<GetPropertyDto>> GetAsync(string propertyId);
        Task<Response<IEnumerable<GetPropertyDto>>> GetAllAsync();
        Task<ResponsePangination<IEnumerable<GetPropertyDto>>> GetAllWithPaginationAsync(int PageNumber, int PageSize);
        #endregion
    }
}

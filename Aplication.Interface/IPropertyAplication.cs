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
        Task<Response<string>> InsertAsync(PropertyDto propertyDto);
        Task<Response<bool>> UpdateAsync(string propertyId ,PropertyDto propertyDto);
        Task<Response<bool>> DeleteAsync(string propertyId);
        Task<Response<GetPropertyDto>> GetAsync(string propertyId);
        Task<Response<IEnumerable<GetPropertyDto>>> GetAllAsync();
        Task<Response<IEnumerable<GetPropertyDto>>> GetAllAsyncFilters(SearchFilterDto filters);
        Task<ResponsePangination<IEnumerable<GetPropertyDto>>> GetAllWithPaginationAsync(int PageNumber, int PageSize);
        Task<Response<bool>> PropertyUpdateAsync(string ID, UpdPropertyDto propertyDto);
        #endregion
    }
}

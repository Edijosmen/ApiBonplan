
using Aplication.Dto;
using Domain.Models;
using Entity;
using Infrastructure.Interface;


namespace Domain.Interface
{
    public interface IPropertyDomain:IGenericCrud<Property>
    {
        Task<IEnumerable<PropertyMdl>> GetPropertyAllAsync();
        Task<Property> GetPropertyByIdAsync( string propertyId);
        Task<bool> PropertyUpdateAsync(string PropertyId, UpdPropertyDto entity);
    }
}

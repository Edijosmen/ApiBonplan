using Aplication.Dto;
using Domain.Models;
using Entity;


namespace Infrastructure.Interface
{
    public interface IPropertyRepository:IGenericCrud<Property>
    {
        Task<IEnumerable<PropertyMdl>> GetPropertyAllAsync();
        Task<Property> GetPropertyByIdAsync(string propertyId);
        Task<bool> PropertyUpdateAsync(string PropertyId, UpdPropertyDto entity);
    }
}

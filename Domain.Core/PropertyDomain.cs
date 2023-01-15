
using Domain.Interface;
using Domain.Models;
using Entity;
using Infrastructure.Interface;

namespace Domain.Core
{
    public class PropertyDomain : IPropertyDomain
    {
        private readonly IPropertyRepository _repository;
        public PropertyDomain(IPropertyRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> InsertAsync(Property entity)
        {
            return _repository.InsertAsync(entity);
        }

        public Task<bool> UpdateAsync( string id ,Property entity)
        {
            return _repository.UpdateAsync( id ,entity);
        }
        public Task<bool> DeleteAsync(string id)
        {
            return _repository.DeleteAsync(id);
        }
        public Task<Property> GetAsync(string id)
        {
           return _repository.GetAsync(id);
        }

        public async Task<int> CountAsync()
        {
           return await _repository.CountAsync();
        }
        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Property>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _repository.GetAllWithPaginationAsync(pageNumber, pageSize);
        }

        public async Task<IEnumerable<PropertyMdl>> GetPropertyAllAsync()
        {
            return await _repository.GetPropertyAllAsync();
        }

        public async Task<Property> GetPropertyByIdAsync(string propertyId)
        {
           return await _repository.GetPropertyByIdAsync( propertyId);
        }
    }
}

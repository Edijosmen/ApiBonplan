using Domain.Interface;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interface;

namespace Domain.Core
{
    public class PropertyByMunicipioDomain : IPropertyByMunicipioDomain
    {
        private readonly IPropertyByMuncipio _repository;
        public PropertyByMunicipioDomain(IPropertyByMuncipio repository)
        {
            _repository = repository;
        }

        public async Task<int> DeleteAsinc(string idRefencia)
        {
            return await _repository.DeleteAsync(idRefencia);
        }

        public Task<IEnumerable<Property>> FilterByDepartamento(int dpart_Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> FilterByMunicipio(int mcip_id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(PropertyByMunicipio entity)
        {
           return await _repository.InsertAsync(entity);
        }
    }
}

using Domain.Interface;
using Entity;
using Infrastructure.Interface;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class DepartamentoDomain : IDepartamentoDomain
    {
        private readonly IDepartamento _repository;
        public DepartamentoDomain(IDepartamento repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentosAll()
        {
           return await _repository.GetDepartamentos();
        }
    }
}

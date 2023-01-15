using Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.common;

namespace Aplication.Interface
{
    public interface IPropertyByMunicipio
    {
        Task<Response<bool>> InsertAsync(PropertyMunicipioDto propertyMunicipioDto);
        Task<Response<IEnumerable<PropertyDto>>> FilterByMunicipio ( PropertyDto propertyDto);
        Task<Response<IEnumerable<PropertyDto>>> FilterByDepartamento(PropertyDto propertyDto);

    }
}

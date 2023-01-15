using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Interface
{
    public interface IPropertyByMuncipio
    {
        Task<bool> InsertAsync(PropertyByMunicipio entity);
        Task<IEnumerable<Property>> FilterByMunicipio(int mcip_id);
        Task<IEnumerable<Property>> FilterByDepartamento(int dpart_Id);
    }
}

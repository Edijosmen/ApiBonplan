
using Entity;
using Infrastructure.Interface;

namespace Domain.Interface
{
    public interface IPropertyByMunicipioDomain
    {
        Task<bool> InsertAsync(PropertyByMunicipio entity);
        Task<IEnumerable<Property>> FilterByMunicipio(int mcip_id);
        Task<IEnumerable<Property>> FilterByDepartamento(int dpart_Id);
    }
}

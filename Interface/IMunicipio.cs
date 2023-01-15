using Entity;

namespace Infrastructure.Interface
{
    public interface IMunicipio
    {
        Task<IEnumerable<Municipio>> GetMunicipio();
        Task<IEnumerable<Municipio>> GetMunicipioByDpart(int dpartId);
        Task<Municipio> GetMunicipioByName(string Name);
    }
}

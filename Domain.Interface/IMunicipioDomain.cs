using Entity;


namespace Domain.Interface
{
    public interface IMunicipioDomain
    {
        Task<IEnumerable<Municipio>> GetMunicipio();
        Task<IEnumerable<Municipio>> GetMunicipioByDpart(int dpartId);
        Task<Municipio> GetMunicipioByName(string Name);
    }
}

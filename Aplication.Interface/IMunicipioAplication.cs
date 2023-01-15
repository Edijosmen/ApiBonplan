using Aplication.Dto;
using Entity;
using Transversal.common;

namespace Aplication.Interface
{
    public interface IMunicipioAplication
    {
        Task<Response<IEnumerable<GetMunicipioDto>>> GetMunicipio();
        Task<Response<IEnumerable<GetMunicipioDto>>> GetMunicipioByDpart(int dpartId);
        Task<Response<GetMunicipioDto>> GetMunicipioByName(string Name);
    }
}

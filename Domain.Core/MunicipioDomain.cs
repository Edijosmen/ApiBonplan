using Domain.Interface;
using Entity;
using Infrastructure.Interface;

namespace Domain.Core
{
    public class MunicipioDomain : IMunicipioDomain
    {
        private readonly IMunicipio _repository;
        public MunicipioDomain(IMunicipio municipio)
        {
            _repository = municipio;
        }

        public async Task<IEnumerable<Municipio>> GetMunicipio()
        {
            return await _repository.GetMunicipio();
        }

        public  async Task<IEnumerable<Municipio>> GetMunicipioByDpart(int dpartId)
        {
            return await _repository.GetMunicipioByDpart(dpartId);
        }

        public async Task<Municipio> GetMunicipioByName(string Name)
        {
            return await _repository.GetMunicipioByName(Name);
        }
    }
}

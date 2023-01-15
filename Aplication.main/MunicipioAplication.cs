using Aplication.Dto;
using Aplication.Interface;
using AutoMapper;
using Domain.Interface;
using Entity;
using Transversal.common;

namespace Aplication.main
{
    public class MunicipioAplication : IMunicipioAplication
    {
        private readonly IMunicipioDomain _municipioDomain;
        private readonly IMapper _mapper;
        public MunicipioAplication(IMunicipioDomain municipioDomain,IMapper mapper)
        {
            _municipioDomain = municipioDomain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetMunicipioDto>>> GetMunicipio()
        {
            Response<IEnumerable<GetMunicipioDto>> response = new();
            try
            {
                var municipio = await _municipioDomain.GetMunicipio();
                response.Data =  _mapper.Map<IEnumerable<GetMunicipioDto>>(municipio);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.RMessage = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.RMessage = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<GetMunicipioDto>>> GetMunicipioByDpart(int dpartId)
        {
            Response<IEnumerable<GetMunicipioDto>> response = new();
            try
            {
                var municipio = await _municipioDomain.GetMunicipioByDpart(dpartId);
                if (municipio != null)
                {
                    response.Data = _mapper.Map<IEnumerable<GetMunicipioDto>>(municipio);
                    response.RMessage = "Consulta Exitosa!!";
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                response.RMessage = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetMunicipioDto>> GetMunicipioByName(string Name)
        {
           Response<GetMunicipioDto> response = new();
            try
            {
                var municipio = await _municipioDomain.GetMunicipioByName(Name);
                if (municipio == null)
                {
                    response.Data = _mapper.Map<GetMunicipioDto>(municipio);
                    response.RMessage = "Consulta exitosa!!";
                }
            }
            catch (Exception ex)
            {
                response.RMessage = ex.Message;
            }
            return response;
        }
    }
}

using Aplication.Dto;
using Aplication.Interface;
using AutoMapper;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.common;

namespace Aplication.main
{
    public class DepartamentoAplication : IDepartamentoAplication
    {
        private readonly IDepartamentoDomain _departamentoDomain;
        private readonly IMapper _mapper;
        public DepartamentoAplication(IDepartamentoDomain departamentoDomain,IMapper mapper)
        {
            _departamentoDomain = departamentoDomain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<DepartamentoDto>>> GetDepartamentosAll()
        {
            Response<IEnumerable<DepartamentoDto>> response = new();
            try
            {
                var departamento = await _departamentoDomain.GetDepartamentosAll();
                response.Data = _mapper.Map<IEnumerable<DepartamentoDto>>(departamento);
                if(response.Data != null)
                {
                    response.IsSuccess = true;
                    response.RMessage = "Consulta Exitosa!!";
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Dto;
using Aplication.Interface;
using Domain.Interface;
using Transversal.common;
using AutoMapper;
using Entity;
namespace Aplication.main
{
    public class PropertyByMunicipioAplication : IPropertyByMunicipio
    {
        private readonly IPropertyByMunicipioDomain _domain;
        private readonly IMapper _mapper;
        public PropertyByMunicipioAplication(IPropertyByMunicipioDomain domain, IMapper mapper)
        {
            _domain = domain;
            _mapper = mapper;
        }

        public async Task<Response<bool>> DelecteAsync(string idRefencia)
        {
            Response<bool> response = new Response<bool>();
            int rest = await _domain.DeleteAsinc(idRefencia);
            if(rest > 0)
            {
                response.Data = true;
                response.IsSuccess = true;
                response.RMessage = $"Se eliminaron {rest} filas.";
            }
            response.Data = false;
            response.IsSuccess = false;
            response.RMessage = "No se encontraron filas para eliminar.";
            return response;
        }
        
        public Task<Response<IEnumerable<PropertyDto>>> FilterByDepartamento(PropertyDto propertyDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PropertyDto>>> FilterByMunicipio(PropertyDto propertyDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> InsertAsync(PropertyMunicipioDto propertyMunicipioDto)
        {
            Response<bool> response = new();
            try
            {
                var property = _mapper.Map<PropertyByMunicipio>(propertyMunicipioDto);
                response.Data = await _domain.InsertAsync(property);
                if (response.Data == true)
                {
                    response.IsSuccess=true;
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

using Aplication.Interface;
using Aplication.Dto;
using AutoMapper;
using Domain.Interface;
using Entity;
using Transversal.common;
using Transversal.AutoMapper;
using System.Linq;

namespace Aplication.main
{
    public class PropertyAplication : IPropertyAplication
    {
        private readonly IPropertyDomain _propertyDomain;
        private readonly IPropertyByMunicipioDomain _propertyByMunicipioDomain;
        private readonly IImageStoreDomain _imageStoreDomain;
        private readonly IMapper _mapper;

        public PropertyAplication(IPropertyDomain propertyDomain, IMapper mapper, IPropertyByMunicipioDomain propertyByMunicipioDomain, IImageStoreDomain imageStoreDomain)
        {
            _propertyDomain = propertyDomain;
            _mapper = mapper;
            _propertyByMunicipioDomain = propertyByMunicipioDomain;
           _imageStoreDomain = imageStoreDomain;
        }

        public async Task<Response<bool>> DeleteAsync(string propertyId)
        {
            Response<bool> response = new();
            try
            {
                int rest1 = await _propertyByMunicipioDomain.DeleteAsinc(propertyId);
                int rest2 = await _imageStoreDomain.DelecteAsync(propertyId);
                if(rest1 >0 && rest2 > 0)
                {
                    response.Data = await _propertyDomain.DeleteAsync(propertyId);
                    if (response.Data == true)
                    {
                        response.IsSuccess = true;
                        response.RMessage = "Eliminación Exitosa!!";
                    }
                }
            }
            catch (Exception ex)
            {

               response.RMessage =ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<GetPropertyDto>>> GetAllAsync()
        {
            Response<IEnumerable<GetPropertyDto>> response = new();
            try
            {
               var property = await _propertyDomain.GetAllAsync();
               response.Data = _mapper.Map<IEnumerable<GetPropertyDto>>(property);
                //response.Data = await _propertyDomain.GetPropertyAllAsync();
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.RMessage = "Consulta Exitosa";
                }
            }
            catch (Exception ex)
            {
                response.RMessage=ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<GetPropertyDto>>> GetAllAsyncFilters(SearchFilterDto filters)
        {
            Response<IEnumerable<GetPropertyDto>> response = new();
            try
            {
                var property = await _propertyDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<GetPropertyDto>>(property);
                //filters
                if (!string.IsNullOrEmpty(filters.search))
                {
                    response.Data = response.Data.Where(x =>
                                    x.Localidad.Contains(filters.search)
                                    || x.Mcip_Name.Contains(filters.search)
                                    || x.Dpart_Name.Contains(filters.search)
                                    || x.PropertyName.Contains(filters.search)).ToList();
                }
                if (!string.IsNullOrEmpty(filters.Estado))
                {
                    response.Data = response.Data.Where(x => 
                                                        x.TypeContract==(int.Parse(filters.Estado))).ToList();
                }
                if(!string.IsNullOrEmpty(filters.Desde) && !string.IsNullOrEmpty(filters.Hasta))
                {
                    response.Data = response.Data.Where(x => x.Prece >= int.Parse(filters.Desde) && x.Prece <= int.Parse(filters.Hasta)).ToList();
                }
                if (!string.IsNullOrEmpty(filters.NHAbitacion))
                {
                    response.Data = response.Data.Where(x =>
                                                        x.NHabitacion == int.Parse(filters.NHAbitacion)).ToList();
                }
                if (!string.IsNullOrEmpty(filters.NBano))
                {
                    response.Data = response.Data.Where(x =>
                                                        x.NBanio == int.Parse(filters.NBano)).ToList();
                }

                //response.Data = await _propertyDomain.GetPropertyAllAsync();
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

        public async Task<ResponsePangination<IEnumerable<GetPropertyDto>>> GetAllWithPaginationAsync(int PageNumber, int PageSize)
        {
            ResponsePangination<IEnumerable<GetPropertyDto>> response = new();
            try
            {
                int count = await _propertyDomain.CountAsync();
                IEnumerable<Property> property = await _propertyDomain.GetAllWithPaginationAsync(PageNumber,PageSize);
                response.Data = _mapper.Map<IEnumerable<GetPropertyDto>>(property);
                if(response.Data != null)
                {
                    response.IsSuccess = true;
                    response.RMessage = "Consulta Exitosa!!";
                    response.TotalPage = (int)Math.Ceiling(count /(double) PageSize);
                    response.TotalCount = count;
                    response.RMessage = "Consulta Exitosa!!";
                    response.PageNumber = PageNumber;
                }
            }
            catch (Exception ex)
            {
                response.RMessage = ex.Message;
            }
            return response;
        }

        public async Task<Response<GetPropertyDto>> GetAsync(string propertyId)
        {
            Response<GetPropertyDto> response = new();
            try
            {
                var property = await _propertyDomain.GetPropertyByIdAsync(propertyId);
                response.Data = _mapper.Map<GetPropertyDto>(property);
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

        public async Task<Response<string>> InsertAsync(PropertyDto propertyDto)
        {
            Response<string> response = new();
            Property property = Mapping.Get_PropertyDto(propertyDto);


            PropertyByMunicipio pByMunicipio = Mapping.Get_PropertyByMunicipio(propertyDto,property.PropertyId);
            try
            {
                //Property property = _mapper.Map<Property>(customerDto);
                 response.Data = await _propertyDomain.InsertAsync(property);
                bool success = await _propertyByMunicipioDomain.InsertAsync(pByMunicipio);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.RMessage = "Registro Guardado!!";
                }
            }
            catch (Exception ex)
            {
               response.RMessage = ex.Message;
            }
            return response;
        }

        public async Task<Response<bool>> PropertyUpdateAsync(string ID, UpdPropertyDto propertyDto)
        {
            Response<bool> response =new();
            try
            {

                response.Data = await _propertyDomain.PropertyUpdateAsync(ID,propertyDto);
                if(response.Data == true)
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

        public Task<Response<bool>> UpdateAsync(string propertyId, PropertyDto propertyDto)
        {
            throw new NotImplementedException();
        }
    }
}
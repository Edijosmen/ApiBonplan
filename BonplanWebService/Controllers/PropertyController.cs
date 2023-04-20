using Aplication.Dto;
using Aplication.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.common;

namespace BonplanWebService.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyAplication _propertyAplication;
        private readonly IPropertyByMunicipio _propertyByMunicipio;
        public PropertyController(IPropertyAplication propertyAplication, IPropertyByMunicipio propertyByMunicipio)
        {
            _propertyAplication = propertyAplication;
            _propertyByMunicipio = propertyByMunicipio;
        }
        [HttpPost]
        public async Task<IActionResult> Filters([FromBody] SearchFilterDto filtro)
        {

            Response<IEnumerable<GetPropertyDto>> response = await _propertyAplication.GetAllAsyncFilters(filtro);
            if (response.IsSuccess == false)
            {
                return BadRequest(new { messge = "Error en la consulta a Db" });
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] string propertyId)
        {
            if (string.IsNullOrEmpty(propertyId))
            {
                return BadRequest(new {message="el parametro de entrada no puede ser Vacio!!"});
            }
            Response<GetPropertyDto> response= await _propertyAplication.GetAsync(propertyId);
            if (response.IsSuccess == false)
            {
                return BadRequest(new {messge="Error en la consulta a Db"});
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            Response<IEnumerable< GetPropertyDto >> response = await _propertyAplication.GetAllAsync();
            if (response.IsSuccess == false)
            {
                return BadRequest(new { messge = "Error en la consulta a Db" });
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetByPage([FromQuery] int PageNumber, int pageSize)
        {

            Response<IEnumerable<GetPropertyDto>> response = await _propertyAplication.GetAllWithPaginationAsync(PageNumber,pageSize);
            if (response.IsSuccess == false)
            {
                return BadRequest(new { messge = "Error en la consulta a Db" });
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] PropertyDto property)
        {
            if (property == null)
                return BadRequest();
            var response = await _propertyAplication.InsertAsync(property);
            if (response.IsSuccess == false)
            {
                return NotFound(response.RMessage);
            }
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update( [FromBody] UpdPropertyDto property)
        {
            if (property == null)
                return BadRequest(new {message="parametros no puden estar vacios"});
            var response = await _propertyAplication.PropertyUpdateAsync(property.Id,property);
            if (response.IsSuccess == false)
            {
                return NotFound(response.RMessage="no se puedo actualizar el registro");
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id )
        {
            if (id == null)
                return BadRequest(new { message = "parametros no puden estar vacios" });

            var seach = await _propertyAplication.GetAsync(id);
            if(seach==null) return NotFound(new { message = "no se hay resgistro con ese ID" });
            
            var response = await _propertyAplication.DeleteAsync(id);
            if (response.IsSuccess == false)
            {
                return NotFound(response.RMessage = "no se puedo actualizar el registro");
            }
            return Ok(response);
        }
    }
}

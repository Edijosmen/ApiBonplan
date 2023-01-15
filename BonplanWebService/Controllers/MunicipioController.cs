using Aplication.Dto;
using Aplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.common;

namespace BonplanWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioAplication _municipioAplication;
        public MunicipioController(IMunicipioAplication municipioAplication)
        {
            _municipioAplication=municipioAplication;
        }
        [HttpGet]
        public async Task<IActionResult> GetMunicipioAll()
        {
            Response<IEnumerable<GetMunicipioDto>> response = await _municipioAplication.GetMunicipio();
            if (response.IsSuccess == false)
            {
                return BadRequest(response.RMessage);
            }
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetMunicipioByDepart([FromQuery] int dpertId)
        {
            Response<IEnumerable<GetMunicipioDto>> response = await _municipioAplication.GetMunicipioByDpart(dpertId);
            if (response.IsSuccess == false)
            {
                return BadRequest(response.RMessage);
            }
            return Ok(response);
        }
      
    }
}

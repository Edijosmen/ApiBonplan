using Aplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BonplanWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoAplication _dpart_Aplication;
        public DepartamentoController(IDepartamentoAplication dpart_Aplication)
        {
            _dpart_Aplication = dpart_Aplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartamentoAll()
        {
            var response = await _dpart_Aplication.GetDepartamentosAll();
            if (response.IsSuccess == false)
            {
                return BadRequest(response.RMessage);
            }
            return Ok(response);
        }
    }
}

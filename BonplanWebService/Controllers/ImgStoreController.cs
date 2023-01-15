using Aplication.Dto;
using Aplication.Interface;
using BonplanWebService.HandlerArch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.common;
using System.IO;
using Grpc.Core;

namespace BonplanWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgStoreController : ControllerBase
    {
        private readonly IImageStoreAplication _imgAplication;
        private readonly IHandlerArchivos _handlerArchivos;
        public ImgStoreController(IImageStoreAplication imgAplication, IHandlerArchivos handlerArchivos)
        {
            _imgAplication = imgAplication;
            _handlerArchivos = handlerArchivos;
        }

        [HttpPost]
        public async Task<IActionResult> GuardarImg([FromForm] ImgDto imgdto)
        {

            string galeria = "Galeria";
            ImageStoreDto img = new ImageStoreDto
            {
                Property_Id = imgdto.Property_Id,
                Image = new List<string>()
            };

            for (int i = 0; i < imgdto.Image.Count; i++)
            {
                string ulr = await _handlerArchivos.GuardarImagen(imgdto.Image[0], galeria);
                img.Image.Add(ulr);

            }
            var response = await _imgAplication.CreateImageStoreAsync(img);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetImgByPropertyId([FromQuery] String propertyId)
        {
            var response = await _imgAplication.GetImageStoresByProperIdAsync(propertyId);
            if (response.IsSuccess == true)
            {
                response.RMessage = "consulta exitosa!!";
            }
            else
                return BadRequest();

            return Ok(response);
        }
        [HttpGet("img")]
        public async Task<IActionResult> Galeria([FromQuery] string name)
        {

            var url = Path.GetFullPath($"~/Galeria/{name}");
            return Ok(new { Url = url });
        }
    }
}

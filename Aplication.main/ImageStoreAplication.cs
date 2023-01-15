using Aplication.Dto;
using Aplication.Interface;
using Domain.Interface;
using Transversal.AutoMapper;
using Transversal.common;

namespace Aplication.main
{
    public class ImageStoreAplication : IImageStoreAplication
    {
        private readonly IImageStoreDomain _imageStoreDomain;
        public ImageStoreAplication(IImageStoreDomain imageStoreDomain)
        {
            _imageStoreDomain = imageStoreDomain;
        }

        public async Task<Response<bool>> CreateImageStoreAsync(ImageStoreDto image)
        {
           Response<bool> response = new Response<bool>();
            try
            {         
                foreach (var item in image.Image)
                {
                    var entity = Mapping.Get_ImageStore(image.Property_Id, item);
                   response.Data = await _imageStoreDomain.CreateImageStoreAsync(entity);
                }
                if (response.Data == true)
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

        public async Task<Response<ImageStoreDto>> GetImageStoresByProperIdAsync(string propertyId)
        {
            Response<ImageStoreDto> response = new Response<ImageStoreDto>(); 
            try
            {
                var imgstore = await _imageStoreDomain.GetImageStoresByProperIdAsync(propertyId);
                response.Data = Mapping.Get_ImgStoreAsImgStoreDto(imgstore);
                if(response.Data != null)
                {
                    response.IsSuccess = true;
                }
               
            }
            catch (Exception  ex)
            {
                response.RMessage = ex.Message;
            }
            return response;
        }
    }
}

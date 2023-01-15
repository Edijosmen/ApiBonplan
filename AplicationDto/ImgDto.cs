using Microsoft.AspNetCore.Http;


namespace Aplication.Dto
{
    public class ImgDto
    {
        public string Property_Id { get; set; } =String.Empty;
        public List<IFormFile> Image { get; set; } 
       
    }
}

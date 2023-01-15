using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ImageStore
    {
       
        public int Img_Id { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string Property_Id { get; set; } = string.Empty;
        public Property Property { get; set; }
    }
}

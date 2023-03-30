using Aplication.Dto;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.AutoMapper
{
    public class Mapping
    {
        public static Property Get_PropertyDto(PropertyDto propertyDto)
        {
            Property property = new Property
            {
                PropertyId = Guid.NewGuid().ToString(),
                Description = propertyDto.Description,
                Prece = int.Parse(propertyDto.Prece),
                TypPropertyId = propertyDto.TypPropertyId,
                State = propertyDto.State,
                TypeContract = propertyDto.TypeContract,
                Dimencion = propertyDto.Dimencion,
                NBanio = propertyDto.NBanio,
                NHabitacion = propertyDto.NHabitacion,
                Caracteristicas = propertyDto.Caracteristicas,
                Localidad = propertyDto.Localidad,
            };
            return property;
        }
        public static PropertyByMunicipio Get_PropertyByMunicipio(PropertyDto propertyDto, string Id)
        {
            PropertyByMunicipio pByMunicipio = new PropertyByMunicipio
            {
                Dpart_Id = propertyDto.Dpart_Id,
                PropertyId = Id,
                Mcip_Id = propertyDto.Mcip_Id,
            };
            return pByMunicipio;
        }

        public static ImageStore Get_ImageStore(string propertyId, string imageStore)
        {

            ImageStore img = new ImageStore
            {
                ImgUrl = imageStore,
                Property_Id = propertyId
            };
            return img;
        }

        public static ImageStoreDto Get_ImgStoreAsImgStoreDto(IEnumerable<ImageStore> img)
        {
            ImageStoreDto imgDto = new();
            imgDto.Image = new List<string>();
            foreach (var item in img)
            {
                imgDto.Property_Id = item.Property_Id;
                imgDto.Image.Add(item.ImgUrl);
            }
            return imgDto;
        }
    }
}

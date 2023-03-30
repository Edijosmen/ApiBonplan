using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dto
{
    public class GetPropertyDto
    {
        public string PropertyId { get; set; }
        public string Description { get; set; }
        public float Prece { get; set; }
        public int TypeContract { get; set; }
        public string PropertyName { get; set; }
        public int State { get; set; }
        public string Dimencion { get; set; }
        public string TypName { get; set; }
        public string Mcip_Name { get; set; }
        public string Dpart_Name { get; set; }
        public string Localidad { get; set; }
        public int NHabitacion { get; set; }
        public int NBanio { get; set; }
        public string Caracteristicas { get; set; }
        public ICollection<ImageStore> ImageStores { get; set; }

    }
}

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
        public string Prece { get; set; }
        public int TypeContract { get; set; }
        public string PropertyName { get; set; }
        public int State { get; set; }
        public string Dimencion { get; set; }
        public string TypName { get; set; }
        public string Mcip_Name { get; set; }
        public string Dpart_Name { get; set; }
        public ICollection<ImageStore> ImageStores { get; set; }

    }
}

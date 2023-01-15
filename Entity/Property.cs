using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Property
    {
       
        public string PropertyId { get; set; }
        public string Description { get; set; }
        public string Prece { get; set; }
        public int TypeContract { get; set; }
        public string PropertyName { get; set; }
        public int State { get; set; }
        public string Dimencion { get; set; }
        public int TypPropertyId { get; set; }
        public string Mcip_Name { get; set; }
        public string Dpart_Name { get; set; }
        public ICollection<ImageStore> ImageStores { get; set; }
    }
}

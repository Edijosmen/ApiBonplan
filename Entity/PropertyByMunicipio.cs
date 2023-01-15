using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PropertyByMunicipio
    {
        [Key]
        public int PB_Id { get; set; }
        public int Mcip_Id { get; set; }
        public string PropertyId { get; set; }
        public int Dpart_Id { get; set; }
    }
}

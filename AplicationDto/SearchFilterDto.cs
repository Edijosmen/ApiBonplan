using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dto
{
    public class SearchFilterDto
    {
        public string search { get; set; }=String.Empty;
        public string Desde { get; set; } = String.Empty;
        public string Hasta { get; set; } = String.Empty;
        public string Estado { get; set; }=String.Empty;
        public string Tipo { get; set; } = String.Empty;
        public string NHAbitacion { get; set; } = String.Empty;
        public string NBano { get; set; } = String.Empty;
    }
}

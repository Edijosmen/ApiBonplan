using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.common
{
    public class Response<T> 
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string  RMessage { get; set; }
    }
}

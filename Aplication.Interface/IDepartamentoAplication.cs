using Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transversal.common;

namespace Aplication.Interface
{
    public interface IDepartamentoAplication
    {
        Task<Response<IEnumerable<DepartamentoDto>>> GetDepartamentosAll();
    }
}

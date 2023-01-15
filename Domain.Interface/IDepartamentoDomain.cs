﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDepartamentoDomain
    {
        Task<IEnumerable<Departamento>> GetDepartamentosAll();
    }
}

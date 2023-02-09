﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.IServices
{
    public interface ICountryService<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}

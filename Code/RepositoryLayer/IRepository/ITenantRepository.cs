﻿using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface ITenantRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void insert(T entity);
        IEnumerable<RentSchedules> GetTenantRent(long tenantId);
        void SaveChnages();
    }
}

using DomainLayer.Models;
using RepositoryLayer.CustomeModel;
using RepositoryLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.IServices
{
    public interface IRentCountService<T> where T : class
    {
        List<RentCountModel> GetRentCounts(RentCountModel rentCountModel);
        void AddRent(List<RentDetails> listofrentdetails);
    }
}

using RepositoryLayer.CustomeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IRentCountRepository<T> where T : class
    {
        void SaveChanges();
        List<RentCountModel> RentCalculation(RentCountModel rentCountModel);
    }
}

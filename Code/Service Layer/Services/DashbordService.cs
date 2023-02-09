using RepositoryLayer.CustomeModel;
using RepositoryLayer.IRepository;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class DashbordService : IDashbordService<DashbordModel>
    {
        private readonly IDashbordRepository<DashbordModel> _dashbord;
        public DashbordService(IDashbordRepository<DashbordModel> dashbordRepository)
        {
            _dashbord= dashbordRepository;
        }
        public DashbordModel DashbordModel()
        {
            return _dashbord.DashbordModel();
        }
    }
}

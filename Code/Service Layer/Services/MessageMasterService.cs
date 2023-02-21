using DomainLayer.Models;
using RepositoryLayer.IRepository;
using Service_Layer.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Layer.Services
{
    public class MessageMasterService : IMessageMasterService<MesssageMaster>
    {
        private readonly IMessageMasterRepository<MesssageMaster> _messageMaster;
        public MessageMasterService(IMessageMasterRepository<MesssageMaster> messageMaster)
        {
            _messageMaster = messageMaster;
        }
        public IEnumerable<MesssageMaster> GetAll()
        {
            try
            {
                return _messageMaster.GetAll();
            }
            catch (Exception)
            {
                throw;
                return null;
            }
        }

        public void Insert(MesssageMaster messagedetails)
        {
            try
            {
                if(messagedetails != null)
                {
                    _messageMaster.insert(messagedetails);
                }
            }
            catch (Exception)
            {
                throw;  
            }
        }
    }
}

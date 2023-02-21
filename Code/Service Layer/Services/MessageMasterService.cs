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
    public class MessageMasterService : IMessageMasterService<MessageMaster>
    {
        private readonly IMessageMasterRepository<MessageMaster> _messageMaster;
        public MessageMasterService(IMessageMasterRepository<MessageMaster> messageMaster)
        {
            _messageMaster = messageMaster;
        }
        public IEnumerable<MessageMaster> GetAll()
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

        public void Insert(MessageMaster messagedetails)
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

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
    public class MessageDetailsService: IMessageDetailsService<MessageDetails>
    {
        private readonly IMessageDetailsRepository<MessageDetails> _messageDetails;
        public MessageDetailsService(IMessageDetailsRepository<MessageDetails> messageDetails)
        {
            _messageDetails = messageDetails;
        }

        public IEnumerable<MessageDetails> GetAll()
        {
            try
            {
                return _messageDetails.GetAll();
            }
            catch (Exception)
            {
                throw;
                return null;
            }
        }

        public void Insert(MessageDetails message)
        {
            try
            {
                if (message != null)
                {
                    _messageDetails.insert(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _MessageDal;

        public MessageManager(IMessageDal MessageDal)
        {
            _MessageDal = MessageDal;
        }

        public void TAdd(Message t)
        {
            _MessageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _MessageDal.Delete(t);
        }

        public List<Message> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Message TGetByID(int id)
        {
            return _MessageDal.GetByID(id);
        }

        public List<Message> TGetList()
        {
            return _MessageDal.GetList();
        }

        public void TUpdate(Message t)
        {
            _MessageDal.Update(t);
        }
    }
}

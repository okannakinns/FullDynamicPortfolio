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
    public class WriterMessageManager : IWriterMessageService
    {
        IWriterMessageDal _WriterMessageDal;

        public WriterMessageManager(IWriterMessageDal WriterMessageDal)
        {
            _WriterMessageDal = WriterMessageDal;
        }

        public List<WriterMessage> GetListReceiverMessages(string p)
        {
            return _WriterMessageDal.GetByFilter(x=>x.Receiver==p);
        }

        public List<WriterMessage> GetListSenderMessages(string p)
        {
            return _WriterMessageDal.GetByFilter(x => x.Sender == p);

        }

        public void TAdd(WriterMessage t)
        {
            _WriterMessageDal.Insert(t);
        }

        public void TDelete(WriterMessage t)
        {
            _WriterMessageDal.Delete(t);
        }

        public List<WriterMessage> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public WriterMessage TGetByID(int id)
        {
            return _WriterMessageDal.GetByID(id);
        }

        public List<WriterMessage> TGetList()
        {
            return _WriterMessageDal.GetList();
        }

        public void TUpdate(WriterMessage t)
        {
            _WriterMessageDal.Update(t);
        }
    }
}

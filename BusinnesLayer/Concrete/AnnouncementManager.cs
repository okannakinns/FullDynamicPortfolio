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
    public class AnnouncementManager : IAnnouncementService
    {
        IAnnouncementDal _AnnouncementDal;

        public AnnouncementManager(IAnnouncementDal AnnouncementDal)
        {
            _AnnouncementDal = AnnouncementDal;
        }

        public void TAdd(Announcement t)
        {
            _AnnouncementDal.Insert(t);
        }

        public void TDelete(Announcement t)
        {
            _AnnouncementDal.Delete(t);
        }

        public List<Announcement> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Announcement TGetByID(int id)
        {
            return _AnnouncementDal.GetByID(id);
        }

        public List<Announcement> TGetList()
        {
            return _AnnouncementDal.GetList();
        }

        public void TUpdate(Announcement t)
        {
            _AnnouncementDal.Update(t);
        }
    }
}

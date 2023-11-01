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
    public class SocialMediaManager : ISocialMediaService
    {
        ISocialMediaDal _SocialMediaDal;

        public SocialMediaManager(ISocialMediaDal SocialMediaDal)
        {
            _SocialMediaDal = SocialMediaDal;
        }

        public void TAdd(SocialMedia t)
        {
            _SocialMediaDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _SocialMediaDal.Delete(t);
        }

        public List<SocialMedia> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public SocialMedia TGetByID(int id)
        {
            return _SocialMediaDal.GetByID(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _SocialMediaDal.GetList();
        }

        public void TUpdate(SocialMedia t)
        {
            _SocialMediaDal.Update(t);
        }
    }
}

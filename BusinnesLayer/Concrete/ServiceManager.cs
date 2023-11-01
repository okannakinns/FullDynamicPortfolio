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
    public class ServiceManager : IServiceService
    {
        IServiceDal _ServiceDal;

        public ServiceManager(IServiceDal ServiceDal)
        {
            _ServiceDal = ServiceDal;
        }

        public void TAdd(Service t)
        {
            _ServiceDal.Insert(t);
        }

        public void TDelete(Service t)
        {
            _ServiceDal.Delete(t);
        }

        public List<Service> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Service TGetByID(int id)
        {
            return _ServiceDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _ServiceDal.GetList();
        }

        public void TUpdate(Service t)
        {
            _ServiceDal.Update(t);
        }
    }
}

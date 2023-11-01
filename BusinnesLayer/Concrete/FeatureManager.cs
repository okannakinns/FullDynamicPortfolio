using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _FeatureDal;

        public FeatureManager(IFeatureDal FeatureDal)
        {
            _FeatureDal = FeatureDal;
        }

        public void TAdd(Feature t)
        {
            _FeatureDal.Insert(t);
        }

        public void TDelete(Feature t)
        {
            _FeatureDal.Delete(t);
        }

        public List<Feature> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Feature TGetByID(int id)
        {
            return _FeatureDal.GetByID(id);
        }

        public List<Feature> TGetList()
        {
            return _FeatureDal.GetList();
        }

        public void TUpdate(Feature t)
        {
            _FeatureDal.Update(t);
        }
    }
}

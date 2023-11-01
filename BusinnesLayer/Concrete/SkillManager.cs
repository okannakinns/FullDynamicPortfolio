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
    public class SkillManager : ISkillService
    {
        ISkillDal _SkillDal;

        public SkillManager(ISkillDal SkillDal)
        {
            _SkillDal = SkillDal;
        }

        public void TAdd(Skill t)
        {
            _SkillDal.Insert(t);
        }

        public void TDelete(Skill t)
        {
            _SkillDal.Delete(t);
        }

        public List<Skill> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Skill TGetByID(int id)
        {
            return _SkillDal.GetByID(id);
        }

        public List<Skill> TGetList()
        {
            return _SkillDal.GetList();
        }

        public void TUpdate(Skill t)
        {
            _SkillDal.Update(t);
        }
    }
}

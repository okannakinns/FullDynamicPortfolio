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
    public class TestimonialManager : ITestimonialService
    {
        ITestimonialDal _TestimonialDal;

        public TestimonialManager(ITestimonialDal TestimonialDal)
        {
            _TestimonialDal = TestimonialDal;
        }

        public void TAdd(Testimonial t)
        {
            _TestimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            _TestimonialDal.Delete(t);
        }

        public List<Testimonial> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Testimonial TGetByID(int id)
        {
            return _TestimonialDal.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
            return _TestimonialDal.GetList();
        }

        public void TUpdate(Testimonial t)
        {
            _TestimonialDal.Update(t);
        }
    }
}

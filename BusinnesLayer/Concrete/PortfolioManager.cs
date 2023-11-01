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
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _PortfolioDal;

        public PortfolioManager(IPortfolioDal PortfolioDal)
        {
            _PortfolioDal = PortfolioDal;
        }

        public void TAdd(Portfolio t)
        {
            _PortfolioDal.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _PortfolioDal.Delete(t);
        }

        public List<Portfolio> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public Portfolio TGetByID(int id)
        {
            return _PortfolioDal.GetByID(id);
        }

        public List<Portfolio> TGetList()
        {
            return _PortfolioDal.GetList();
        }

        public void TUpdate(Portfolio t)
        {
            _PortfolioDal.Update(t);
        }
    }
}

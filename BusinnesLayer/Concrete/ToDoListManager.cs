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
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _ToDoListDal;

        public ToDoListManager(IToDoListDal ToDoListDal)
        {
            _ToDoListDal = ToDoListDal;
        }

        public void TAdd(ToDoList t)
        {
            _ToDoListDal.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _ToDoListDal.Delete(t);
        }

        public List<ToDoList> TGetByFilter()
        {
            throw new NotImplementedException();
        }

        public ToDoList TGetByID(int id)
        {
            return _ToDoListDal.GetByID(id);
        }

        public List<ToDoList> TGetList()
        {
            return _ToDoListDal.GetList();
        }

        public void TUpdate(ToDoList t)
        {
            _ToDoListDal.Update(t);
        }
    }
}

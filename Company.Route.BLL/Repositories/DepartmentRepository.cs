using Company.Route.BLL.Interfaces;
using Company.Route.DAL.Data.Contexts;
using Company.Route.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private AppDbContext _Context;
        public DepartmentRepository(AppDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<Department> GetAll()
        {
           return _Context.Departments.ToList();
        }
        public Department Get(int? id)
        {
          return  _Context.Departments.FirstOrDefault(D => D.Id == id);
        }
        public int Add(Department entity)
        {
           _Context.Departments.Add(entity);
           return _Context.SaveChanges();
        }
        public int Update(Department entity)
        {
           _Context.Departments.Update(entity);
            return _Context.SaveChanges();
        }

        public int Delete(Department entity)
        {
           _Context.Departments.Remove(entity);
            return _Context.SaveChanges();
        }

       

       

       
    }
}

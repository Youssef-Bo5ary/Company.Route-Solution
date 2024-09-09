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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
       
        
        public EmployeeRepository(AppDbContext context) //ask CLR create object from AppContext
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
           return _context.Employees.ToList();
        }

        public Employee Get(int id)
        {
          return  _context.Employees.Find(id);
        }
        public int Add(Employee entity)
        {
           _context.Employees.Add(entity);
           return _context.SaveChanges();
        }
        public int Update(Employee entity)
        {

            _context.Employees.Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(Employee entity)
        {

            _context.Employees.Remove(entity);
            return _context.SaveChanges();
        }

       

      

       
    }
}

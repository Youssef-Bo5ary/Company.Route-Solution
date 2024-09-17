using Company.Route.BLL.Interfaces;
using Company.Route.BLL.Repositories;
using Company.Route.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _departmentRepository = new DepartmentRepository(context);
            _employeeRepository = new EmployeeRepository(context);
        }

        public IEmployeeRepository EmployeeRepository => _employeeRepository;

        public IDepartmentRepository DepartmentRepository => _departmentRepository;
    }
}

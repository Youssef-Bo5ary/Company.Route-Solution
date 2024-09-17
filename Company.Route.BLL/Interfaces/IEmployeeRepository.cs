﻿using Company.Route.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Route.BLL.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetByName(string name);
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        int Add(Employee entity);
        int Update(Employee entity);
        int Delete(Employee entity);
    }
}

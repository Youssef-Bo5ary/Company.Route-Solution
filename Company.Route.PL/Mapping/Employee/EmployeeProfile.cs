using AutoMapper;
using Company.Route.DAL.Models;
using Company.Route.PL.ViewModels;

namespace Company.Route.PL.Mapping
{
    public class EmployeeProfile : Profile
    {
        //Automatic Mapping
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();//casting from view to model
           // CreateMap<Employee, EmployeeViewModel>();                                     //Reverse Map here cast vice versa also 
        }
    }
}

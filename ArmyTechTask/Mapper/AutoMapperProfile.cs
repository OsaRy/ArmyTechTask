using HR.DomainModels;
using HR.PresentationsModel.Dots.Employee;
using HR.PresentationsModel.Dots.Governorate;
using HR.PresentationsModel.Dots.Neighborhood;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.MVC.Mapper
{
   
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Employee, EmployeeForCreateDto>().ReverseMap();
                CreateMap<Employee, EmployeeForUpdateDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();



            CreateMap<Governorate, GovernorateForCreateDto>().ReverseMap();
                CreateMap<Governorate, GovernorateForUpdateDto>().ReverseMap();
            CreateMap<Governorate, GovernorateDto>().ReverseMap();



            CreateMap<Neighborhood, NeighborhoodForCreateDto>().ReverseMap();
                CreateMap<Neighborhood, NeighborhoodForUpdateDto>().ReverseMap();
            CreateMap<Neighborhood, NeighborhoodDto>().ReverseMap();



        }
    }
     
    
}
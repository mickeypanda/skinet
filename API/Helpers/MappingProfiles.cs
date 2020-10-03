using API.DTOs;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    //THis class is for mapping the properties of enties to DTOs by the use of Automapper
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //This method is for creating the map between objects, from source to destinationas
            CreateMap<Product, ProductToReturnDto>();
        }
    }
}

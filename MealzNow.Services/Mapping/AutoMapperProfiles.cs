using AutoMapper;
using MealzNow.Core;
using MealzNow.Core.Dto;
using MealzNow.Core.RequestModels;
using MealzNow.Db.Models;

namespace MealzNow.Services.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<Category, CategoryDto>();

            CreateMap<Franchise, FranchiseDto>();

            CreateMap<Product, ProductDto>();

            CreateMap<CustomerDto, Customer>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<MealzNowUsers, Customer>();

            CreateMap<Customer, MealzNowUsers>();

            CreateMap<MealzNowUsers, FranchiseUser>();

            CreateMap<FranchiseUser, MealzNowUsers>();

            CreateMap<MealzNowUsers, Client>();

            CreateMap<Client, MealzNowUsers>();

        }

    }
}
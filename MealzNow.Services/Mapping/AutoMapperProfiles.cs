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

            CreateMap<Countries, CountriesDto>();

            CreateMap<Franchise, FranchiseDto>();

            CreateMap<FranchiseDto, Franchise>();

            CreateMap<Packages, PackageDto>();

            CreateMap<PackageDto, Packages>();

            CreateMap<Category, CategoryDto>();

            CreateMap<Category, CategoryOutlineDto>();

            CreateMap<Product, ProductDto>();

            CreateMap<ProductDto, Product>();

            CreateMap<Packages, PackageDto>();

            CreateMap<PackageDto, Packages>();

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
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
            CreateMap<CountriesDto, Countries>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<State, StateDto>();
            CreateMap<StateDto, State>();

            CreateMap<CityName, CityNameDto>();
            CreateMap<CityNameDto, CityName>();

            CreateMap<Franchise, FranchiseDto>();
            CreateMap<FranchiseDto, Franchise>();

            CreateMap<FranchiseTiming, FranchiseTimingDto>();
            CreateMap<FranchiseTimingDto, FranchiseTiming>();

            CreateMap<ServingTimings, ServingTimingsDto>();
            CreateMap<ServingTimingsDto, ServingTimings>();

            CreateMap<ServingTime, ServingTimeDto>();
            CreateMap<ServingTimeDto, ServingTime>();

            CreateMap<FranchiseHoliday, FranchiseHolidayDto>();
            CreateMap<FranchiseHolidayDto, FranchiseHoliday>();

            CreateMap<DishOfDay, DishOfDayDto>();
            CreateMap<DishOfDayDto, DishOfDay>();

            CreateMap<Banner, BannerDto>();
            CreateMap<BannerDto, Banner>();

            CreateMap<FranchiseSettingDto, FranchiseSetting>();
            CreateMap<FranchiseSetting, FranchiseSettingDto>();

            CreateMap<MealsPerDay, MealsPerDayDto>();
            CreateMap<MealsPerDayDto, MealsPerDay>();

            CreateMap<ServingDays, ServingDaysDto>();
            CreateMap<ServingDaysDto, ServingDays>();

            CreateMap<ProductOutline, ProductOutlineDto>();
            CreateMap<ProductOutlineDto, ProductOutline>();

            CreateMap<ProductInclusion, ProductInclusionDto>();
            CreateMap<ProductInclusionDto, ProductInclusion>();

            CreateMap<Packages, PackageDto>();
            CreateMap<PackageDto, Packages>();

            CreateMap<DishOfDay, DishOfDayDto>();
            CreateMap<DishOfDayDto, DishOfDay>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Category, CategoryOutlineDto>();

            CreateMap<SubCategory, SubCategoryDto>();
            CreateMap<SubCategoryDto, SubCategory>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<ProductAllergy, ProductAllergyDto>();
            CreateMap<ProductAllergyDto, ProductAllergy>();

            CreateMap<ProductPrice, ProductPriceDto>();
            CreateMap<ProductPriceDto, ProductPrice>();

            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryDto, ProductCategory>();

            CreateMap<ProductChoices, ProductChoicesDto>();
            CreateMap<ProductChoicesDto, ProductChoices>();

            CreateMap<ProductExtraDipping, ProductExtraDippingDto>();
            CreateMap<ProductExtraDippingDto, ProductExtraDipping>();

            CreateMap<ProductExtraDippingAllergy, ProductExtraDippingAllergyDto>();
            CreateMap<ProductExtraDippingAllergyDto, ProductExtraDippingAllergy>();

            CreateMap<ProductExtraDippingPrice, ProductExtraDippingPriceDto>();
            CreateMap<ProductExtraDippingPriceDto, ProductExtraDippingPrice>();

            CreateMap<ProductExtraTopping, ProductExtraToppingDto>();
            CreateMap<ProductExtraToppingDto, ProductExtraTopping>();

            CreateMap<ProductExtraToppingAllergy, ProductExtraToppingAllergyDto>();
            CreateMap<ProductExtraToppingAllergyDto, ProductExtraToppingAllergy>();

            CreateMap<ProductExtraToppingPrice, ProductExtraToppingPriceDto>();
            CreateMap<ProductExtraToppingPriceDto, ProductExtraToppingPrice>();

            CreateMap<ProductItemOutline, ProductItemOutlineDto>();
            CreateMap<ProductItemOutlineDto, ProductItemOutline>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<MealzNowUsers, Customer>();
            CreateMap<Customer, MealzNowUsers>();

            CreateMap<CustomerAddresses, CustomerAddressDto>();
            CreateMap<CustomerAddressDto, CustomerAddresses>();

            CreateMap<CustomerPackage, CustomerPackageDto>();
            CreateMap<CustomerPackageDto, CustomerPackage>();

            CreateMap<CustomerPayment, CustomerPaymentDto>();
            CreateMap<CustomerPaymentDto, CustomerPayment>();

            CreateMap<CustomerPromo, CustomerPromoDto>();
            CreateMap<CustomerPromoDto, CustomerPromo>();

            CreateMap<CustomerDevice, CustomerDeviceDto>();
            CreateMap<CustomerDeviceDto, CustomerDevice>();

            CreateMap<CustomerPassword, CustomerPasswordDto>();
            CreateMap<CustomerPasswordDto, CustomerPassword>();

            CreateMap<Preference, PreferenceDto>();
            CreateMap<PreferenceDto, Preference>();

            CreateMap<PreferredCategories, PreferredCategoriesDto>();
            CreateMap<PreferredCategoriesDto, PreferredCategories>();

            CreateMap<PreferredSubCategories, PreferredSubCategoriesDto>();
            CreateMap<PreferredSubCategoriesDto, PreferredSubCategories>();

            CreateMap<CustomerProductOutline, CustomerProductOutlineDto>();
            CreateMap<CustomerProductOutlineDto, CustomerProductOutline>();

            CreateMap<CustomerProductInclusion, CustomerProductInclusionDto>();
            CreateMap<CustomerProductInclusionDto, CustomerProductInclusion>();

            CreateMap<MealzNowUsers, FranchiseUser>();
            CreateMap<FranchiseUser, MealzNowUsers>();

            CreateMap<MealzNowUsers, Client>();
            CreateMap<Client, MealzNowUsers>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<CustomerDetails, CustomerDetailsDto>();
            CreateMap<CustomerDetailsDto, CustomerDetails>();

            CreateMap<CustomerAddressDetail, CustomerAddressDetailDto>();
            CreateMap<CustomerAddressDetailDto, CustomerAddressDetail>();

            CreateMap<CustomerOrderedPackage, CustomerOrderedPackageDto>();
            CreateMap<CustomerOrderedPackageDto, CustomerOrderedPackage>();

            CreateMap<CustomerOrderPayment, CustomerOrderPaymentDto>();
            CreateMap<CustomerOrderPaymentDto, CustomerOrderPayment>();

            CreateMap<CustomerOrderPromo, CustomerOrderPromoDto>();
            CreateMap<CustomerOrderPromoDto, CustomerOrderPromo>();

            CreateMap<ProductByDay, ProductByDayDto>();
            CreateMap<ProductByDayDto, ProductByDay>();

            CreateMap<ProductByTiming, ProductByTimingDto>();
            CreateMap<ProductByTimingDto, ProductByTiming>();

            CreateMap<OrderedProductChoices, OrderedProductChoicesDto>();
            CreateMap<OrderedProductChoicesDto, OrderedProductChoices>();

            CreateMap<OrderedProductExtraDipping, OrderedProductExtraDippingDto>();
            CreateMap<OrderedProductExtraDippingDto, OrderedProductExtraDipping>();

            CreateMap<OrderedProductExtraTopping, OrderedProductExtraToppingDto>();
            CreateMap<OrderedProductExtraToppingDto, OrderedProductExtraTopping>();

            CreateMap<OrderedProductSides, OrderedProductSidesDto>();
            CreateMap<OrderedProductSidesDto, OrderedProductSides>();

            CreateMap<OrderedProductDessert, OrderedProductDessertDto>();
            CreateMap<OrderedProductDessertDto, OrderedProductDessert>();

            CreateMap<OrderedProductDrinks, OrderedProductDrinksDto>();
            CreateMap<OrderedProductDrinksDto, OrderedProductDrinks>();


        }

    }
}
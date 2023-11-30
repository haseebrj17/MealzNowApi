using AutoMapper;
using MealzNow.Core.Dto;
using MealzNow.Db.Models;
using MealzNow.Db.Repositories;
using MealzNow.Services.Interfaces;

namespace MealzNow.Services.Services
{
    public class AppService : IAppService
    {
        private readonly IFranchiseRepository _franchiseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBannerRepository _bannerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPackagesRepository _packagesRepository;

        private readonly IMapper _mapper;

        public AppService(IFranchiseRepository franchiseRepository, IBannerRepository bannerRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IProductRepository productRepository, IPackagesRepository packagesRepository)
        {
            _mapper = mapper;
            _franchiseRepository = franchiseRepository;
            _bannerRepository = bannerRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _packagesRepository = packagesRepository;
        }
        public async Task<List<FranchiseDto>> GetClientFranchises(Guid clientId)
        {
            return _mapper.Map<List<Franchise>, List<FranchiseDto>>(await _franchiseRepository.GetClientFranchises(clientId));
        }

        public async Task<HomeDataDto> GetAppHomeData(Guid franchiseId)
        {
            var homeData = new HomeDataDto();

            var franchise = await _franchiseRepository.GetClientFranchises(franchiseId);

            if (franchise != null)
            {
                homeData.FranchiseId = franchiseId;

                var banners = await _bannerRepository.GetFranchiseBanners(franchiseId);
                homeData.Banners = _mapper.Map<List<Banner>, List<BannerDto>>(banners);

                var packages = await _packagesRepository.GetFranchisePackages(franchiseId);
                homeData.Packages = _mapper.Map<List<Packages>, List<PackageDto>>(packages);

                var products = await _productRepository.GetAllProducts(franchiseId);
                homeData.Products = _mapper.Map<List<Product>, List<ProductDto>>(products);

                homeData.Categories = _mapper.Map<List<Category>, List<CategoryDto>>(_categoryRepository.GetFranchiseBrands(franchiseId));

                var allSubCategories = await _categoryRepository.GetAllSubCategories(franchiseId);
                homeData.AllSubCategories = _mapper.Map<List<SubCategory>, List<SubCategoryDto>>(allSubCategories);
            }

            return homeData;
        }
    }
}
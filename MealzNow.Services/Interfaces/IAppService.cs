using MealzNow.Core.Dto;

namespace MealzNow.Services.Interfaces
{
    public interface IAppService
    {
        Task<List<FranchiseDto>> GetClientFranchises(Guid clientId);
        Task<HomeDataDto> GetAppHomeData(Guid franchiseId);
    }
}
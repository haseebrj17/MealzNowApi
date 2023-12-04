using System.Net;
using System.Text.Json;
using MealzNow.Core.RequestModels;
using MealzNow.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MealzNow.MobApi
{
    public class MealzNowMobAppApi
    {
        private readonly ILogger _logger;
        private readonly IAppService _appService;

        public MealzNowMobAppApi(ILoggerFactory loggerFactory, IAppService appService)
        {
            _logger = loggerFactory.CreateLogger<MealzNowMobAppApi>();
            _appService = appService;
        }

        [Function(nameof(GetClientFranchises))]
        public async Task<HttpResponseData> GetClientFranchises([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetClientFranchises funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _appService.GetClientFranchises(request.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }

        [Function(nameof(GetAppDashboardData))]
        public async Task<HttpResponseData> GetAppDashboardData([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            _logger.LogInformation("Calling GetAppDashboardData funtion");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            if (content == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var request = JsonConvert.DeserializeObject<CommonRequest>(content);

            if (request == null)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            if (request.Id == Guid.Empty)
                return req.CreateResponse(HttpStatusCode.BadRequest);

            var data = await _appService.GetAppHomeData(request.Id.Value);

            var response = req.CreateResponse(HttpStatusCode.OK);

            await response.WriteAsJsonAsync(data);

            return response;
        }
    }
}
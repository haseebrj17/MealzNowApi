using System;
namespace MealzNow.Core.RequestModels
{
    public class LoginRequestModel
    {
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
    }
}


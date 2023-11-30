using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Azure.Functions.Worker.Http;
using static MealzNow.Core.Enum.Enums;
using MealzNow.Core;

namespace MealzNow.Services
{
    public interface IJwtTokenManager
    {
        public string GenerateToken(MealzNowUsers user);
        public MealzNowUsers? ValidateToken(HttpRequestData req, List<UserRole> requiredRoles);
    }
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly string JwtValidIssuer = "https://mealznow.azurewebsites.net";
        private readonly string JwtValidAudience = "https://mealznow.azurewebsites.net";
        private readonly string JwtSecret = "5ef415806dc3415aa408416a2baad940";
        public string GenerateToken(MealzNowUsers user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: JwtValidIssuer,
                audience: JwtValidAudience,
                claims: new List<Claim>() {
                    new Claim(nameof(user.Id), (user.Id ?? Guid.NewGuid()).ToString()),
                    new Claim(nameof(user.FullName), user.FullName.ToString()),
                    new Claim(nameof(user.EmailAddress), user.EmailAddress.ToString()),
                    new Claim(nameof(user.ContactNumber), user.ContactNumber.ToString()),
                    new Claim(nameof(user.UserRole), (user.UserRole ?? UserRole.Customer).ToString()),
                    new Claim(nameof(user.FranchiseId), (user.FranchiseId ?? Guid.NewGuid()).ToString()),
                },
                expires: DateTime.Now.AddDays(365),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        public MealzNowUsers? ValidateToken(HttpRequestData req, List<UserRole> requiredRoles)
        {
            var authorizationHeader = req.Headers.FirstOrDefault(h => h.Key == "Authorization");

            if (authorizationHeader.Equals(default(KeyValuePair<string, IEnumerable<string>>)))
            {
                return null;
            }
            if (string.IsNullOrEmpty(authorizationHeader.Value.FirstOrDefault()))
            {
                return null;
            }

            var token = authorizationHeader.Value.First();

            if (token == null)
                return null;

            token = token.Replace("Bearer ", "");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSecret);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                var mealzNowUsers = new MealzNowUsers()
                {
                    Id = new Guid(jwtToken.Claims.First(x => x.Type == nameof(MealzNowUsers.Id)).Value),
                    FranchiseId = new Guid(jwtToken.Claims.First(x => x.Type == nameof(MealzNowUsers.FranchiseId)).Value),
                    ContactNumber = jwtToken.Claims.First(x => x.Type == nameof(MealzNowUsers.ContactNumber)).Value,
                    EmailAddress = jwtToken.Claims.First(x => x.Type == nameof(MealzNowUsers.EmailAddress)).Value,
                    UserRole = Enum.Parse<UserRole>(jwtToken.Claims.First(x => x.Type == nameof(MealzNowUsers.UserRole)).Value),
                    FullName = jwtToken.Claims.First(x => x.Type == nameof(MealzNowUsers.FullName)).Value
                };

                if (requiredRoles.IndexOf(mealzNowUsers.UserRole.Value) < 0)
                {
                    return null;
                }

                return mealzNowUsers;
            }
            catch
            {
                return null;
            }
        }
    }
    public class UnAuthrozedException : Exception
    {
        public UnAuthrozedException() : base() { }

        public override string StackTrace
        {
            get { return "401 Unauthorized Access!"; }
        }
    }
}
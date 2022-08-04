using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;

namespace IdentityServer4Host.IdentityConfiguration
{
    public class Users
    {
        public static List<TestUser> Get()
        {
            var address = new
            {
                street_address = "R. Casillo",
                locality = "Davao City",
                postal_code = 8000,
                country = "Philippines"
            };

            return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "818727",
                        Username = "john",
                        Password = "user",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Role, "User"),
                            new Claim(JwtClaimTypes.Name, "John Doe"),
                            new Claim(JwtClaimTypes.GivenName, "John"),
                            new Claim(JwtClaimTypes.FamilyName, "Doe"),
                            new Claim(JwtClaimTypes.Email, "john@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://john.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "88421113",
                        Username = "kevin",
                        Password = "admin",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Role, "Admin"),
                            new Claim(JwtClaimTypes.Name, "Kevin Doe"),
                            new Claim(JwtClaimTypes.GivenName, "Kevin"),
                            new Claim(JwtClaimTypes.FamilyName, "Doe"),
                            new Claim(JwtClaimTypes.Email, "kevin@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://kevin.com"),
                            new Claim(JwtClaimTypes.Address, JsonSerializer.Serialize(address), IdentityServerConstants.ClaimValueTypes.Json)
                        }
                    }
                };
        }
    }
}

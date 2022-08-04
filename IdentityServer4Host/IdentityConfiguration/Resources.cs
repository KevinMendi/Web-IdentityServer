using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4Host.IdentityConfiguration
{
    public class Resources
    {
        /*~Identity Resources are some standard open id connect scopes, that are unique to a particular user, 
        which you want Identity Server to support.Standard scopes like OpenId, profile & Email 
        and also a custom scope role that holds and returns role claims for the authenticated user.
        Standard scope OpenId needs to be supported if you want to implement OpenID Connect flow 
        for Identity token.*/
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource
                {
                    Name = "role",
                    DisplayName = "Role",
                    UserClaims = { JwtClaimTypes.Role }
                }
            };
        }

        //~API Resources are used to define the API that the identity server is protecting 
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
               new ApiResource
                {
                    Name = "sampleApi",
                    DisplayName = "Sample Api",
                    Description = "Allow the application to access Weather Api on your behalf",
                    Scopes = new List<string> { "sampleApi.read", "sampleApi.write"},
                    ApiSecrets = new List<Secret> {new Secret("PR0V1D3_S0M3_S3CR3T_K3Y".Sha256())},
                    UserClaims = new List<string> {"role"}
                },
                new ApiResource
                {
                    Name = "ContosoUniversityAPI",
                    DisplayName = "Contoso University Api",
                    Description = "Allow the application to access Contoso University Api on your behalf",
                    Scopes = new List<string> { "ContosoUniversityAPI.read", "ContosoUniversityAPI.write"},
                    ApiSecrets = new List<Secret> {new Secret("PR0V1D3_S0M3_S3CR3T_K3Y".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}

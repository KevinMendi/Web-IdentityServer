using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4Host.IdentityConfiguration
{
    public class Scopes
    {
        /*~API Scopes is used to specify what actions authorized user can perform at the level of the API.
        API Scopes can be used to control what scopes on an API are allowed for the authorized user.*/
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("sampleApi.read", "Read Access to Web API"),
                new ApiScope("sampleApi.write", "Write Access to Web API"),
                new ApiScope("ContosoUniversityAPI.read", "Read Access to Contoso University API"),
                new ApiScope("ContosoUniversityAPI.write", "Write Access to Contoso University API"),
            };
        }
    }
}

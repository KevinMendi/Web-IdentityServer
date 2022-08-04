using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4Host.IdentityConfiguration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client>
            {
                //~Client for Machine to Machine Interaction using OAuth2
                new Client
                {
                    ClientId = "sampleApi",
                    ClientName = "Sample ASP.NET Core Web Api",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("PR0V1D3_S0M3_S3CR3T_K3Y".Sha256())},
                    AllowedScopes = new List<string> {"sampleApi.read"}
                },
                //~Client for interactive authentication using OpenID Connect 
                new Client
                {
                    ClientId = "sampleMVCApp",
                    ClientName = "Sample ASP.NET Core MVC Web App",
                    ClientSecrets = new List<Secret> {new Secret("PR0V1D3_S0M3_S3CR3T_K3Y".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:44354/signin-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "sampleApi.read"
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                },
                 new Client
                {
                    ClientId = "ContosoUniversityMVCApp",
                    ClientName = "Contoso University ASP.NET Core MVC Web App",
                    ClientSecrets = new List<Secret> {new Secret("PR0V1D3_S0M3_S3CR3T_K3Y".Sha256())},
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris = { "https://localhost:44354/signin-oidc" },
                     FrontChannelLogoutUri = "https://localhost:44354/signout-oidc",
                     PostLogoutRedirectUris = { "https://localhost:44354/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "ContosoUniversityAPI.read"
                    },
                }
            };
        }
    }
}

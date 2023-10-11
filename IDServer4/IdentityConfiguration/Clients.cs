using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace Library.IDServer4.IdentityConfiguration
{
    public class Clients
    {
        public static IEnumerable<Client> Get()
        {

            return new List<Client>
            {
                new Client
                {
                    ClientId = "webAPIClient",
                    ClientName = "The web API client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret> {new Secret("JLibrary".Sha256())},
                    AllowedScopes = new List<string> {"read"}
                },
                new Client
                {
                    ClientId = "webAppClient",
                    ClientName = "Clients of the web app mostly customers",
                    ClientSecrets = new List<Secret> {new Secret("JLibrary".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = new List<string> {"https://localhost:44346/signin-oidc"},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        "read"
                    },

                    RequirePkce = true,
                    AllowPlainTextPkce = false
                }
            };
        }
    }
}

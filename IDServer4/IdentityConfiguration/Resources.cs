using IdentityServer4.Models;
using System.Collections.Generic;

namespace Library.IDServer4.IdentityConfiguration
{
    public class Resources
    {
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
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "webAPIClient",
                    DisplayName = "Library API",
                    Description = "Allow the application to access the Library API on your behalf",
                    Scopes = new List<string> { "admin", "read", "write"},
                    ApiSecrets = new List<Secret> {new Secret("JLibrary".Sha256())},
                    UserClaims = new List<string> {"role"}
                }
            };
        }
    }
}

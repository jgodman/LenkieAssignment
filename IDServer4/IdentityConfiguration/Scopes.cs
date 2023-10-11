using IdentityServer4.Models;
using System.Collections.Generic;

namespace Library.IDServer4.IdentityConfiguration
{
    public class Scopes
    {
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new[]
            {
                new ApiScope("admin", "Admin Access to Library API"),
                new ApiScope("read", "Read Access to Library API"),
                new ApiScope("write", "Write Access to Library API"),
            };
        }
    }
}

﻿using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using static System.Net.WebRequestMethods;

namespace Adek.IDP;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
			 
		};

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
            { };

    public static IEnumerable<Client> Clients =>
        new Client[] 
            {
                new Client { 
                    ClientName ="Image Gallery", 
                    ClientId="imagegalleryclient",
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = {
						"https://localhost:7184/signin-oidc"
					},
                    AllowedScopes = { 
                        IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile,
					},
                    ClientSecrets = { 
                        new Secret("Secret".Sha256())
                    }
                }
            };
}
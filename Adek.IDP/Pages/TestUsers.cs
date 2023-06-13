// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Duende.IdentityServer;
using Duende.IdentityServer.Test;

namespace Adek.IDP;

public class TestUsers
{
    public static List<TestUser> Users
    {
        get
        {
          
                
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "af29f5c8-2845-4150-9566-226e8109a4dc",
                    Username = "David",
                    Password = "David",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Flag"),
                        new Claim(JwtClaimTypes.GivenName, "David")
                        
                    }
                },
                new TestUser
                {
                    SubjectId = "11b397d3-ae9d-444d-88d0-eb863845e390",
                    Username = "Emma",
                    Password = "Emma",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.FamilyName, "Flag"),
                        new Claim(JwtClaimTypes.GivenName, "Emma")
                       
                    }
                }
            };
        }
    }
}
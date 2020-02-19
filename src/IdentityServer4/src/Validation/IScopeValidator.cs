// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityServer4.Validation
{
    public interface IScopeValidator
    {
        bool ContainsApiResourceScopes { get; }
        bool ContainsOfflineAccessScope { get; }
        bool ContainsOpenIdScopes { get; }
        Resources GrantedResources { get; }
        Resources RequestedResources { get; }

        Task<bool> AreScopesAllowedAsync(Client client, IEnumerable<string> requestedScopes);
        Task<bool> AreScopesValidAsync(IEnumerable<string> requestedScopes, bool filterIdentityScopes = false);
        bool IsResponseTypeValid(string responseType);
        void SetConsentedScopes(IEnumerable<string> consentedScopes);
        bool ValidateRequiredScopes(IEnumerable<string> consentedScopes);
    }
}
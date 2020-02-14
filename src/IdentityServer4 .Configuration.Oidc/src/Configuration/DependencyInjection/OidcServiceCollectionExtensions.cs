// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// DI extension methods for adding IdentityServer
    /// </summary>
    public static class OidcServiceCollectionExtensions
    {
        /// <summary>
        /// Configures the OpenIdConnect handlers to persist the state parameter into the server-side IDistributedCache.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="schemes">The schemes to configure. If none provided, then all OpenIdConnect schemes will use the cache.</param>
        public static IServiceCollection AddOidcStateDataFormatterCache(this IServiceCollection services, params string[] schemes)
        {
            services.AddSingleton<IPostConfigureOptions<OpenIdConnectOptions>>(
                svcs => new ConfigureOpenIdConnectOptions(
                    schemes,
                    svcs.GetRequiredService<IHttpContextAccessor>())
            );

            return services;
        }
    }
}
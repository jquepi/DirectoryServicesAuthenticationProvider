﻿using System;
using Nancy;
using Octopus.Node.Extensibility.Authentication.DirectoryServices.Configuration;
using Octopus.Server.Extensibility.Authentication.DirectoryServices.Web;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api;

namespace Octopus.Server.Extensibility.Authentication.DirectoryServices
{
    public class DirectoryServicesApi : NancyModule
    {
        public const string ApiExternalGroupsSearch = "/api/externalgroups/directoryServices{?partialName}";
        public const string ApiExternalUsersSearch = "/api/externalusers/directoryServices{?partialName}";

        public DirectoryServicesApi(
            Func<SecuredActionInvoker<ListSecurityGroupsAction, IDirectoryServicesConfigurationStore>> listSecurityGroupsActionInvokerFactory,
            Func<SecuredActionInvoker<UserLookupAction, IDirectoryServicesConfigurationStore>> userLookupActionInvokerFactory)
        {
            Get[ApiExternalGroupsSearch] = o => listSecurityGroupsActionInvokerFactory().Execute(Context, Response);
            Get[ApiExternalUsersSearch] = o => userLookupActionInvokerFactory().Execute(Context, Response);
        }
    }
}
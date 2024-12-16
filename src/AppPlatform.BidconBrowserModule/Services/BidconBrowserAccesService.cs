﻿using AppPlatform.BidconBrowserModule.Models;
using AppPlatform.Core.Abstractions;
using AppPlatform.Core.Extensions;
using AppPlatform.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AppPlatform.BidconBrowserModule.Services;
internal class BidconBrowserAccesService(IBidconAccess bidconAccess, IDbContextFactory<ApplicationDbContext> DbContextFactory) : IBidconBrowserAccesService
{
    public async Task<TreeItem> GetTreeItemRootAsync(ClaimsPrincipal userClaims)
    {
        using var context = await DbContextFactory.CreateDbContextAsync();
        var credentials = await context.BidconAccessCredentials.Where(x => x.TenantId == userClaims.GetTenantId()).FirstOrDefaultAsync();
        if(credentials == null)
        {
            throw new Exception("No credentials found for user");
        }
        if(credentials.UseDesktopBidconLink)
        {
            throw new Exception("Desktop bidcon link is not supported");
        }
        var folder = await bidconAccess.GetFolderRootAsync(userClaims);
        return new TreeItem(folder);
    }
}

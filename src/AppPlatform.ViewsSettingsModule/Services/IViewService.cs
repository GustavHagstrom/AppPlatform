﻿using AppPlatform.Core.Enteties.EstimationView;
using System.Security.Claims;

namespace AppPlatform.ViewSettingsModule.Services;
internal interface IViewService
{
    Task GetAsync(string viewId);
    Task GetAllAsync(ClaimsPrincipal userClaims);
    Task UpdateAsync(View view);
    Task DeleteAsync(View view);
    Task CreateAsync(ClaimsPrincipal userClaims, View view);
    Task<List<View>> GetViewListAsync(ClaimsPrincipal UserClaims);
}

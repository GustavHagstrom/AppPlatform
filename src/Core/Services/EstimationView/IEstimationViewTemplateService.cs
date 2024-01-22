﻿using AppPlatform.Core.DTOs.EstimationView;

namespace AppPlatform.Core.Services.EstimationView;
public interface IEstimationViewTemplateService
{
    Task DeleteAsync(Guid id, string organizationId);
    Task<IEnumerable<EstimationViewTemplateDto>?> GetAllAsDeepListAsync(string organizationId);
    Task<IEnumerable<EstimationViewTemplateDto>?> GetAllAsShallowListAsync(string organizationId);
    Task<EstimationViewTemplateDto?> GetSingleDeepAsync(Guid id, string organizationId);
    Task UpsertAsync(EstimationViewTemplateDto dto, string organizationId);
}
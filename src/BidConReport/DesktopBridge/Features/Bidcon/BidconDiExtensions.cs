using BidConReport.DesktopBridge.Features.Bidcon.Factories;
using BidConReport.DesktopBridge.Features.Bidcon.RulesEngine;
using BidConReport.DesktopBridge.Features.Bidcon.Services;

namespace BidConReport.DesktopBridge.Features.Bidcon;

public static class BidconDiExtensions
{
    public static void UseBidconFeature(this IServiceCollection services)
    {
        services.AddSingleton<IBidConImporter, BidConImporter>();
        services.AddTransient<IBidconDataConverter, BidconDataConverter>();
        services.AddTransient<IEstimationItemRulesEngine, EstimationItemRulesEngine>();
        services.AddTransient<IEstimationFactory, EstimationFactory>();
        services.AddTransient<IBidConConfigProvider, BidConConfigProvider>();
    }
}

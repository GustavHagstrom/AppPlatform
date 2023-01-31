using DesktopBridge.Features.Bidcon.Factories;
using DesktopBridge.Features.Bidcon.RulesEngine;
using DesktopBridge.Features.Bidcon.Services;

namespace DesktopBridge.Features.Bidcon;

public static class BidconDiExtensions
{
    public static void UseBidconFeature(this IServiceCollection services)
    {
        services.AddSingleton<IBidConImporter, BidConImporter>();
        services.AddTransient<IBidConModelSimpliefier, BidConModelSimpliefier>();
        services.AddTransient<IEstimationItemRulesEngine, EstimationItemRulesEngine>();
        services.AddTransient<ISimpleEstimationFactory, SimpleEstimationFactory>();
        services.AddTransient<IBidConConfigProvider, BidConConfigProvider>();
    }
}

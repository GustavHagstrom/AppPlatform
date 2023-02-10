using BidConReport.Shared.ExportPresentation.Files.Excel.Builders;
using Microsoft.Extensions.DependencyInjection;

namespace BidConReport.Shared.Extensions;
public static class DependencyInjection
{
    private const string SyncFusionLicenseKey = "Mgo+DSMBaFt/QHNqVVhkW1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF9iSH5QdkFmWn1bcXZdTg==;Mgo+DSMBPh8sVXJ0S0V+XE9AcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3xSd0VgWXtbc3ZQR2lUWQ==;ORg4AjUWIQA/Gnt2VVhjQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRd0RjWn9adXdXQ2JUVkw=;NzUzMzkyQDMyMzAyZTMzMmUzMGNMbUhEdWZvMFJnWERXb0J4aG45cVlkN0hFaitwT0EzV2pKV3ZxYzJPZEU9;NzUzMzkzQDMyMzAyZTMzMmUzMGt3MCtQaXc2T2dGZ0JYRWIvS242WlJtYUxScXZBNktyNmVDaXBrNmpvdW89;NRAiBiAaIQQuGjN/V0Z+X09EaFtFVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdERiWXxedHFWRGVaVEd3;NzUzMzk1QDMyMzAyZTMzMmUzMEtnckppQnhFS3dybUFFYjNvTGoybHhianF5QzBxaDhMWnRGSHZkb3VHYUk9;NzUzMzk2QDMyMzAyZTMzMmUzME9IZmNtdGhZK25EcjJhR01zVUNtOE80SkJJS0UvV25FYzVyWkkzUm9xRFE9;Mgo+DSMBMAY9C3t2VVhjQlFaclhJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxRd0RjWn9adXdXQ2heUEU=;NzUzMzk4QDMyMzAyZTMzMmUzMEFCTCt1MVZNcnlqa3krcmxLdHBZdUVmd0dLQklVSU5lRWVBL2RHbVRZMVk9;NzUzMzk5QDMyMzAyZTMzMmUzMElFdEZ0Y2FYNGVibm1IRk5NeWZ0VFpzeDVCTTMyUWFLRmI5N21wVUJhMlU9;NzUzNDAwQDMyMzAyZTMzMmUzMEtnckppQnhFS3dybUFFYjNvTGoybHhianF5QzBxaDhMWnRGSHZkb3VHYUk9";
    public static IServiceCollection AddSharedLibrary(this IServiceCollection services)
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(SyncFusionLicenseKey);
        AddExcelServices(services);
        return services;
    }

    private static void AddExcelServices(IServiceCollection services)
    {
        services.AddTransient<IExcelFileBuilder, ExcelFileBuilder>();
        services.AddTransient<IExcelHeaderBuilder, ExcelHeaderBuilder>();
        services.AddTransient<IExcelTitleBuilder, ExcelTitleBuilder>();
        services.AddTransient<IExcelGeneralInformationBuilder, ExcelGeneralInformationBuilder>();
        services.AddTransient<IExcelPriceBuilder, ExcelPriceBuilder>();
        services.AddTransient<IExcelTableBuilder, ExcelTableBuilder>();
    }
}

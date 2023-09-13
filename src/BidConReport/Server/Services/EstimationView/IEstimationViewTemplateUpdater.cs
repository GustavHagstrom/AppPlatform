using BidConReport.Server.Enteties.EstimationView;

namespace BidConReport.Server.Services.EstimationView;
public interface IEstimationViewTemplateUpdater
{
    void Update(EstimationViewTemplate existing, EstimationViewTemplate updateSrc);
}
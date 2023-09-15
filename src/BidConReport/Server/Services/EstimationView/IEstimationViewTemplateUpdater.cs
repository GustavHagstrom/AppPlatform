using Server.Enteties.EstimationView;

namespace Server.Services.EstimationView;
public interface IEstimationViewTemplateUpdater
{
    void Update(EstimationViewTemplate existing, EstimationViewTemplate updateSrc);
}
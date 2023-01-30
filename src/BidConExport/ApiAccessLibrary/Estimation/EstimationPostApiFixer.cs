using SharedLibrary.Models;

namespace ApiAccessLibrary.Estimation;
public static class EstimationPostApiFixer
{
    public static void FixParentReferences(SimpleEstimation simpleEstimation)
    {
        FixRecursivly(simpleEstimation.Items);
    }
    private static void FixRecursivly(IEnumerable<SimpleEstimationItem> items, SimpleEstimationItem? parent = null)
    {
        foreach (var item in items)
        {
            item.Parent = parent;
            FixRecursivly(item.Items, item);
        }
    }
}

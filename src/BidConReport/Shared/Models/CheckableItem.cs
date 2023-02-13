namespace BidConReport.Shared.Models;
public class CheckableItem<T>
{
    public CheckableItem(bool isChecked, T item)
    {
        IsChecked = isChecked;
        Item = item;
    }

    public bool IsChecked { get; set; }
    public T Item { get; set; }
}

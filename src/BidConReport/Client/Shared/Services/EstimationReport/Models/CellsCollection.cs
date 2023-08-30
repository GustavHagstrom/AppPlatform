namespace BidConReport.Client.Shared.Services.EstimationReport.Models;

public class CellsCollection
{
    private Cell[,] _cells;
    public CellsCollection(int rows, int columns)
    {
        _cells = new Cell[rows, columns];
    }
    public Cell this[int column, int row]
    {
        get
        {
            var cell = _cells[column, row];
            return cell ?? (_cells[column, row] = new());
        }

        set => _cells[column, row] = value;
    }
}

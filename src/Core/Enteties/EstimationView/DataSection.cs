using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace AppPlatform.Core.Enteties.EstimationView;

public class DataSection : IViewEntity, ISection
{
    public DataSection()
    {
        AddColumn();
        AddRow();
        Cells = new List<DataCell>();
    }
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50)]
    public string Name { get; set; } = "DataSection";
    public int Order { get; set; }
    public List<DataRow> Rows { get; set; } = new();
    public List<DataColumn> Columns { get; set; } = new();

    [NotMapped]
    public int RowCount => Rows.Count;
    [NotMapped]
    public int ColumnCount => Columns.Count;
    public bool IsFooter { get; set; } = false;
    public bool IsHeader { get; set; } = false;
    public List<DataCell> Cells { get; set; }



    [StringLength(50)]
    public string ViewId { get; set; } = string.Empty;
    public View? View { get; set; }


    public void AddRow()
    {
        Rows.Add(new DataRow
        {
            DataSectionId = Id,
            DataSection = this,
            Order = Rows.Count + 1
        });
    }
    public void AddColumn()
    {
        Columns.Add(new DataColumn
        {
            DataSectionId = Id,
            DataSection = this,
            Order = Columns.Count + 1
        });
    }
}

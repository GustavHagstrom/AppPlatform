﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BidConReport.Shared.Models;
public class EstimationItem
{
    public required Guid Id { get; set; }
    [NotMapped]
    public EstimationItem? Parent { get; set; }
    public required int RowNumber { get; set; }
    public int? ChangedToRowNumber { get; set; }
    public required EstimationItemType ItemType { get; set; }
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(10)]
    public required string Unit { get; set; }
    [MaxLength(10)]
    public required string DisplayedUnit { get; set; }
    public required double Quantity { get; set; }
    public required string DisplayedQuantity { get; set; }
    public required double UnitCost { get; set; }
    [MaxLength(1000)]
    public required string Comment { get; set; }
    public required ICollection<string> Tags { get; set; }
    public required ICollection<EstimationItem> Items { get; set; }


    public override string ToString()
    {
        return $"{RowNumber} - {Name}";
    }

}

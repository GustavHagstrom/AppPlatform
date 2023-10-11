﻿using SharedLibrary.Enums.BidconAccess;
using System.Text.Json;

namespace Client.Shared.EstimationViewTemplate.Models;

public class SheetSection : IViewSection
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public SheetType SheetType { get; set; }
    public List<SheetColumn> Columns { get; set; } = new();

    public SheetSection Clone()
    {
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<SheetSection>(json)!;
    }
}
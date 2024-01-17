﻿using System.Text.Json;

namespace Server.EstimationViewTemplate_old.Models;

public class DataSection : IViewSection
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public List<DataColumn> Columns { get; } = new();
    public int RowCount { get; set; }

    public DataSection Clone()
    {
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<DataSection>(json)!;
    }
}
﻿using AppPlatform.Core.Enums.BidconAccess;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;

public class SheetSection : IViewEntity, ISection
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public int Order { get; set; }
    public SheetType SheetType { get; set; }



    public List<SheetColumn> Columns { get; set; } = new();
    [StringLength(450)]
    public string ViewId { get; set; } = string.Empty;
    public View? View { get; set; }
}

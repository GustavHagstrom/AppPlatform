﻿using AppPlatform.Core.Enteties.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace AppPlatform.Core.Enteties.EstimationView;
public class View : IViewEntity, ITenantEntety
{
    [StringLength(50)]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    public List<DataSection> DataSections { get; set; } = new();
    public List<SheetSection> SheetSections { get; set; } = new();
    [StringLength(50)]
    public string FontFamily { get; set; } = "Calibri";
    public bool AllowChanges { get; set; } = true;
    public List<Tag> Tags { get; set; } = new();
    [StringLength(50)]
    public string TenantId { get; set; } = string.Empty;

    public void AddEmptyDataSection()
    {
        DataSections.Add(new DataSection
        {
            ViewId = Id,
            View = this
        });
    }
    public void AddEmptySheetSection()
    {
        SheetSections.Add(new SheetSection
        {
            ViewId = Id,
            View = this
        });
    }
    public IEnumerable<ISection> SectionsInOrder()
    {
        return DataSections.Cast<ISection>().Concat(SheetSections.Cast<ISection>()).OrderBy(s => s.Order);
    }
}

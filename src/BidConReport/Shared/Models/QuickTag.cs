﻿using System.ComponentModel.DataAnnotations;

namespace BidConReport.Shared.Models;
public class QuickTag
{
    public required int Id { get; set; }
    [MaxLength(30)]
    public required string Value { get; set; }
}
﻿namespace SharedPlatformLibrary.DTOs;
public class OrganizationDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public override string ToString()
    {
        return Name;
    }
}
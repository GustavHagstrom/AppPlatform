﻿using BidConReport.Shared.DTOs.BidconAccess;

namespace BidconLink.Services;

public interface IConnectionstringService
{
    string Build(BC_DatabaseCredentialsDto credentials);
}
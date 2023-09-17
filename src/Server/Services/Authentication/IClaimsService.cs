﻿using SharedLibrary.DTOs;

namespace Server.Services.Authentication;
public interface IClaimsService
{
    /// <summary>
    /// Creates and returns the claims for the provided user. 
    /// Applicationrights are provided as a single string with int values joined by a "," char
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<ICollection<ClaimDto>> GetClaimsAsync(string userId);
}
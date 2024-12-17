﻿using AppPlatform.Data.MongoDb.Enteties.Abstractions;
using MongoDB.Bson;

namespace AppPlatform.Data.MongoDb.Enteties.Authorization;
public class UserRole : IUserEntety
{
    public ObjectId _id;
    public string UserId { get; set; } = string.Empty;
    public string RoleId { get; set; } = string.Empty;

}

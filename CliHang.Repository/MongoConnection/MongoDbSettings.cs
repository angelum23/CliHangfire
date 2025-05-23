﻿using System.Text.Json.Serialization;

namespace CliHang.Repository;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}
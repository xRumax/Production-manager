using System;
using System.Collections.Generic;

namespace EndLand.Data.Models;

public partial class Incident
{
    public string Imei { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string ProjectName { get; set; } = null!;

    public string OrderNumber { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Exception { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}

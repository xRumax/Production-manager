using System;
using System.Collections.Generic;

namespace EndLand.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string PinCode { get; set; } = null!;
}

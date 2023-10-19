using System;
using System.Collections.Generic;

namespace EntityFrameworkCore.Data.ScaffoldModels;

public partial class Group
{
    public long GroupId { get; set; }

    public string Name { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace ContactAPI.Models;

public partial class ContactListTable
{
    public string ContactName { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public string? ContactRemarks { get; set; }
}

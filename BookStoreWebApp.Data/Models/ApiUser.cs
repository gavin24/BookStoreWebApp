using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Data.Models;

public partial class ApiUser
{
    public long Id { get; set; }

    public string? EmailAddress { get; set; }

    public string? Password { get; set; }

    public long? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}

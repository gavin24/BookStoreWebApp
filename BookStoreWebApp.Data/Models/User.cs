using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Data.Models;

public partial class User
{
    public long Id { get; set; }

    public string? EmailAddress { get; set; }

    public string? Password { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}

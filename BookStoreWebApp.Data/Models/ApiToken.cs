using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Data.Models;

public partial class ApiToken
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public string? TokenValue { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? ExpirationDate { get; set; }
}

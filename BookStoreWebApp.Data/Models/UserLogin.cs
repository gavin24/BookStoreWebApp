using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Data.Models;

public partial class UserLogin
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? TokenValue { get; set; }
}

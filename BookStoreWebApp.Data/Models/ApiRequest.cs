using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Data.Models;

public partial class ApiRequest
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public string? IpAddress { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ControllerName { get; set; }

    public string? ApiPath { get; set; }
}

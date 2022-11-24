using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Data.Models;

public partial class Book
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? PurchasePrice { get; set; }

    public string? Category { get; set; }

    public string? Author { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }
}

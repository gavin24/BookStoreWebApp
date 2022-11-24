using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Data.Models;

public partial class BookSubscription
{
    public long Id { get; set; }

    public long? BookId { get; set; }

    public DateTime? DateCreated { get; set; }

    public long? DateModified { get; set; }

    public int? NumberOfSubscriptions { get; set; }
}

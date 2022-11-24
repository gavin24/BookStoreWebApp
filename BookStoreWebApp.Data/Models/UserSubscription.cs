using System;
using System.Collections.Generic;

namespace BookStoreWebApp.Data.Models;

public partial class UserSubscription
{
    public long Id { get; set; }

    public long? BookId { get; set; }

    public bool? IsSubscribed { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public long? UserId { get; set; }
}

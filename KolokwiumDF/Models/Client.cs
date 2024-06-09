using System;
using System.Collections.Generic;

namespace KolokwiumDF.Models;

public partial class Client
{
    public int IdClient { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}

using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class EventSubscription
{
    public int IdSubscription { get; set; }

    public int IdUser { get; set; }

    public int IdEvent { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

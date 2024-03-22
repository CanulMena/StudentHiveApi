using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Event
{
    public int IdEvent { get; set; }

    public string EventType { get; set; } = null!;

    public virtual ICollection<EventSubscription> EventSubscriptions { get; set; } = new List<EventSubscription>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}

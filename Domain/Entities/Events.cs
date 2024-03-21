using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Event
{
    public int IdEvent { get; set; }

    public string EventType { get; set; } = null!;

    public virtual ICollection<EventSubscription> EventSubscription { get; set; } = new List<EventSubscription>();

    public virtual ICollection<Notification> Notification { get; set; } = new List<Notification>();

    public virtual ICollection<Request> Request { get; set; } = new List<Request>();
}

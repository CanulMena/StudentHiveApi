using System;
using System.Collections.Generic;

namespace StudentHive.Domain.Entities;

public partial class Notification
{
    public int IdNotification { get; set; }

    public int IdEvent { get; set; }

    public int IdUser { get; set; }

    public string Message { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}

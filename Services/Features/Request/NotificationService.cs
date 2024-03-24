using StudentHive.Services.Features.Users;

public interface INotificationService
{
    Task SendNotification(int userId, string message);
}

public class NotificationService : INotificationService
{
    private readonly UsersService _userService;

    public NotificationService(UsersService userService)
    {
        _userService = userService;
    }

    public async Task SendNotification(int userId, string message)
    {
        var user = await _userService.GetById(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }

        // Aquí es donde realmente enviarías la notificación.
        // Esto dependerá de cómo quieras enviar las notificaciones (por ejemplo, por correo electrónico, SMS, notificaciones push, etc.).
        // Por ahora, solo vamos a imprimir el mensaje en la consola.
        Console.WriteLine($"Sending notification to user {user.IdUser}: {message}");
    }
}
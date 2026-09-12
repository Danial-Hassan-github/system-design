using Microsoft.AspNetCore.SignalR;

namespace SystemDesign.NotificationService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHubContext<NotificationHub> _notificationHub;

        public Worker(
            ILogger<Worker> logger,
            IHubContext<NotificationHub> notificationHub)
        {
            _logger = logger;
            _notificationHub = notificationHub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation(
                        "Notification worker running at: {time}",
                        DateTimeOffset.Now);

                    string title = "New Notification";
                    string message = "This is a test notification.";

                    await _notificationHub.Clients.All.SendAsync(
                        "ReceiveNotification",
                        title,
                        message,
                        stoppingToken);

                    _logger.LogInformation(
                        "Notification sent: {title}",
                        title);

                    await Task.Delay(4000, stoppingToken);
                }
                catch (OperationCanceledException)
                    when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Error sending notification");
                }
            }
        }
    }
}
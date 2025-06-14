using Microsoft.Extensions.Hosting;

public class FileWatcherHostedService : IHostedService, IDisposable
{
    private readonly FileWatcherService _watcherService;

    public FileWatcherHostedService(FileWatcherService watcherService)
    {
        _watcherService = watcherService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _watcherService.StartWatching("Uploads");
        Console.WriteLine("FileWatcher started.");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _watcherService.StopWatching();
        Console.WriteLine("FileWatcher stopped.");
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _watcherService.StopWatching();
    }
}

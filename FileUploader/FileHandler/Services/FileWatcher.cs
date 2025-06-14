public class FileWatcherService
{
    private readonly IFileEventBus _eventBus;
    private FileSystemWatcher? _watcher;

    public FileWatcherService(IFileEventBus eventBus)
    {
        _eventBus = eventBus;
    }


   
    public void StartWatching(string path)
{
    if (!Directory.Exists(path))
        Directory.CreateDirectory(path);

    var fullPath = Path.GetFullPath(path);
    Console.WriteLine($"[Watcher] Monitoring folder: {fullPath}");
   


    _watcher = new FileSystemWatcher(fullPath)
    {
        EnableRaisingEvents = true,
        Filter = "*.txt"
    };

    _watcher.Created += (s, e) =>
    {
        Console.WriteLine($"[Watcher] File created: {e.FullPath}");
        Task.Delay(500).Wait();
        _eventBus.RaiseFileDetected(e.FullPath);
    };
}


    public void StopWatching()
    {
        if (_watcher != null)
        {
            _watcher.EnableRaisingEvents = false;
            _watcher.Dispose();
        }
    }
}



public class FileHandlers
{
    private readonly IFileEventBus _eventBus;
    private readonly ILogger<FileHandlers> _logger;

    public FileHandlers(IFileEventBus eventBus,ILogger<FileHandlers>logger)
    {
        _eventBus = eventBus;
        _logger = logger;
        _eventBus.FileDetected += HandleFile;
        _eventBus.FileProcessed += OnFileProcessed;
        _eventBus.FileFailed += OnFileFailed;
    }

    private void HandleFile(object? sender, FileDetectedEventArgs e)
    {
        try
        {
            var newPath = Path.ChangeExtension(e.FilePath, ".processed.txt");

            const int maxRetries = 3;
            int retryCount = 0;
            bool moved = false;

            while (!moved && retryCount < maxRetries)
            {
                try
                {
                    _logger.LogInformation(" Processing file: {File}", newPath);
                    // If target file exists, delete it before move
                    if (File.Exists(newPath))
                    {
                        File.Delete(newPath);
                    }

                    File.Move(e.FilePath, newPath);
                    moved = true;
                }
                catch (IOException ioEx)
                {
                    retryCount++;
                    if (retryCount >= maxRetries)
                    {
                        // Raise failure event and log error if final attempt fails
                        _eventBus.RaiseFileFailed(e.FilePath, ioEx);
                         _logger.LogError(ioEx, "Failed processing {File}", newPath);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($" Failed to move file after {maxRetries} attempts: {e.FilePath}");
                        Console.WriteLine($"   Error: {ioEx.Message}");
                        Console.ResetColor();
                        return; // Exit after failure
                    }
                    else
                    {
                        // Wait before retrying
                        Task.Delay(500).Wait();
                    }
                }
            }

            // If moved successfully, raise success event
            _eventBus.RaiseFileProcessed(newPath, "Valid");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"File processed successfully: {newPath}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            // Catch any other exceptions, raise failure event and log
            _eventBus.RaiseFileFailed(e.FilePath, ex);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($" Unexpected error processing file: {e.FilePath}");
            Console.WriteLine($" Error: {ex.Message}");
            Console.ResetColor();
        }
    }


 
    private void OnFileProcessed(object? sender, FileProcessedEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" File processed: {e.FilePath} → Result: {e.Result}");
        Console.ResetColor();
    }

    private void OnFileFailed(object? sender, FileFailedEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($" File failed: {e.FilePath}");
        Console.WriteLine($"   Error: {e.Error.Message}");
        Console.ResetColor();
    }

}
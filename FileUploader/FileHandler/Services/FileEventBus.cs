// EventArgs classes
public class FileDetectedEventArgs : EventArgs
{
    public string FilePath { get; }
    public FileDetectedEventArgs(string filePath) => FilePath = filePath;
}

public class FileProcessedEventArgs : EventArgs
{
    public string FilePath { get; }
    public string Result { get; }
    public FileProcessedEventArgs(string filePath, string result)
    {
        FilePath = filePath;
        Result = result;
    }
}

public class FileFailedEventArgs : EventArgs
{
    public string FilePath { get; }
    public Exception Error { get; }
    public FileFailedEventArgs(string filePath, Exception error)
    {
        FilePath = filePath;
        Error = error;
    }
}

// Event bus interface
public interface IFileEventBus
{
    event EventHandler<FileDetectedEventArgs> FileDetected;
    event EventHandler<FileProcessedEventArgs> FileProcessed;
    event EventHandler<FileFailedEventArgs> FileFailed;

    void RaiseFileDetected(string filePath);
    void RaiseFileProcessed(string filePath, string result);
    void RaiseFileFailed(string filePath, Exception ex);
}

// Event bus implementation
public class FileEventBus : IFileEventBus
{
    public event EventHandler<FileDetectedEventArgs>? FileDetected;
    public event EventHandler<FileProcessedEventArgs>? FileProcessed;
    public event EventHandler<FileFailedEventArgs>? FileFailed;

    public void RaiseFileDetected(string filePath)
    {
        FileDetected?.Invoke(this, new FileDetectedEventArgs(filePath));
    }

    public void RaiseFileProcessed(string filePath, string result)
    {
        FileProcessed?.Invoke(this, new FileProcessedEventArgs(filePath, result));
    }

    public void RaiseFileFailed(string filePath, Exception ex)
    {
        FileFailed?.Invoke(this, new FileFailedEventArgs(filePath, ex));
    }
}

using RSAEncryption.Contracts;

namespace RSAEncryption.Entities;

public class RSALogger : ILogger, IDisposable
{
    private readonly StreamWriter _streamWriter;

    public RSALogger(StreamWriter streamWriter)
    {
        _streamWriter = streamWriter;
    }

    public void Dispose()
    {
        if (_streamWriter != null)
            _streamWriter.Dispose();
    }

    public void Log(string message)
    {
        _streamWriter.WriteLine(message);
    }
}

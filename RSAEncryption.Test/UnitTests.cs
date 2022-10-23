using RSAEncryption.UI;

namespace RSAEncryption.Test;

public class Tests
{
    private RSAProvider _rsaProvider;
    private IEnumerable<string> _text;

    [SetUp]
    public void Setup()
    {
        _rsaProvider = new RSAProvider();
    }

    [Test]
    public void Encryption()
    {
        Setup();
        Encrypt();

        Assert.NotNull(_rsaProvider.GetResult());
        Assert.IsNotEmpty(_rsaProvider.GetResult());
    }

    [Test]
    public void Decryption()
    {
        Setup();
        _text = Encrypt();

        _rsaProvider.DecryptText(_text);
        _text = _rsaProvider.GetResult();

        Assert.NotNull(_rsaProvider.GetResult());
        Assert.IsNotEmpty(_rsaProvider.GetResult());
    }

    private IEnumerable<string> Encrypt()
    {
        _rsaProvider.EncryptText("t.me/xvskilledhimself");
        Console.WriteLine(_rsaProvider.GetResult());
        return _rsaProvider.GetResult();
    }

}
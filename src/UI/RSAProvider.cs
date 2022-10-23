using RSAEncryption.Entities;
using RSAEncryption.Models;

namespace RSAEncryption.UI;

public class RSAProvider
{
    public const int DefaultRange = 1_000;
    private readonly RSA rsa;
    private ModuloNumber? _moduloNumber;
    private PrivateKey? _privateKey;
    private PublicKey? _publicKey;

    public RSAProvider(ModuloNumber moduloNumber, PrivateKey privateKey, PublicKey publicKey)
        : this()
    {
        _moduloNumber = moduloNumber;
        _privateKey = privateKey;
        _publicKey = publicKey;
    }

    public RSAProvider()
    {
        rsa = new RSA(new RSALogger(new StreamWriter(Console.OpenStandardOutput())));

        if (_moduloNumber is null && _privateKey is null && _publicKey is null)
            GenerateAllKeys();
    }

    public void EncryptText(string text)
    {
        rsa.Encrypt(text, _publicKey);
    }

    public void DecryptText(IEnumerable<string> text)
    {
        rsa.Decrypt(text, _privateKey);
    }

    public IEnumerable<string> GetResult()
        => rsa.Result;

    private void GenerateAllKeys()
    {
        List<int> primes = PrimeNumberGenerator.Generate(DefaultRange);
        Random random = new Random();

        int firstFactor = primes[random.Next(primes.Count())];
        int secondFactor = primes[random.Next(primes.Count())];

        _moduloNumber = new ModuloNumber(firstFactor, secondFactor);
        _privateKey = PrivateKeyGenerator.GenerateKey(_moduloNumber);
        _publicKey = PublicKeyGenerator.GenerateKey(_privateKey, _moduloNumber);
    }
}

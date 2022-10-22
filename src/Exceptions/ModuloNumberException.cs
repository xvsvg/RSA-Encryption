namespace RSAEncryption.Exceptions;

public class ModuloNumberException : RSAEncryptionException
{
    private ModuloNumberException(string message)
        : base(message) { }

    public static ModuloNumberException ModuloNumberFactorsShouldBePrime(string message)
        => new ModuloNumberException(message);
}

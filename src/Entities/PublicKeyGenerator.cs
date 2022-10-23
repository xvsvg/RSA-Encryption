using RSAEncryption.Models;

namespace RSAEncryption.Entities;

public static class PublicKeyGenerator
{
    public const int DefaultKeyValue = 10;

    public static PublicKey GenerateKey(PrivateKey privateKey, ModuloNumber moduloNumber)
    {
        int publicKey = DefaultKeyValue;
        uint functionValue = PrivateKeyGenerator.EulerFunction(moduloNumber);

        while (true)
        {
            if ((ulong)(privateKey.Key * publicKey) % functionValue == 1)
                break;
            else publicKey++;
        }

        return new PublicKey(moduloNumber, publicKey);
    }
}

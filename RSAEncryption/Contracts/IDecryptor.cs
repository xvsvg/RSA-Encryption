using RSAEncryption.Models;

namespace RSAEncryption.Contracts;

public interface IDecryptor
{
    void Decrypt(IEnumerable<string> data, PrivateKey privateKey);
}

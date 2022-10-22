using RSAEncryption.Models;

namespace RSAEncryption.Contracts;

public interface IEncryptor
{
    void Encrypt(string data, PublicKey publicKey);
}

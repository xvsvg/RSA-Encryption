using RSAEncryption.Contracts;
using RSAEncryption.Exceptions;
using RSAEncryption.Models;
using System.Numerics;

namespace RSAEncryption.Entities;

public class RSA : IEncryptor, IDecryptor
{
    private readonly ILogger? _logger;
    private readonly List<string> _text;
    private Array _alphabet;

    public RSA(ILogger? logger)
    {
        _logger = logger;
        _text = new List<string>();
        _alphabet = Array.Empty<char>();
    }

    public IEnumerable<string> Result => _text;

    public void Decrypt(IEnumerable<string> data, PrivateKey privateKey)
    {
        ArgumentNullException.ThrowIfNull(privateKey);
        ArgumentNullException.ThrowIfNull(data);
        data = data.ToList();

        BigInteger decryptedCharacter;
        _logger?.Log("Decryption in process...\n");

        foreach (string encryptedCharacter in data)
        {
            decryptedCharacter = DecryptCharacter(privateKey, encryptedCharacter);

            int alphabetPosition = Convert.ToInt32(decryptedCharacter.ToString());

            _text.Add(_alphabet.GetValue(alphabetPosition % _alphabet.Length).ToString());
        }

        _logger?.Log("Decryption finished\n");
    }

    public void Encrypt(string data, PublicKey publicKey)
    {
        ArgumentNullException.ThrowIfNull(publicKey);

        if (string.IsNullOrEmpty(data))
            throw RSAException.UnableToEncryptEmptyInputDataException("Provide some data for encryption");

        DefineAlphabetAndClearBuffer(data);

        BigInteger encryptedCharacter;
        _logger?.Log("Encryption in process...\n");

        foreach (var character in data)
        {
            encryptedCharacter = EncryptCharacter(alphabet: _alphabet, encryptingCharacter: character, publicKey: publicKey);

            _text.Add(encryptedCharacter.ToString());
        }

        _logger?.Log("Encryption done successfully\n");
    }

    private void DefineAlphabetAndClearBuffer(string data)
    {
        _alphabet = DefineAlphabet(data);
        _text.Clear();
    }

    private BigInteger EncryptCharacter(Array alphabet,char encryptingCharacter, PublicKey publicKey)
    {
        int occurancePosition = Array.IndexOf(alphabet, encryptingCharacter);

        BigInteger result = new BigInteger(occurancePosition);
        result = BigInteger.Pow(result, publicKey.Key);
        result = result % new BigInteger(publicKey.ModuloNumber.Number);

        return result;
    }

    private static BigInteger DecryptCharacter(PrivateKey privateKey, string encryptedCharacter)
    {
        BigInteger decryptedCharacter = new BigInteger(Convert.ToDouble(encryptedCharacter));
        decryptedCharacter = BigInteger.Pow(decryptedCharacter, privateKey.Key);
        decryptedCharacter = decryptedCharacter % new BigInteger(privateKey.ModuloNumber.Number);
        return decryptedCharacter;
    }

    private Array DefineAlphabet(string data)
    {
        return data
            .Distinct()
            .ToArray();
    }
}

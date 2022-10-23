using RSAEncryption.Entities;
using RSAEncryption.Exceptions;

namespace RSAEncryption.Models;

public class ModuloNumber
{
    public ModuloNumber(int firstFactor, int secondFactor)
    {
        (FirstFactor, SecondFactor) = ValidateParameters(firstFactor, secondFactor);
    }

    public int FirstFactor { get; }
    public int SecondFactor { get; }
    public int Number => FirstFactor * SecondFactor;

    private (int FirstFactor, int SecondFactor) ValidateParameters(int firstFactor, int secondFactor)
    {
        if (PrimeNumberGenerator.IsPrime(firstFactor) && PrimeNumberGenerator.IsPrime(secondFactor))
            return (firstFactor, secondFactor);
        else throw ModuloNumberException.ModuloNumberFactorsShouldBePrime($"{firstFactor} and {secondFactor} both should be prime");
    }
}
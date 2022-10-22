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
		if (IsPrime(firstFactor) && IsPrime(secondFactor))
			return (firstFactor, secondFactor);
		else throw ModuloNumberException.ModuloNumberFactorsShouldBePrime($"{firstFactor} and {secondFactor} both should be prime");
	}

	private bool IsPrime(int number)
	{
        if (number < 2)
            return false;

        if (number == 2)
            return true;

        for (long i = 2; i < number; i++)
            if (number % i == 0)
                return false;

        return true;
    }
}
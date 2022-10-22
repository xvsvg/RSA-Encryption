using RSAEncryption.Models;

namespace RSAEncryption.Entities;

public static class PrivateKeyGenerator
{
    public static PrivateKey GenerateKey(ModuloNumber moduloNumber)
    {
        uint functionValue = EulerFunction(moduloNumber);
        int privateKey = (int)EulerFunction(moduloNumber) - 1;

        for(long i = 2; i <= functionValue; i++)
        {
            if (DoHaveCommonFactors(functionValue, privateKey, i))
            {
                privateKey--;
                i = 1;
            }
        }
        return new PrivateKey(moduloNumber, privateKey);
    }

    public static uint EulerFunction(ModuloNumber moduloNumber)
    {
        return (uint)((moduloNumber.FirstFactor - 1) * (moduloNumber.SecondFactor - 1));
    }

    private static bool DoHaveCommonFactors(uint moduloNumber, int privateKey, long i)
    {
        return (moduloNumber % i == 0) && (privateKey % i == 0);
    }
}

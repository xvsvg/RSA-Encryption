namespace RSAEncryption.Entities;

public static class PrimeNumberGenerator
{
    public static List<int> Generate(int range)
    {
        var primes = from i in Enumerable.Range(2, range - 1).AsParallel()
                where Enumerable.Range(1, (int)Math.Sqrt(i)).All(j => j == 1 || i % j != 0)
                select i;
        return primes.ToList();
    }

    public static bool IsPrime(int number)
    {
        List<int> factors = new List<int>();

        for (int i = 1; i * i <= number; ++i)
        {
            if (number % i == 0)
            {
                factors.Add(i);
                if (number / i != i)
                    factors.Add(number / i);
            }
        }

        if (factors.Count == 2 && factors.Contains(1) && factors.Contains(number))
            return true;
        else return false;
    }
}

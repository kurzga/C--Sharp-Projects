using System;
using System.Numerics;

class DecimalNumber
{
    public BigInteger WholePart { get; set; }
    public BigInteger DecimalPart { get; set; }
    public int DecimalPlaces { get; set; }

    public DecimalNumber(string value, int precision)
    {
        decimal decimalValue = decimal.Parse(value);
        WholePart = (BigInteger)decimal.Truncate(decimalValue);
        DecimalPart = (BigInteger)((decimalValue - decimal.Truncate(decimalValue)) * (decimal)Math.Pow(10, precision));
        DecimalPlaces = precision;
    }
}

class Program
{
    static void AddDecimals(DecimalNumber result, DecimalNumber num1, DecimalNumber num2)
    {
        result.WholePart = num1.WholePart + num2.WholePart;
        result.DecimalPart = num1.DecimalPart + num2.DecimalPart;

        while (result.DecimalPart >= BigInteger.Pow(10, result.DecimalPlaces))
        {
            result.DecimalPart /= 10;
            result.DecimalPlaces--;
        }
    }

    static void PrintDecimal(DecimalNumber num)
    {
        Console.WriteLine($"{num.WholePart}.{num.DecimalPart.ToString().PadLeft(num.DecimalPlaces, '0')}");
    }

    static void Main()
    {
        DecimalNumber num1 = new DecimalNumber("0.1", 20);
        DecimalNumber num2 = new DecimalNumber("0.2", 20);
        DecimalNumber result = new DecimalNumber("0", 20);

        AddDecimals(result, num1, num2);

        Console.Write("Result: ");
        PrintDecimal(result);
        Console.ReadKey();
    }
}

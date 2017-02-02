using System;
using static System.Math;

namespace ComplexNumbers
{
    /// <summary>
    /// Class which tests the Complex Number class
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            ComplexNumber x = new ComplexNumber(-Sqrt((3)), 1);
            ComplexNumber y = new ComplexNumber(Sqrt(2), Sqrt(6));

            try
            {
                Console.WriteLine("x = " + x);
                Console.WriteLine("y = " + y);

                Console.WriteLine("\nx == y " + (x==y));
                Console.WriteLine("x != y " + (x != y));

                Console.WriteLine("\nModulus of x is " + x.Modulus);
                Console.WriteLine("Modulus of y is " + y.Modulus);

                Console.WriteLine("\nConjugate of x is " + x.Conjugate);
                Console.WriteLine("Conjugate of y is " + y.Conjugate);

                Console.WriteLine("\nx + y = " + (x + y));
                Console.WriteLine("x - y = " + (x - y));
                Console.WriteLine("x * y = " + (x * y));
                Console.WriteLine("x / y = " + (x / y));
                Console.WriteLine("\nArg(x) is " + x.Argument);
                Console.WriteLine("Arg(y) is " + y.Argument);

                Console.WriteLine($"\n1/x = {ComplexNumber.GetReciprocal(x)}");
                Console.WriteLine($"1/y = {ComplexNumber.GetReciprocal(y)}");

                Console.WriteLine($"\nLog(x) = {ComplexNumber.ComplexLog(x)}");
                Console.WriteLine($"Log(y) = {ComplexNumber.ComplexLog(y)}");

                Console.WriteLine($"\nexp(x) = {ComplexNumber.ComplexExponential(x)}");
                Console.WriteLine($"exp(y) = {ComplexNumber.ComplexExponential(y)}");

                Console.WriteLine($"\nPolar of x = {ComplexNumber.PolarFormOutput(x)}");
                Console.WriteLine($"Polar of x == x is {ComplexNumber.PolarForm(x) == x}");
                Console.WriteLine($"Polar of y = {ComplexNumber.PolarFormOutput(y)}");
                Console.WriteLine($"Polar of y == y is {ComplexNumber.PolarForm(y) == y}");

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
            }
        }
    }
}

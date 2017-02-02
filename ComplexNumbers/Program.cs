using System;

namespace ComplexNumbers
{
    /// <summary>
    /// Class which tests the Complex Number class
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            ComplexNumber x = new ComplexNumber(2, -4);
            ComplexNumber y = new ComplexNumber(0, 0.001);

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

                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
            }
        }
    }
}

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
            ComplexNumber x = new ComplexNumber(-0.25, -0.25);
            ComplexNumber y = new ComplexNumber(-0.25, -0.25);

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
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
            }
        }
    }
}

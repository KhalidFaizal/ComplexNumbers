//
// Class for Complex Numbers. Allows for basic arithmetic operations and also more involved operations such as modulus, argument and conjugates
//
// Author: Khalid Faizal           Date: 26 Jan 2017
//
//

using System;
using static System.Math;

namespace ComplexNumbers
{
    public class ComplexNumber
    {
        public double Real { get; }
        public double Imaginary { get; }

        /// <summary>
        /// Constructor for the Complex Number class, sets the real and imaginary parts
        /// </summary>
        /// <param name="real">The real value of the Complex Number</param>
        /// <param name="imaginary">The imaginary value of the Complex Number</param>
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        /// <summary>
        /// Returns the conjugate of a complex number a+ib as a-ib
        /// </summary>
        public ComplexNumber Conjugate => new ComplexNumber(Real, -1.0 * Imaginary);

        /// <summary>
        /// Returns Modulus of a complex number
        /// </summary>
        public double Modulus => Sqrt(Pow(Real, 2.0) + Pow(Imaginary, 2.0));

        /// <summary>
        /// Returns the argument of a complex number in RADIANS
        /// </summary>
        public double Argument
        {
            get
            {
                if (Real > 0)
                {
                    return Atan(Imaginary / Real);
                }

                if (Real < 0 && Imaginary >= 0)
                {
                    return Atan(Imaginary / Real) + PI;
                }

                if (Real < 0 && Imaginary < 0)
                {
                    return Atan(Imaginary / Real) - PI;
                }

                if (Real == 0 && Imaginary > 0)
                {
                    return PI / 2;
                }

                if (Real == 0 && Imaginary < 0)
                {
                    return -PI / 2;
                }

                if (Real == 0 && Imaginary == 0)
                {
                    throw new Exception(
                        "Argument Error: Both the real and imaginary parts are 0, argument is undefined!");
                }

                throw new Exception("Why the fuck did this even hit? MAGIC"); // wtf?
            }
        }

        /// <summary>
        /// Performs the addition of two complex numbers
        /// </summary>
        /// <param name="x">The first complex number</param>
        /// <param name="y">The second complex number</param>
        /// <returns>The addition of x and y</returns>
        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Real + y.Real, x.Imaginary + y.Imaginary);
        }

        /// <summary>
        /// Performs the subtraction of two complex numbers
        /// </summary>
        /// <param name="x">The first complex number</param>
        /// <param name="y">The second complex number</param>
        /// <returns>The subtraction of x and y</returns>
        public static ComplexNumber operator -(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Real - y.Real, x.Imaginary - y.Imaginary);
        }

        /// <summary>
        /// Performs the multiplication of two complex numbers
        /// </summary>
        /// <param name="x">The first complex number</param>
        /// <param name="y">The second complex number</param>
        /// <returns>The multiplication of x and y</returns>
        public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.Real * y.Real - x.Imaginary * y.Imaginary,
                x.Imaginary * y.Real + x.Real * y.Imaginary);
        }

        /// <summary>
        /// Performs the division of two complex numbers, given that the divisor complex number isn't equal to zero
        /// </summary>
        /// <param name="x">The first complex number</param>
        /// <param name="y">The second complex number</param>
        /// <returns>Complex number which is the result of the division of x and y</returns>
        public static ComplexNumber operator /(ComplexNumber x, ComplexNumber y)
        {
            if (y.Real == 0 && y.Imaginary == 0)
            {
                throw new Exception(
                    "Division by zero error: Both the real and imaginary parts of the second complex number are zero");
            }

            double divisionDenominator = Pow(y.Real, 2.0) + Pow(y.Imaginary, 2.0);
            double realPart = (x.Real * y.Real + x.Imaginary * y.Imaginary) / divisionDenominator;
            double imaginaryPart = (x.Imaginary * y.Real - x.Real * y.Imaginary) / divisionDenominator;

            return new ComplexNumber(realPart, imaginaryPart);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ComplexNumber) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Real.GetHashCode() * 397) ^ Imaginary.GetHashCode();
            }
        }

        /// <summary>
        /// Compares two complex numbers for equality
        /// </summary>
        /// <param name="other">The other complex number to compare to</param>
        /// <returns>True if both are equal, false otherwise</returns>
        protected bool Equals(ComplexNumber other)
        {
            return AboutEqual(Real, other.Real) && AboutEqual(Imaginary, other.Imaginary);
        }

        /// <summary>
        /// Compares two doubles for equality using a calculated tolerance value of epsilon
        /// </summary>
        /// <param name="x">The first double to compare</param>
        /// <param name="y">The second double to compare</param>
        /// <returns>True if the two doubles are "about" equal, false otherwise</returns>
        public static bool AboutEqual(double x, double y)
        {
            double epsilon = Max(Abs(x), Abs(y)) * 1E-15;
            return Abs(x - y) <= epsilon;
        }

        /// <summary>
        /// Overrides the operator == to test for equality
        ///</summary>
        /// <param name="x">The first complex number</param>
        /// <param name="y">The second complex number</param>
        /// <returns>True if x is equal to y, false otherwise</returns>
        public static bool operator ==(ComplexNumber x, ComplexNumber y)
        {
            return x.Equals(y);
        }

        /// <summary>
        /// Overrides the operator != to test for not equals
        /// </summary>
        /// <param name="x">The first complex number</param>
        /// <param name="y">The second complex number</param>
        /// <returns>True if x does not equal y, false otherwise</returns>
        public static bool operator !=(ComplexNumber x, ComplexNumber y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Prints the complex number in a verbose way such as: a + bi
        /// </summary>
        /// <returns>Verbose output of a complex number</returns>
        public override string ToString()
        {
            string sign = Imaginary < 0 ? "-" : "+";

            // Check for no real part output
            if (Real != 0.0)
            {
                return Real + " " + sign + " " + (Abs(Imaginary) == 1.0 ? "i" : Abs(Imaginary) + "i");
            }

            // Check if the imaginary part is one to output a single i with no unit 1 in front
            if (Abs(Imaginary) == 1.0)
            {
                return sign == "-" ? sign + " i" : "i";
            }

            // Otherwise output as normal
            return sign == "-" ? sign + Abs(Imaginary) + "i" : Abs(Imaginary) + "i";
        }

        /// <summary>
        /// Returns the reciprocal 1/z of a complex number z by using 1/z = zbar / z * zbar = zbar / |z| ^ 2
        /// </summary>
        /// <param name="z">The complex number to calculate the reciprocal of</param>
        /// <returns>The reciprocal of the complex number z</returns>
        public static ComplexNumber GetReciprocal(ComplexNumber z)
        {
            double modSquared = Pow(z.Modulus, 2.0);
            double realPart = z.Real / modSquared;
            double imaginaryPart = -1 * (z.Imaginary / modSquared);

            return new ComplexNumber(realPart, imaginaryPart);
        }

        /// <summary>
        /// Returns the complex log of z
        /// </summary>
        /// <param name="z">Complex number z</param>
        /// <returns>Complex log of z</returns>
        public static ComplexNumber ComplexLog(ComplexNumber z)
        {
            return new ComplexNumber(Log(z.Modulus), z.Argument);
        }

        /// <summary>
        /// Returns the exponential log of z
        /// </summary>
        /// <param name="z">Complex exponential z</param>
        /// <returns>Complex exponential of z</returns>
        public static ComplexNumber ComplexExponential(ComplexNumber z)
        {
            double realPart = Exp(z.Real) * Cos(z.Imaginary);
            double imaginaryPart = Exp(z.Real) * Sin(z.Imaginary);

            return new ComplexNumber(realPart, imaginaryPart);
        }

        /// <summary>
        /// Evaluates the complex number z in polar form z = r ( cos(theta) + sin(theta); r = |z| and theta = arg(z)
        /// </summary>
        /// <param name="z">The complex number to return the polar form of</param>
        /// <returns>Polar form of the complex number z</returns>
        public static ComplexNumber PolarForm(ComplexNumber z)
        {
            double realPart = z.Modulus * Cos(z.Argument);
            double imaginaryPart = z.Modulus * Sin(z.Argument);

            return new ComplexNumber(realPart, imaginaryPart);
        }

        /// <summary>
        /// Prints the polar form of the complex number z = r ( cos(theta) + sin(theta); r = |z| and theta = arg(z)
        /// </summary>
        /// <param name="z">The complex number to print the polar form of</param>
        /// <returns>Polar form of the complex number z</returns>
        public static string PolarFormOutput(ComplexNumber z)
        {
            return z.Modulus + "(Cos(" + z.Argument + ") + Sin(" + z.Argument + "))";
        }
    }
}
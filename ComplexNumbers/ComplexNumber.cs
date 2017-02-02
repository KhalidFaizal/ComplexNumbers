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
        //TODO Add functions for: Check if argument is the principal argument, Log, exponential, polar form

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

        protected bool Equals(ComplexNumber other)
        {
            return Real.Equals(other.Real) && Imaginary.Equals(other.Imaginary);
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
    }
}
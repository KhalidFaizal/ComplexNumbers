//
// Class for Complex Numbers. Allows for basic arithmetic operations and also more involved operations such as modulus, argument and conjugates
//
// Author: Khalid Faizal           Date: 26 Jan 2017
//
//

using System;

namespace ComplexNumbers
{
    public class ComplexNumber
    {
        //TODO Add functions for: Reciprocal (1/z), Check if argument is the principal argument, Log, exponential, polar form, shit

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
        public ComplexNumber Conjugate => new ComplexNumber(Real, -1.0*Imaginary);

        /// <summary>
        /// Returns Modulus of a complex number
        /// </summary>
        public double Modulus => Math.Sqrt(Math.Pow(Real, 2.0) + Math.Pow(Imaginary, 2.0));

        /// <summary>
        /// Returns the argument of a complex number in RADIANS
        /// </summary>
        public double Argument
        {
            get
            {
                if (Real > 0)
                {
                    return Math.Atan(Imaginary/Real);
                }

                if (Real < 0 && Imaginary >= 0)
                {
                    return Math.Atan(Imaginary/Real) + Math.PI;
                }

                if (Real < 0 && Imaginary < 0)
                {
                    return Math.Atan(Imaginary / Real) - Math.PI;
                }

                if (Real == 0 && Imaginary > 0)
                {
                    return Math.PI/2;
                }

                if (Real == 0 && Imaginary < 0)
                {
                    return -Math.PI / 2;
                }

                if (Real == 0 && Imaginary == 0)
                {
                    throw new Exception("Argument Error: Both the real and imaginary parts are 0, argument is undefined!");
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
            return new ComplexNumber(x.Real*y.Real - x.Imaginary*y.Imaginary, x.Imaginary*y.Real + x.Real*y.Imaginary);
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

            double divisionDenominator = Math.Pow(y.Real, 2.0) + Math.Pow(y.Imaginary, 2.0);
            double realPart = (x.Real*y.Real + x.Imaginary*y.Imaginary)/divisionDenominator;
            double imaginaryPart = (x.Imaginary*y.Real - x.Real*y.Imaginary)/divisionDenominator;

            return new ComplexNumber(realPart, imaginaryPart);
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ComplexNumber)obj);
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

            return Real + " " + sign + " " + Math.Abs(Imaginary) + "i";
        }
    }
}
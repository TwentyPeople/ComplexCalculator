using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Globalization;


namespace ComplexCalculator
{
    public class ComplexNumber
    {
        double real; // real part (a)
        double imaginary; // imaginary part (b)

        // Constructor
        public ComplexNumber(double realpart, double imaginarypart)
        {
            this.real = realpart;
            this.imaginary = imaginarypart;
        }

        // Addition
        public static ComplexNumber operator +(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.real + n2.real, n1.imaginary + n2.imaginary);
        }

        // Substraction
        public static ComplexNumber operator -(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber(n1.real - n2.real, n1.imaginary - n2.imaginary);
        }

        // Product
        public static ComplexNumber operator *(ComplexNumber n1, ComplexNumber n2)
        {
            return new ComplexNumber((n1.real * n2.real) - (n1.imaginary * n2.imaginary), (n1.imaginary * n2.real) + (n1.real * n2.imaginary));
        }

        // Conjugate (needed for quocient) // not a static method
        public ComplexNumber Conjugate()
        {
            return new ComplexNumber(this.real, -(this.imaginary));
        }


        // Displaying as string
        public override string ToString()
        {
            if (this.imaginary > 0)
            {
                if (this.imaginary != 1)
                {
                    return String.Format("{0} + {1}i", this.real, this.imaginary);
                }
                else
                {
                    return String.Format("{0} + i", this.real);
                }
            }
            else if (this.imaginary < 0)
            {
                if (this.imaginary != -1)
                {
                    return String.Format("{0} - {1}i", this.real, Math.Abs(this.imaginary));
                }
                else
                {
                    return String.Format("{0} - i", this.real);
                }
            }
            else
            {
                return String.Format("{0}", this.real);
            }
        }

        // Overrides needed for testing
        public static void AssertEqualty (ComplexNumber n1, ComplexNumber n2, String errormsg = "Error while asserting equalty.")
        {
            Assert.AreEqual(n1.real, n2.real, errormsg);
            Assert.AreEqual(n1.imaginary, n2.imaginary, errormsg);
        }

        // Parse from a string following this pattern: "a + bi"
        public static ComplexNumber ParseFromString(String str)
        {
            string regexPattern =
                // Match any float, negative or positive, group it
                @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+)" +
                // ... possibly following that with whitespace
                @"\s*" +
                // ... followed by a plus
                @"([-+])" +
                // and possibly more whitespace:
                @"\s*" +
                // Match any other float, and save it
                @"([-+]?\d+\.?\d*|[-+]?\d*\.?\d+)*" +
                // ... followed by 'i'
                @"i";
            Regex cmplxRegex = new Regex(regexPattern);
            Match cmplxMatch = cmplxRegex.Match(str);

            // Parse the matched information
            double realpart = double.Parse(cmplxMatch.Groups[1].Value, CultureInfo.InvariantCulture);
            double imgpart;
            if (cmplxMatch.Groups[3].Success == false)
            {
                imgpart = double.Parse(cmplxMatch.Groups[2].Value + 1);
            }
            else
            {
                imgpart = double.Parse(cmplxMatch.Groups[2].Value + cmplxMatch.Groups[3].Value, CultureInfo.InvariantCulture);
            }
            // Return a new complex number
            return new ComplexNumber(realpart, imgpart);

        }
    }

}

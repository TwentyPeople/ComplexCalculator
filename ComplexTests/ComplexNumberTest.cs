using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComplexCalculator;

namespace ComplexTests
{
    [TestClass]
    public class ComplexNumberTest
    {
        /*
         * Tests start here.
         * A wrapper for Assert.Arequal must be used since ComplexNumbers need to be compared 
         * real v. real and imaginary v. imaginary.
         */

        [TestMethod]
        public void PositiveOperands()
        {
            
            // Definitions of the numbers
            ComplexNumber myNum1 = new ComplexNumber(3, 4);
            ComplexNumber myNum2 = new ComplexNumber(2, 5);

            // Operations to be done
            ComplexNumber result1 = myNum1 + myNum2;
            ComplexNumber result2 = myNum1 - myNum2;
            ComplexNumber result3 = myNum1 * myNum2;

            // Expected Results
            ComplexNumber expectedResult1 = new ComplexNumber(5, 9);
            ComplexNumber expectedResult2 = new ComplexNumber(1, -1);
            ComplexNumber expectedResult3 = new ComplexNumber(-14, 23);

            // First group (positive operands)
            ComplexNumber.AssertEqualty(expectedResult1, result1, "Addition failed.");
            ComplexNumber.AssertEqualty(expectedResult2, result2, "Substraction failed.");
            ComplexNumber.AssertEqualty(expectedResult3, result3, "Product failed.");
        }

        [TestMethod]
        public void NegativeOperand()
        {
            // Definitions of the numbers
            ComplexNumber myNum1 = new ComplexNumber(3, 4);
            ComplexNumber myNum2 = new ComplexNumber(2, -5);

            // Operations to be done
            ComplexNumber result1 = myNum1 + myNum2;
            ComplexNumber result2 = myNum1 - myNum2;
            ComplexNumber result3 = myNum1 * myNum2;

            // Expected Results
            ComplexNumber expectedResult1 = new ComplexNumber(5, -1);
            ComplexNumber expectedResult2 = new ComplexNumber(1, 9);
            ComplexNumber expectedResult3 = new ComplexNumber(26, -7);

            // Second group (one of the operands is negative)
            ComplexNumber.AssertEqualty(expectedResult1, result1, "Addition failed.");
            ComplexNumber.AssertEqualty(expectedResult2, result2, "Substraction failed.");
            ComplexNumber.AssertEqualty(expectedResult3, result3, "Product failed.");
        }

        [TestMethod]
        public void MethodTests()
        {
            // Try and parse a b-positive and a b-negative complex numbers from two strings
            String bPositive = "1 + 5i";
            String bNegative = "1 - 3i";
            // Try and calculate a b-positive and a b-negative conjugate
            ComplexNumber bpComplex = new ComplexNumber(1, 3);
            ComplexNumber bnComplex = new ComplexNumber(-3, -2);

            // Parse the thingies
            ComplexNumber result1 = ComplexNumber.ParseFromString(bPositive);
            ComplexNumber result2 = ComplexNumber.ParseFromString(bNegative);
            // Calculate the conjugate
            ComplexNumber bpConjugate = bpComplex.Conjugate();
            ComplexNumber bnConjugate = bnComplex.Conjugate();

            // What do we expect?
            ComplexNumber expected1 = new ComplexNumber(1, 5);
            ComplexNumber expected2 = new ComplexNumber(1, -3);
            ComplexNumber ebpConjugate = new ComplexNumber(1, -3);
            ComplexNumber ebnConjugate = new ComplexNumber(-3, 2);

            // Do the opposite (complex -> string) with the same numbers
            String fromComplex1 = expected1.ToString();
            String fromComplex2 = expected2.ToString();

            // Run the tests
            ComplexNumber.AssertEqualty(expected1, result1);
            ComplexNumber.AssertEqualty(expected2, result2);
            Assert.AreEqual(bPositive, fromComplex1);
            Assert.AreEqual(bNegative, fromComplex2);
            ComplexNumber.AssertEqualty(ebpConjugate, bpConjugate);
            ComplexNumber.AssertEqualty(ebnConjugate, bnConjugate);
        }
    }
}

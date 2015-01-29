using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaration section
            String fstNum, sndNum, op;
            ComplexNumber first, second, result;
            // 2nd result in case it's not an operand but a conjugate or another mutation
            ComplexNumber result2 = null;
            

            // IO
            Console.WriteLine("Welcome to the complex calculator. Keep in mind your input should follow this model: a +/- bi");
            Console.Write("Please type in first operand: ");
            fstNum = Console.ReadLine();
            Console.Write("Please type in second operand: ");
            sndNum = Console.ReadLine();


            // Logic

            // Parse the operands
            first = ComplexNumber.ParseFromString(fstNum);
            second = ComplexNumber.ParseFromString(sndNum);

            // Figure what operation we want to do
            do
            {
                Console.Write("Please type in the operator (+, -, * or conjugate; press enter to exit): ");
                op = Console.ReadLine();
                switch (op)
                {
                    case "+":
                        result = first + second;
                        break;
                    case "-":
                        result = first - second;
                        break;
                    case "*":
                        result = first * second;
                        break;
                    case "conjugate":
                        result = first.Conjugate();
                        result2 = second.Conjugate();
                        break;
                    default:
                        Console.WriteLine("The operand " + op + " is unknown to this calculator.");
                        // Set a result just in case something weird happens.
                        result = first;
                        Environment.Exit(1);
                        break;
                }

                // Display the output
                Console.WriteLine("Result: " + result);
                if (result2 != null)
                {
                    Console.WriteLine("Result 2: " + result2);
                }
            } while (true);
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllLines("input.txt")[0];

            string[] elements = (DeleteSpace(input));

            double result = Calculate(elements);

            string answer = double.IsNaN(result) ? "Недопустимая операция" : result.ToString();

            string[] output = new [] { answer };

            File.WriteAllLines("Output.txt", output);

        }

        static string[] DeleteSpace (string input)
        {
            string[] elements = input.Split(' ');
            List<string> result = new List<string>();

            foreach(string element in elements)
            {
                if (String.IsNullOrEmpty(element))                
                    continue;
                
                result.Add(element);
            }

            return result.ToArray();
        }

        static double Calculate (string[] elements)
        {
            double operand1 = Convert.ToDouble(elements[0]);
            double operand2 = Convert.ToDouble(elements[2]);

            switch (elements[1])
            {
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (elements[2] != "0")
                    {
                        return operand1 / operand2;
                    }
                    else
                    {
                        return double.NaN;
                    }
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                default:
                    return double.NaN;
            }
        }
    }
}

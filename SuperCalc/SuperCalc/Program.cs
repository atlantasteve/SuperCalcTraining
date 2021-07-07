using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace SuperCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter a Basic Arithmetic equation: ");
                string input = Console.ReadLine();
                if (input == string.Empty || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;
                var result = ParseAndCalculate(input);
                Console.WriteLine(result);
            }
            Console.WriteLine("Goodbye");
        }

        private static string ParseAndCalculate(string input)
        {
            var operators = new List<string>() { "+", "-", "*", "x", "/", "^", "%" };

            var parts = input.Split(' ');

            if (parts.Length != 3)
            {
                return "The Equation is not properly structured.";
            }

            if (!decimal.TryParse(parts[0], out decimal operand1))
            {
                return "Operand 1 is not a proper number";
            }

            if (!decimal.TryParse(parts[2], out decimal operand2))
            {
                return "Operand 2 is not a proper number";
            }

            string op = parts[1];

            if (!operators.Contains(op))
            {
                return "Operator is not recognized";
            }

            decimal result = Calculate(operand1, op, operand2);
            return $"{operand1} {op} {operand2} is {result}";
        }

        private static decimal Calculate(decimal operand1, string op, decimal operand2)
        {
            switch (op)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                case "x":
                    return operand1 * operand2;
                case "/":
                    return operand1 / operand2;
                case "^":
                    return (decimal)Math.Pow((double)operand1, (double)operand2);
                case "%":
                    return operand1 % operand2;
                default:
                    throw new ApplicationException("Invalid Operator");
            }
        }
    }
}

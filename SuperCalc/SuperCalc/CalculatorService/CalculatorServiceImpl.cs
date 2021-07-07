using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalc
{
    public class CalculatorServiceImpl : ICalculatorService
    {
        public CalculatorServiceImpl()
        {

        }

        public List<string> Operators { get; } = new List<string>() { "+", "-", "*", "x", "/", "^", "%" };

        public decimal Calculate(decimal operand1, string op, decimal operand2)
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
                    if (operand2 == 0)
                        throw new SuperCalcExcpetion("Divide By Zero", SuperCalcFailure.DivideByZero);
                    return operand1 / operand2;
                case "^":
                    return (decimal)Math.Pow((double)operand1, (double)operand2);
                case "%":
                    return operand1 % operand2;
                default:
                    throw new SuperCalcExcpetion("Invalid Operator", SuperCalcFailure.InvalidOperator);
            }
        }
    }
}

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
            return -1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SuperCalc
{
    public class CalcParseServiceImpl : ICalcParseService
    {
        private readonly ICalculatorService _calc;
        public CalcParseServiceImpl(ICalculatorService calc)
        {
            _calc = calc;
        }

        public string ParseAndCalculate(string input)
        {
            InputData = input;

            var parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new SuperCalcExcpetion("The Equation is not properly structured.", SuperCalcFailure.ImproperEquation);
            }

            if (!decimal.TryParse(parts[0], out decimal operand1))
            {
                throw new SuperCalcExcpetion("Operand 1 is not a proper number", SuperCalcFailure.InvalidOperand1);
            }

            if (!decimal.TryParse(parts[2], out decimal operand2))
            {
                throw new SuperCalcExcpetion("Operand 2 is not a proper number", SuperCalcFailure.InvalidOperand2);
            }

            string op = parts[1];

            if (!_calc.Operators.Contains(op))
            {
                throw new SuperCalcExcpetion("Operator is not recognized", SuperCalcFailure.InvalidOperator);
            }

            Operand1 = operand1;
            Operand2 = operand2;
            Operator = op;

            decimal result = _calc.Calculate(operand1, op, operand2);
            Output = $"{operand1} {op} {operand2} is {result}";

            return Output;
        }

        public decimal Operand1 { get; private set; }
        public decimal Operand2 { get; private set; }
        public string Operator { get; private set; }

        public string InputData { get; private set; }

        public string Output { get; private set; }

    }
}

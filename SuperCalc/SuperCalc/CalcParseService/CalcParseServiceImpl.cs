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
            return null;
        }

        public decimal Operand1 { get; private set; }
        public decimal Operand2 { get; private set; }
        public string Operator { get; private set; }

        public string InputData { get; private set; }

        public string Output { get; private set; }

    }
}

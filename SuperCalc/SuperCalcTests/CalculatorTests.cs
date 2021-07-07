using SuperCalc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using FluentAssertions;

namespace SuperCalcTests
{
    public class CalculatorTests
    {
        [Fact]
        void Calculator_Plus()
        {
            var calc = new CalculatorServiceImpl();
            decimal result = calc.Calculate(15, "+", 13);            
            result.Should().Be(28);
            result = calc.Calculate(15, "+", -13);
            result.Should().Be(2);
            result = calc.Calculate(-15, "+", 13);
            result.Should().Be(-2);
        }

        [Fact]
        void Calculator_Times()
        {
            var calc = new CalculatorServiceImpl();
            decimal result = calc.Calculate(5, "x", 3);
            result.Should().Be(15);
            result = calc.Calculate(5, "*", -3);
            result.Should().Be(-15);
            result = calc.Calculate(3, "*", 0);
            result.Should().Be(0);
        }

        [Fact]
        void Calculator_Divide()
        {
            var calc = new CalculatorServiceImpl();
            decimal result = calc.Calculate(15, "/", 3);
            result.Should().Be(5);
            result = calc.Calculate(15, "/", -3);
            result.Should().Be(-5);

            Action func = () => calc.Calculate(3, "/", 0) ;
            func.Should().Throw<SuperCalcExcpetion>().And.Failure.Should().Be(SuperCalcFailure.DivideByZero);
            
        }


    }
}

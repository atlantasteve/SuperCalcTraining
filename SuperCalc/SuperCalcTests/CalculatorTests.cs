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
            //arrange
            var calc = new CalculatorServiceImpl();

            //act
            decimal result = calc.Calculate(15, "+", 13);            

            //assert
            result.Should().Be(28);

            //act
            result = calc.Calculate(15, "+", -13);

            //assert
            result.Should().Be(2);

            //act
            result = calc.Calculate(-15, "+", 13);

            //assert
            result.Should().Be(-2);
        }

        [Fact]
        void Calculator_Times()
        {
            //arrange
            var calc = new CalculatorServiceImpl();

            //act
            decimal result = calc.Calculate(5, "x", 3);

            //assert
            result.Should().Be(15);

            //act
            result = calc.Calculate(5, "*", -3);

            //assert
            result.Should().Be(-15);

            //act
            result = calc.Calculate(3, "*", 0);

            //assert
            result.Should().Be(0);
        }

        [Fact]
        void Calculator_Divide()
        {
            //arrange
            var calc = new CalculatorServiceImpl();
            
            //act
            decimal result = calc.Calculate(15, "/", 3);

            //assert
            result.Should().Be(5);            

            //act
            result = calc.Calculate(15, "/", -3);

            //assert
            result.Should().Be(-5);

            //act
            Action func = () => calc.Calculate(3, "/", 0) ;

            //assert
            func.Should().Throw<SuperCalcExcpetion>().And.Failure.Should().Be(SuperCalcFailure.DivideByZero);            
        }
    }
}

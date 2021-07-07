using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SuperCalc;
using Moq;
using FluentAssertions;

namespace SuperCalcTests
{
    public class ArithmeticParserTests
    {
        ICalculatorService _calc = null;
        public ArithmeticParserTests()
        {

            List<string> operators = new List<string>() { "?", "!", "o" };
            var calcMock = new Mock<ICalculatorService>();
            calcMock.Setup(c => c.Operators).Returns(operators);
            calcMock.Setup(c => c.Calculate(It.IsAny<decimal>(), It.IsAny<string>(), It.IsAny<decimal>())).Returns(25);
            _calc = calcMock.Object;

        }

        [Fact]
        void Arithmetic_HappyPath()
        {
            var prsr = new CalcParseServiceImpl(_calc);
            prsr.ParseAndCalculate("7 ! 23");
            prsr.Output.Should().Be("7 ! 23 is 25");
        }

        [Fact]
        void Arithmetic_BadEquation()
        {
            var prsr = new CalcParseServiceImpl(_calc);
            prsr.Invoking(p => p.ParseAndCalculate("bananas")).Should().Throw<SuperCalcExcpetion>().And.Failure.Should().Be(SuperCalcFailure.ImproperEquation);
            
        }

        [Fact]
        void Arithmetic_BadOperator()
        {
            var prsr = new CalcParseServiceImpl(_calc);
            prsr.Invoking(p => p.ParseAndCalculate("7 $ 72")).Should().Throw<SuperCalcExcpetion>().And.Failure.Should().Be(SuperCalcFailure.InvalidOperator);
            
        }

        [Fact]
        void Arithmetic_BadOperand()
        {
            var prsr = new CalcParseServiceImpl(_calc);
            prsr.Invoking(p => p.ParseAndCalculate("7 ! potato")).Should().Throw<SuperCalcExcpetion>().And.Failure.Should().Be(SuperCalcFailure.InvalidOperand2);
        }
    }
}

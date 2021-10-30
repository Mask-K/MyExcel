using System;
using Xunit;
using Menu;

namespace Menu.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestDivMul()
        {
            Assert.Equal(Calculator.Evaluate("0 * 5"), 0);
            Assert.Throws<DivideByZeroException>(() => Calculator.Evaluate("1 / 0"));
            Assert.Equal(Calculator.Evaluate("5 * 5"), 25);
        }

        [Fact]
        public void TestExponent()
        {
            Assert.Equal(Calculator.Evaluate("0 ^ 0"), 1);
            Assert.Equal(Calculator.Evaluate("1 ^ 10"), 1);
            Assert.Equal(Calculator.Evaluate("10 ^ 1"), 10);
            Assert.Equal(Calculator.Evaluate("10 ^ 2"), 100);
            Assert.Equal(Calculator.Evaluate("10 ^ 0"), 1);
        }
        [Fact]
        public void TestMinMax()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Assert.Equal(Calculator.Evaluate("min(12, 10)"), 10);
            Assert.Equal(Calculator.Evaluate("max(12, 10)"), 12);
            Assert.Equal(Calculator.Evaluate("min(1, 1)"), 1);
            Assert.Equal(Calculator.Evaluate("min(-1, 1)"), -1);
            Assert.Equal(Calculator.Evaluate("max(-1, 1)"), 1);
            Assert.Equal(Calculator.Evaluate("max(-1^3, 1^3)"), 1);
            Assert.Equal(Calculator.Evaluate("max(1.2, 10)"), 10);
            Assert.Equal(Calculator.Evaluate("min(1.2, 10)"), 1.2);
        }

        [Fact]
        public void TestIncDec()
        {
            Assert.Equal(Calculator.Evaluate("inc 5"), 6);
            Assert.Equal(Calculator.Evaluate("dec 5"), 4);
            Assert.Equal(Calculator.Evaluate("inc (min(5, 3))"), 4);
        }
    }

    
}

using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;


namespace StringCalculatorKata.Test
{
    public class StringCalculatorTest
    {
        [Test]
        public void Add_EmptyStringAsParam_ReturnsZero()
        {
            Assert.AreEqual(0, StringCalculator.Add(""));
        }

        [TestCase("1", ExpectedResult = 1)]
        [TestCase("1,1", ExpectedResult = 2)]
        [TestCase("1,1,2,3", ExpectedResult = 7)]
        [TestCase("//;\n1;2", ExpectedResult = 3)]
        [TestCase("//.\n1.3.4", ExpectedResult = 8)]
        [TestCase("1,10,2,3", ExpectedResult = 16)]

        public int Add_StringAsParam_ReturnsOneNumber(string value)
        {
            return StringCalculator.Add(value);
        }

        [Test]
        public void String_Exception ()
        {
            Assert.Throws<NegativeNumberException>(() => StringCalculator.Add("1, -2"));
        }

        [TestCase(ExpectedResult = 7)]
        public int GetAddMethodCalls()
        {
            return StringCalculator.GetCalledCount();
        }


    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTests.Tests
{
    public class TestsWithAttributes
    {

        [Test, TestCaseSource("ComparisonCases")]
        public void ComparisonTest(int a, int b)
        {
            Assert.IsTrue(a > b);
        }
        static object[] ComparisonCases =
        {
            new object[] { 2, 1 },
            new object[] { 3, 4 },
            new object[] { 9, 4 }
        };

        [Test]
        public void CheckTemperature([Random(35.9,37.3,5)] decimal randomTemperature)
        {
            const double standardBodyTemperature = 36.6;
            Assert.That(randomTemperature, Is.LessThanOrEqualTo(standardBodyTemperature));
        }
    }
}





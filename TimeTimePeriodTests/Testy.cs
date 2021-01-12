using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTimePeriod;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;


namespace TimeTimePeriodTests
{
    [TestClass]
    public static class InitializeCulture
    {
        [AssemblyInitialize]
        public static void SetEnglishCultureOnAllUnitTest(TestContext context)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }
    }
    [TestClass]
    public class Constructors
    {


        public void AssertTime(Time time, byte expectedHour, byte expectedMinute, byte expectedSecond)
        {
            Assert.AreEqual(time.Hours, expectedHour);
            Assert.AreEqual(time.Minutes, expectedMinute);
            Assert.AreEqual(time.Seconds, expectedSecond);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(0, 0, 0)]
        [DataRow(21, 0, 10)]
        [DataRow(0, 0, 44)]
        [DataRow(10, 10, 10)]
        [DataRow(4, 44, 4)]

        public void Constructors_3(int hour, int minute, int second)
        {
            var time = new Time((byte)hour, (byte)minute, (byte)second);

            AssertTime(time, (byte)hour, (byte)minute, (byte)second);
        }

        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(0, 0)]
        [DataRow(21, 0)]
        [DataRow(0, 0)]
        [DataRow(10, 10)]
        [DataRow(4, 44)]

        public void Constructors_2(int hour, int minute)
        {
            var time = new Time((byte)hour, (byte)minute);
            AssertTime(time, (byte)hour, (byte)minute, 0);
        }
        [DataTestMethod, TestCategory("Constructors")]
        [DataRow(0)]
        [DataRow(21)]
        [DataRow(04)]
        [DataRow(10)]
        [DataRow(1)]
        public void Constructors_1(int hour)
        {
            var time = new Time((byte)hour);
            AssertTime(time, (byte)hour, 0, 0);
        }
        [DataTestMethod, TestCategory("Constructors")]
        public void Constructors_0()
        {
            var time = new Time();
            AssertTime(time, 0, 0, 0);
        }
    }
}






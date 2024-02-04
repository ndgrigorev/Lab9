using Lab9;
namespace TestCalendarDate
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(29,2,2020);
            //Act
            CalendarDate actual = new CalendarDate(1, 3, 2020);
            actual = actual + (-1);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            CalendarDate expected = new CalendarDate() >> 2;
            //Act
            CalendarDate actual = new CalendarDate(1, 3, 2024);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(28, 2, 2023);
            //Act
            CalendarDate actual = new CalendarDate(expected);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(1, 1, 1);
            //Act
            CalendarDate actual = new CalendarDate(-1, -1, -1);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(31, 12, 2003);
            //Act
            CalendarDate actual = new CalendarDate(32, 15, 2003);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod6()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(2, 1, 2003);
            //Act
            CalendarDate actual = new CalendarDate(31, 12, 2002) + 2;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod7()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(2, 2, 2004);
            //Act
            CalendarDate actual = new CalendarDate(31, 1, 2003) + 2 >> 12;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod8()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(31, 1, 2004);
            //Act
            CalendarDate actual = new CalendarDate(1, 2, 2005) + -1;
            actual = actual >> -12;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod9()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(31, 12, 2005);
            //Act
            CalendarDate actual = new CalendarDate(1, 1, 2006) + -1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod10()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(1, 1, 1);
            //Act
            CalendarDate actual = new CalendarDate(1, 1, 1) + -1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod11()
        {
            //Arrange
            CalendarDate expected = new CalendarDate(1, 1, 1);
            //Act
            CalendarDate actual = new CalendarDate(5, 1, 1) + -4;
            actual = actual >> -1;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod12()
        {
            //Arrange
            string expected = "01.01.0005";
            //Act
            CalendarDate date = new CalendarDate(1, 1, 5);
            string actual = date;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod13()
        {
            //Arrange
            int expected = 1;
            //Act
            CalendarDate date = new CalendarDate(1, 1, 2005);
            int actual = (int)date;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod14()
        {
            //Arrange
            int expected = 2;
            //Act
            CalendarDate date = new CalendarDate(1, 5, 2005);
            int actual = (int)date;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod15()
        {
            //Arrange
            int expected = 3;
            //Act
            CalendarDate date = new CalendarDate(1, 8, 2005);
            int actual = (int)date;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod16()
        {
            //Arrange
            int expected = 4;
            //Act
            CalendarDate date = new CalendarDate(1, 12, 2005);
            int actual = (int)date;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod17()
        {
            //Arrange
            bool expected = true;
            //Act
            CalendarDate date = new CalendarDate(1, 12, 2030);
            bool actual = false;
            if (date)
            {
                actual = true;
            }
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod18()
        {
            //Arrange
            bool expected = true;
            //Act
            CalendarDate date = new CalendarDate(1, 12, 2020);
            bool actual = date.IsLeapYear();
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod19()
        {
            //Arrange
            bool expected = true;
            //Act
            CalendarDate date = new CalendarDate(1, 12, 2020);
            bool actual = CalendarDate.IsLeapYear(date);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod20()
        {
            //Arrange
            CalendarDateArray expected = new CalendarDateArray(3);
            //Act
            CalendarDateArray actual = new CalendarDateArray(expected);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod21()
        {
            //Arrange
            CalendarDateArray actual = new CalendarDateArray(3);
            //Act
            Assert.ThrowsException<Exception>(() => { new CalendarDate(actual[6]); });
        }
        [TestMethod]
        public void TestMethod22()
        {
            //Arrange
            CalendarDateArray expected = new CalendarDateArray();
            //Act
            CalendarDateArray actual = new CalendarDateArray(1);
            actual[0] = new CalendarDate(1, 1, 2024);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
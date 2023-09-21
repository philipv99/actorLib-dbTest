using Microsoft.VisualStudio.TestTools.UnitTesting;
using actorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace actorLib.Tests
{
    [TestClass()]
    public class ActorTests
    {

        [TestMethod()]
        public void ValidateYoB1820()
        {
            Actor actor1 = new Actor("tom hangs", 1820, Genre.drama );
            int temp = actor1.YearOfBirth;
            actor1.ValidateYearOfBirth();
            Assert.AreEqual( temp, actor1.YearOfBirth );
        }

        [TestMethod()]
        public void ValidateYoB1821()
        {
            Actor actor1 = new Actor("tom hangs", 1821, Genre.drama);
            int temp = actor1.YearOfBirth;
            actor1.ValidateYearOfBirth();
            Assert.AreEqual(temp, actor1.YearOfBirth);
        }

        [TestMethod()]
        public void ValidateYoB1819()
        {
            Actor actor1 = new Actor("tom hangs", 1819, Genre.drama);
            int temp = actor1.YearOfBirth;
            Assert.ThrowsException<ArgumentException>(() => actor1.ValidateYearOfBirth());
        }



        [TestMethod()]
        public void ValidateName()
        {
            Actor actor1 = new Actor("1234", 1819, Genre.drama);
            Assert.AreEqual(actor1.Name.Length, 4);
        }

        [TestMethod()]
        public void ValidateNameShort()
        {
            Actor actor1 = new Actor("123", 1819, Genre.drama);
            Assert.ThrowsException<ArgumentException>(() => actor1.ValidateName());
        }
        [TestMethod()]
        public void ValidateLong()
        {
            Actor actor1 = new Actor("12345", 1819, Genre.drama);
            Assert.AreEqual(actor1.Name.Length, 5);
        }

        [TestMethod()]
        public void ValidateTest()
        {
            Actor actor1 = new Actor("12345", 2334, Genre.drama);
            actor1.Validate();
        }
    }
}
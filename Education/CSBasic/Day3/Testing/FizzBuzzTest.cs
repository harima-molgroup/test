using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CSBasic.Day3.Main;

namespace CSBasic.Day3.Testing
{
    [TestClass]
    public class FizzBuzzTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("A", "A");
        }

        [TestMethod]
        public void Fizzかどうか()
        {
            var fizzbuzz = new FizzBuzz(3, 5);

            Assert.AreEqual("fizz", fizzbuzz.Execute(3, 3, 5));
            Assert.AreEqual("fizz", fizzbuzz.Execute(6, 3, 5));
            Assert.AreEqual("fizz", fizzbuzz.Execute(9, 3, 5));
            Assert.AreEqual("fizz", fizzbuzz.Execute(12, 3, 5));
            //Assert.AreEqual("fizz", fizzbuzz.Execute(15, 3, 5));
        }

        [TestMethod]
        public void Buzzかどうか()
        {
            var fizzbuzz = new FizzBuzz(3, 5);

            Assert.AreEqual("buzz", fizzbuzz.Execute(5, 3, 5));
            Assert.AreEqual("buzz", fizzbuzz.Execute(10, 3, 5));
            Assert.AreEqual("buzz", fizzbuzz.Execute(20, 3, 5));
            Assert.AreEqual("buzz", fizzbuzz.Execute(25, 3, 5));
        }

        [TestMethod]
        public void FizzBuzzかどうか()
        {
            var fizzbuzz = new FizzBuzz(3, 5);

            Assert.AreEqual("fizzbuzz", fizzbuzz.Execute(15, 3, 5));
            Assert.AreEqual("fizzbuzz", fizzbuzz.Execute(30, 3, 5));
        }

        [TestMethod]
        public void どれでもない()
        {
            var fizzbuzz = new FizzBuzz(3, 5);

            Assert.AreEqual("1", fizzbuzz.Execute(1, 3, 5));
            Assert.AreEqual("4", fizzbuzz.Execute(4, 3, 5));
            Assert.AreEqual("7", fizzbuzz.Execute(7, 3, 5));
        }
    }
}

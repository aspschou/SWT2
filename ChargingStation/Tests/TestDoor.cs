using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Library;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestDoor
    {
        private Door _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Door();
        }

        [Test]
        public void UnlockDoorToDisplay()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            _uut.UnlockDoor();

            string expectedResult = "Door is unlocked" + "\r\n";

            Assert.That(output.ToString(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void LockDoorToDisplay()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            _uut.LockDoor();

            string expectedResult = "Door is locked" + "\r\n";

            Assert.That(output.ToString(), Is.EqualTo(expectedResult));
        }
    }
}
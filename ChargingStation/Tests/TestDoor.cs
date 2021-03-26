using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Library;
using Library.Interfaces;
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

        [Test]
        public void EventRaisedOnDoorOpened()
        {
            DoorOpenedEventArgs _receivedEventArgs = null;
            _uut.DoorOpenedEvent += (o,args) => { _receivedEventArgs = args; };

            _uut.OnDoorOpened();

            Assert.That(_receivedEventArgs, Is.Not.Null);
        }

        [Test]
        public void EventRaisedOnDoorClosed()
        {
            DoorClosedEventArgs _receivedEventArgs = null;
            _uut.DoorClosedEvent += (o, args) => { _receivedEventArgs = args; };

            _uut.OnDoorClosed();

            Assert.That(_receivedEventArgs, Is.Not.Null);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using Library;
using Library.Interfaces;
using NUnit.Framework;
using System.IO;

namespace Tests
{
    [TestFixture]
    public class TestDisplay
    {
        private Display _uut;
        [SetUp]
        public void Setup()
        {
            _uut = new Display();
        }

        [Test]
        [TestCase(MessageType.ConnectPhone, "Connect your phone" + "\r\n")]
        [TestCase(MessageType.ScanRFIDToOpen, "Scan your RFID tag to open" + "\r\n")]
        [TestCase(MessageType.ScanRFIDToLock, "Scan your RFID tag to lock" + "\r\n")]
        [TestCase(MessageType.ConnectionError, "Phone not properly connected, try again" + "\r\n")]
        [TestCase(MessageType.StationOccupied, "Station already in use" + "\r\n")]
        [TestCase(MessageType.RFIDError, "Tag can't be read" + "\r\n")]
        [TestCase(MessageType.TakePhone, "You may take your phone" + "\r\n")]
        [TestCase(MessageType.IsCharging, "The phone is currently charging" + "\r\n")]
        [TestCase(MessageType.FullyCharged, "The phone is fully charged. You can now remove it from the station" + "\r\n")]
        [TestCase(MessageType.CurrentWarning, "SOMETHING WENT WRONG, REMOVE PHONE" + "\r\n")]

        public void MessageTypeToDisplay(MessageType messageType, string expectedResult)
        {
            var output = new StringWriter();
            Console.SetOut(output);

            _uut.DisplayMsg(messageType);

            Assert.That(output.ToString(), Is.EqualTo(expectedResult));
        }
    }
}

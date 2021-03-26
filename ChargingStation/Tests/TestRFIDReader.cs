using System;
using System.Collections.Generic;
using System.Text;
using Library;
using Library.Interfaces;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestRFIDReader
    {
        private RFIDReader _uut;
        private RfidDetectedEventArgs _RFIDReaderEvent;

        [SetUp]
        public void Setup()
        {
            _uut = new RFIDReader();
            _uut.DetectIdEvent += (o, args) => _RFIDReaderEvent = args;
        }

        [Test]
        public void RFIDReaderEvent()
        {
            _uut.RfidRead(5);
            Assert.That(_RFIDReaderEvent.Id, Is.Not.Null);
        }
        
        [Test]
        public void RFIDCorrectID()
        {
            _uut.RfidRead(5);
            Assert.That(_RFIDReaderEvent.Id, Is.EqualTo(5));
        }   
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Library;
using NUnit.Framework;
using NSubstitute;
using Library.Interfaces;

namespace Tests
{
    [TestFixture]
    public class TestChargeControl
    {
        private ChargeControl _uut;
        private IDisplay _display;
        private IUsbCharger _usbCharger;

        [SetUp]
        public void Setup()
        {
            _usbCharger = Substitute.For<IUsbCharger>();
            _display = Substitute.For<IDisplay>();
            _uut = new ChargeControl(_display, _usbCharger);
        }

        // Test for usbCharger Connected
        [Test]
        public void Connected_IsConnected()
        {
            _usbCharger.Connected.Returns(true);
            Assert.That(_uut.IsConnected(), Is.True);
        }

        [Test]
        public void Connected_IsNotConnected()
        {
            _usbCharger.Connected.Returns(false);
            Assert.That(_uut.IsConnected(), Is.False);
        }

        // Test for StartCharge
        [Test] 
        public void StartCharge()
        {
            _uut.StartCharge();
            _usbCharger.Received(1).StartCharge();
        }

        // Test for StopCharge
        [Test]
        public void StopCharge()
        {
            _uut.StopCharge();
            _usbCharger.Received(1).StopCharge();
        }

        // Test for forskellige currents
        [TestCase(0)]
        public void ChargingCurrentValue_Zero(int current)
        {
            
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current});

            _display.Received(1).DisplayMsg(MessageType.ConnectionError);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void ChargingCurrent_BelowFive(int current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            _display.Received(1).DisplayMsg(MessageType.FullyCharged);
        }

        [TestCase(100)]
        [TestCase(250)]
        [TestCase(500)]
        public void ChargingCurrent_BetweenFiveandFiveHundred(int current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            _display.Received(1).DisplayMsg(MessageType.IsCharging);
        }

        [TestCase(550)]
        public void ChargingCurrent_AboveFiveHundred(int current)
        {
            _usbCharger.CurrentValueEvent += Raise.EventWith(new CurrentEventArgs() { Current = current });

            _display.Received(1).DisplayMsg(MessageType.CurrentWarning);
        }
    }
}

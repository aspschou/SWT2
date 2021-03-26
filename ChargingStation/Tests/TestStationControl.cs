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
    public class TestStationControl
    {
        private StationControl _uut;
        private IChargeControl _charger;
        private IDoor _door;
        private IDisplay _display;
        private ILog _log;
        private IRFIDReader _rfidReader;


        [SetUp]
        public void Setup()
        {
            _charger = Substitute.For<IChargeControl>();
            _door = Substitute.For<IDoor>();
            _display = Substitute.For<IDisplay>();
            _log = Substitute.For<ILog>();
            _rfidReader = Substitute.For<IRFIDReader>();
            _uut = new StationControl(_charger, _door, _rfidReader, _display, _log);
        }

        // Test for RfidDetected
        // hvor ChargingStationState = Available
        [Test]
        public void RfidDetected_Available_IsConnected()
        {
            _charger.IsConnected().Returns(true);
            _rfidReader.DetectIdEvent += Raise.EventWith(new RfidDetectedEventArgs() { Id = 2 });

            Assert.Multiple(() =>
            {
                _charger.Received().StartCharge();
                _door.Received().LockDoor();
                _display.Received().DisplayMsg(MessageType.ScanRFIDToOpen);
                _log.Received().LogDoorLocked(2);
            });
        }


        [Test]
        public void RfidDetected_Available_IsNotConnected()
        {
            _charger.IsConnected().Returns(false);
            _rfidReader.DetectIdEvent += Raise.EventWith(new RfidDetectedEventArgs() { Id = 2 });

            Assert.Multiple(() =>
            {
                _charger.DidNotReceive().StartCharge();
                _door.DidNotReceive().LockDoor();
                _display.Received().DisplayMsg(MessageType.ConnectionError);
                _log.DidNotReceive().LogDoorLocked(2);
            });
        }

        // Test for ID
        // Samme ID
        [Test]
        public void RfidDetected_Locked_CorrectID()
        {
            _charger.IsConnected().Returns(true);
            _rfidReader.DetectIdEvent += Raise.EventWith(new RfidDetectedEventArgs() { Id = 2 });
            _rfidReader.DetectIdEvent += Raise.EventWith(new RfidDetectedEventArgs() { Id = 2 });

            Assert.Multiple(() =>
            {
                _charger.Received().StopCharge();
                _door.Received().UnlockDoor();
                _display.Received().DisplayMsg(MessageType.TakePhone);
                _log.Received().LogDoorUnlocked(2);
            });
        }

        // To forskellige ID
        [Test]
        public void RfidDetected_Locked_WrongID()
        {
            _charger.IsConnected().Returns(true);
            _rfidReader.DetectIdEvent += Raise.EventWith(new RfidDetectedEventArgs() { Id = 2 });
            _rfidReader.DetectIdEvent += Raise.EventWith(new RfidDetectedEventArgs() { Id = 5 });

            Assert.Multiple(() =>
            {
                _charger.DidNotReceive().StopCharge();
                _door.DidNotReceive().UnlockDoor();
                _display.Received().DisplayMsg(MessageType.RFIDError);
                _log.DidNotReceive().LogDoorUnlocked(2);
            });
        }

        // Test for DoorOpened
        [Test]
        public void RfidDetected_WhileDoorOpened()
        {
            _door.DoorOpenedEvent += Raise.EventWith(new DoorOpenedEventArgs()); 
            _rfidReader.DetectIdEvent += Raise.EventWith(new RfidDetectedEventArgs() { Id = 2 });
            
            Assert.Multiple(() =>
            {
                _charger.DidNotReceive().StartCharge();
                _charger.DidNotReceive().StopCharge();
                _display.DidNotReceive().DisplayMsg(MessageType.RFIDError);
                _display.DidNotReceive().DisplayMsg(MessageType.ConnectionError);
            });

        }

    }
}

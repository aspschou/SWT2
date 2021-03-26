using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum ChargingStationState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private ChargingStationState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;
        private ILog _log;
        private IDisplay _display;
        private IRFIDReader _rfidReader;

        public StationControl(IChargeControl Charger, IDoor Door, IRFIDReader RfidReader, IDisplay Display, ILog Log)
        {
            _charger = Charger;
            _door = Door;
            _rfidReader = RfidReader;
            _log = Log;
            _display = Display;
            _state = ChargingStationState.Available;
            _door.DoorOpenedEvent += new EventHandler<DoorOpenedEventArgs>(HandleDoorOpened);
            _door.DoorClosedEvent += new EventHandler<DoorClosedEventArgs>(HandleDoorClosed);
            _rfidReader.DetectIdEvent += new EventHandler<RfidDetectedEventArgs>(HandleRFIDDetected);
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case ChargingStationState.Available:
                    // Check for ladeforbindelse
                    if (_charger.IsConnected())
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        _log.LogDoorLocked(id);

                        _display.DisplayMsg(MessageType.ScanRFIDToOpen);
                        _state = ChargingStationState.Locked;
                    }
                    else
                    {
                        _display.DisplayMsg(MessageType.ConnectionError);
                    }

                    break;

                case ChargingStationState.DoorOpen:
                    // Ignore
                    break;

                case ChargingStationState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        _log.LogDoorUnlocked(id);

                        _display.DisplayMsg(MessageType.TakePhone);

                        _state = ChargingStationState.Available;
                    }
                    else
                    {
                        _display.DisplayMsg(MessageType.RFIDError);
                    }

                    break;
            }
        }

        void HandleDoorOpened(object sender, DoorOpenedEventArgs e)
        {
            if (_state == ChargingStationState.Locked)
                Console.WriteLine("---Cant open Locked door---");
            else
            {
                _state = ChargingStationState.DoorOpen;
                if (!_charger.IsConnected())
                    _display.DisplayMsg(MessageType.ConnectPhone);
            }
        }

        
        void HandleDoorClosed(object sender, DoorClosedEventArgs e)
        {
            if (_state == ChargingStationState.DoorOpen)
            {
                _state = ChargingStationState.Available;
                if(_charger.IsConnected())
                    _display.DisplayMsg(MessageType.ScanRFIDToLock);
            }

            else
                Console.WriteLine("---Cant close Closed door---");
        }

        void HandleRFIDDetected(object sender, RfidDetectedEventArgs e)
        {
            RfidDetected(e.Id);
        }
    }
}

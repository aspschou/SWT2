using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public enum MessageType
            {
                ConnectPhone,
                ScanRFIDToOpen,
                ScanRFIDToLock,
                ConnectionError,
                StationOccupied,
                RFIDError,
                TakePhone,
                IsCharging,
                FullyCharged,
                CurrentWarning
            };

    public interface IDisplay
    {
        public void DisplayMsg(MessageType messageType);
    }
}

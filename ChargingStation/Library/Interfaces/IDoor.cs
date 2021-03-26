using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public class DoorOpenedEventArgs : EventArgs
    {
        
        public bool DoorOpened { set; get; }
    }

    public class DoorClosedEventArgs : EventArgs
    {
        public bool DoorClosed { set; get; }
    }

    public interface IDoor
    {
        public event EventHandler<DoorOpenedEventArgs> DoorOpenedEvent;

        public event EventHandler<DoorClosedEventArgs> DoorClosedEvent;


        void OnDoorOpened();

        void OnDoorClosed();

        void LockDoor();

        void UnlockDoor();
        
    }
}

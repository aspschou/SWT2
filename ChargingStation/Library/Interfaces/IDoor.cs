using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public class DoorOpenedEventArgs : EventArgs
    { }

    public class DoorClosedEventArgs : EventArgs
    { }

    public interface IDoor
    {

        public event EventHandler<DoorOpenedEventArgs> DoorOpenedEvent;
        public event EventHandler<DoorClosedEventArgs> DoorClosedEvent;

        void LockDoor();
        void UnlockDoor();
    }
}

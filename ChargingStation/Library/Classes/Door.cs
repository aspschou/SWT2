using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library
{
    public class Door : IDoor
    {
        public event EventHandler<DoorOpenedEventArgs> DoorOpenedEvent;
        public event EventHandler<DoorClosedEventArgs> DoorClosedEvent;
        

        public void LockDoor()
        {
            Console.WriteLine("Door is locked");
        }

        public void UnlockDoor()
        {
            Console.WriteLine("Door is unlocked");
        }

        public virtual void OnDoorOpened()
        {
            DoorOpenedEvent?.Invoke(this, new DoorOpenedEventArgs());
        }

        public virtual void OnDoorClosed()
        {
            DoorClosedEvent?.Invoke(this, new DoorClosedEventArgs());
        }

    }

}

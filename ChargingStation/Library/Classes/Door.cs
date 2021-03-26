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

        enum Lock 
        { 
            Locked, 
            Unlocked
        };


        public event EventHandler<DoorOpenedEventArgs> DoorOpenedEvent;
        public event EventHandler<DoorClosedEventArgs> DoorClosedEvent;

       private Lock _Lock;

        public Door()
        {
            _Lock = Lock.Locked;
   
        }

        public void OnDoorClosed()
        {
            throw new NotImplementedException();
        }

        public void OnDoorOpened()
        {
            throw new NotImplementedException();
        }

        public void LockDoor()
        {
            _Lock = Lock.Locked;
            Console.WriteLine("Door is locked");
        }

        public void UnlockDoor()
        {
            _Lock = Lock.Unlocked;
            Console.WriteLine("Door is Unlocked");
        }

        protected virtual void OnDoorOpened(DoorOpenedEventArgs e)
        {
            DoorOpenedEvent?.Invoke(this, e);
        }

        protected virtual void OnDoorClosed(DoorClosedEventArgs e)
        {
            DoorClosedEvent?.Invoke(this, e);
        }

    }

}

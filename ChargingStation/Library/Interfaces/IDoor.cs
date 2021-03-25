using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public class DoorEventArgs : EventArgs
    {
        
        public bool IsDoorOpen { set; get; }
    }


    public interface IDoor
    {
        event EventHandler<DoorEventArgs> DoorStateEvent;
        void DoorOpened();

        void DoorClosed();

        void LockDoor();

        void UnlockDoor();
        
    }
}

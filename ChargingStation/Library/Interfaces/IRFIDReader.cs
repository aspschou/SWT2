using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public class RfidDetectedEventArgs : EventArgs
    {
        public int Id { set; get; }
    }

    public interface IRFIDReader
    {
        public event EventHandler<RfidDetectedEventArgs> DetectIdEvent;
        public void RfidRead(int Id);
    }

}

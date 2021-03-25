using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library
{
    public class RFIDReader : IRFIDReader
    {
        public event EventHandler<RfidDetectedEventArgs> DetectIdEvent;
        
        protected virtual void OnRfidRead(RfidDetectedEventArgs e)
        {
            DetectIdEvent?.Invoke(this, e);
        }
        public void RfidRead(int Id)
        {
            OnRfidRead(new RfidDetectedEventArgs { Id = Id });
        }

    }
}

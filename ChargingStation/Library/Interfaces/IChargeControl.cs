using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface IChargeControl
    {
        bool Connected { get; }

        bool IsConnected();
        void StartCharge();
        void StopCharge();
    }
}

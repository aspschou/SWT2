using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    interface ILog
    {
        public void LogDoorLocked(int Id);
        public void LogDoorUnlocked(int Id);
    }
}

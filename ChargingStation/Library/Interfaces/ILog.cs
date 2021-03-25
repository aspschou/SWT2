using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Interfaces
{
    public interface ILog
    {
        void LogDoorLocked(int Id);
        void LogDoorUnlocked(int Id);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library
{
    public class Log : ILog
    {
        public Log(string filename) { logFile = filename; }
        private string logFile; // Navnet på systemets log-fil


        public void LogDoorLocked(int Id)
        {
            using (var writer = File.AppendText(logFile))
            {
                writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", Id);
            }
            
        }

        public void LogDoorUnlocked(int Id)
        {
            using (var writer = File.AppendText(logFile))
            {
                writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", Id);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library
{
     class Display : IDisplay
    {

        public void DisplayMsg(MessageType messageType)
        {

            switch(messageType)
            {
                case MessageType.ConnectPhone:
                    Console.WriteLine("Connect your phone");
                    break;
                case MessageType.ScanRFID:
                    Console.WriteLine("Scan your RFID tag");
                    break;
                case MessageType.ConnectionError:
                    Console.WriteLine("Phone not properly connected, try again");
                    break;
                case MessageType.StationOccupied:
                    Console.WriteLine("Station already in use");
                    break;
                case MessageType.RFIDError:
                    Console.WriteLine("Tag can't be read");
                    break;
                case MessageType.TakePhone:
                    Console.WriteLine("You may take your phone");
                    break;
                case MessageType.IsCharging:
                    Console.WriteLine("The phone is currently charging");
                    break;
                case MessageType.FullyCharged:
                    Console.WriteLine("The phone is fully charged. You can now remove it from the station");
                    break;
                case MessageType.CurrentWarning:
                    Console.WriteLine("SOMETHING WENT WRONG, REMOVE PHONE");
                    break;
            }
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using Library;
using UsbSimulator;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Door door = new Door();
            RFIDReader rfidReader = new RFIDReader();
            Display display = new Display();
            UsbChargerSimulator usbChargerSimulator = new UsbChargerSimulator();
            Log log = new Log("file.txt");

            ChargeControl chargeControl = new ChargeControl(display,usbChargerSimulator);
            StationControl stationControl = new StationControl(chargeControl, door, rfidReader, display, log);
            // Assemble your system here from all the classes


            bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast F, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'F':
                        finish = true;
                        break;

                    case 'O':
                        door.OnDoorOpened();
                        break;

                    case 'C':
                        door.OnDoorClosed();
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string idString = System.Console.ReadLine();

                        int id = Convert.ToInt32(idString);
                        rfidReader.RfidRead(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }
}



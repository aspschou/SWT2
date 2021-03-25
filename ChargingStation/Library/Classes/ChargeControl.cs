using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library
{
    class ChargeControl
    {
        private IUsbCharger _usbCharger;
        private IDisplay _display;

        public ChargeControl(IDisplay display)
        {
            _display = display;
        }

        bool IsConnected()
        {
            return _usbCharger.Connected;
        }


        void StartCharge()
        {
            _usbCharger.StartCharge();
        }

        void StopCharge()
        {
            _usbCharger.StopCharge();
        }

        void newCurrentEvent(object sender, CurrentEventArgs e)
        {
            if (e.Current == 0)
            {
                _display.Display(MessageType.ConnectionError);
            }
            else if (0 < e.Current && e.Current < 5)
            {
                _display.Display(MessageType.FullyCharged);
            }
            else if (5 < e.Current && e.Current < 500)
            {
                _display.Display(MessageType.IsCharging);
            }
            else if (e.Current > 500)
            {
                StopCharge();
                _display.Display(MessageType.CurrentWarning);
            }
        }
    }
}

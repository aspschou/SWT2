using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Library.Interfaces;

namespace Library
{
    public class ChargeControl : IChargeControl
    {
        private IUsbCharger _usbCharger;
        private IDisplay _display;

        public ChargeControl(IDisplay display)
        {
            _display = display;
        }

        public bool IsConnected()
        {
            return _usbCharger.Connected;
        }


        public void StartCharge()
        {
            _usbCharger.StartCharge();
        }

        public void StopCharge()
        {
            _usbCharger.StopCharge();
        }

        void newCurrentEvent(object sender, CurrentEventArgs e)
        {
            if (e.Current == 0)
            {
                _display.DisplayMsg(MessageType.ConnectionError);
            }
            else if (0 < e.Current && e.Current < 5)
            {
                _display.DisplayMsg(MessageType.FullyCharged);
            }
            else if (5 < e.Current && e.Current < 500)
            {
                _display.DisplayMsg(MessageType.IsCharging);
            }
            else if (e.Current > 500)
            {
                StopCharge();
                _display.DisplayMsg(MessageType.CurrentWarning);
            }
        }
    }
}

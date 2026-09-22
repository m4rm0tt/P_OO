using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class Ticket
    {
        private DateTime _arrivedTime;
        private DateTime _leavedTime;

        private int _amount;

        public Ticket()
        {
            _arrivedTime = DateTime.Now;
        }

        public void DeleteTicket()
        {
            CalculPrice();   
        }

        private void CalculPrice()
        {
            _leavedTime = _arrivedTime + TimeSpan.FromHours(1); // Futur Random, mais pour l'instant en dur car je ne vais pas m'eparpier sur tout le code maintenant.

            TimeSpan total = _leavedTime - _arrivedTime;

            _amount = (int)(Math.Floor(total.TotalHours) * Parking.TicketPrice);
        }
    }
}

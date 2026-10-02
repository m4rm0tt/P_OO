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

        public int Amount { get; private set; }
        public TimeSpan Total { get; private set; }

        public Ticket()
        {
            _arrivedTime = DateTime.Now;
        }

        public void Close()
        {
            CalculPrice();  
            
            
        }

        private void CalculPrice()
        {
            _leavedTime = _arrivedTime + TimeSpan.FromHours(1); // Futur Random, mais pour l'instant en dur car je ne vais pas m'eparpier sur tout le code maintenant.

            Total = _leavedTime - _arrivedTime;

            Amount = (int)(Math.Floor(Total.TotalHours) * Parking.TicketPrice);
        }
    }
}

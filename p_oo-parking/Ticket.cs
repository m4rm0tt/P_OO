using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class Ticket
    {
        public DateTime ArrivedTime { get; }
        private DateTime _leavedTime;

        public int Amount { get; private set; }
        public TimeSpan Total { get; private set; }

        public Ticket()
        {
            ArrivedTime = DateTime.Now;
        }

        public void Close()
        {
            CalculPrice();
        }

        public void CalculPrice()
        {
            _leavedTime = ArrivedTime + TimeSpan.FromHours(1); // Futur Random, mais pour l'instant en dur car je ne vais pas m'eparpier sur tout le code maintenant.

            Total = _leavedTime - ArrivedTime;

            Amount = (int)(Math.Floor(Total.TotalHours) * Parking.TicketPrice);
        }
    }
}

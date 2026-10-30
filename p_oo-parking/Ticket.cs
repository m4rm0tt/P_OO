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

        private string _plate;
        private ParkingSpace _parkingSpace;

        public int Amount { get; private set; }
        public TimeSpan Total { get; private set; }

        public Ticket(string plate, ParkingSpace parkingSpace)
        {
            ArrivedTime = DateTime.Now;
            _plate = plate;
            _parkingSpace = parkingSpace;
            
            ShowTicket();
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
        
        public void ShowTicket(bool close = false)
        {
            Console.WriteLine("========== TICKET ==========");
            Console.WriteLine($"- Plaque : {_plate}");
            Console.WriteLine($"- Place : {_parkingSpace.Number}");
            Console.WriteLine($"- Heure d'arrivé : {ArrivedTime.TimeOfDay}");

            if (close)
            {
                Console.WriteLine($"- Heure de départ : {_leavedTime.TimeOfDay}");
                Console.WriteLine($"- Durée : {Total}");
                Console.WriteLine($"- Montant : {Amount}");
            }
            
        }
    }
}

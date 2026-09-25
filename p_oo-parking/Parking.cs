using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class Parking
    {
        private List<Car> _cars;
        public List<ParkingSpace> _parkingSpaces { get; private set; }

        static public int TicketPrice { get; private set; } = 5; // Par Heure

        public Parking()
        {
            _cars = new List<Car>();
            _parkingSpaces = new List<ParkingSpace>();

            for (int i = 0; i < 10; i++)
            {
                _parkingSpaces.Add(new ParkingSpace(_parkingSpaces.Count));
            }
            //Mettre dans test.
        }
    }
}

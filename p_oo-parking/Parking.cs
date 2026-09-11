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
        private List<ParkingSpace> _parkingSpaces;

        public Parking()
        {
            _cars = new List<Car>();
            _parkingSpaces = new List<ParkingSpace>();
        }
    }
}

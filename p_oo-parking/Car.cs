using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class Car
    {
        private Ticket _ticket;
        private ParkingSpace _parkingSpace;

        private string _plate;

        public Car(ParkingSpace parkingSpace, string plate)
        {
            _ticket = new Ticket();
            _parkingSpace = parkingSpace;
            _plate = plate;
        }
    }
}

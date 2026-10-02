using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class Car
    {
        public Ticket Ticket { get; private set; }
        public ParkingSpace ParkingSpace { get; private set; }

        public string Plate { get; private set; }

        public Car(ParkingSpace parkingSpace, string plate)
        {
            Ticket = new Ticket();
            ParkingSpace = parkingSpace;
            Plate = plate;
        }
    }
}

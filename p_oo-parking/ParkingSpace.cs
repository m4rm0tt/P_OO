using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class ParkingSpace
    {
        private int _number;
        private bool _isOccupied;

        public ParkingSpace(Parking p)
        {
            _number = p._parkingSpaces.Count + 1;

            // Console.WriteLine(_number); Mettre dans un test.

            _isOccupied = false;
        }
    }
}

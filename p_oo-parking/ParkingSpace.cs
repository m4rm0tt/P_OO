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

        public ParkingSpace(int SpaceNumber)
        {
            _number = SpaceNumber;
            _isOccupied = false;
        }
    }
}

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

        public ParkingSpace(int c)
        {
            _number = c + 1;

            //Console.WriteLine(_number); Mettre dans un test.

            _isOccupied = false;
        }
    }
}

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
        public bool IsOccupied { get; private set; }

        public ParkingSpace(int c)
        {
            _number = c + 1;

            //Console.WriteLine(_number); Mettre dans un test.

            IsOccupied = false;
        }
        
        public void SetOccupied(bool newState)
        {
            IsOccupied = newState;
        }
    }
}

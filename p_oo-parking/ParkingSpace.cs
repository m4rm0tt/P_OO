using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class ParkingSpace
    {
        public int Number { get; private set; }
        public bool IsOccupied { get; private set; }

        public ParkingSpace(int c)
        {
            Number = c + 1;

            //Console.WriteLine(_number); Mettre dans un test.

            IsOccupied = false;
        }
        
        public void SetOccupied(bool newState)
        {
            IsOccupied = newState;
        }
    }
}

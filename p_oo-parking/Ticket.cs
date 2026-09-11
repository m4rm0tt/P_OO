using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_oo_parking
{
    internal class Ticket
    {
        private DateTime _arrivedTime;
        private DateTime _leavedTime;

        private int _amount;

        public Ticket()
        {
            _arrivedTime = DateTime.Now;
        }
    }
}

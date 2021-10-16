using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGeneratorApp
{
    public class Ride
    {
        public double distance;
        public int time;
        //creating Parameterized constructor
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}

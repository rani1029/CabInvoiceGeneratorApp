using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGeneratorApp
{
    public class InvoiceGenerator
    {
        RideType ridetype;
        private readonly RideRepository rideRepository;

        // constants Declaration
        private readonly double MIN_COST_PER_KM;
        private readonly double COST_PER_TIME;
        private readonly double MIN_FAIR;
        //constructor
        public InvoiceGenerator(RideType ridetype)
        {
            this.ridetype = ridetype;
            //private RideRepository rideRepository;
            try
            {
                //constant if Ridetype is normal
                if (this.ridetype.Equals(RideType.NORMAL))
                {
                    this.MIN_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MIN_FAIR = 5;
                }
                if (this.ridetype.Equals(RideType.PREMIUM))
                {
                    this.MIN_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MIN_FAIR = 20;
                }
            }
            //if ridetype is invalid
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }
        public double CalculateFare(double distance, int time)
        {
            double totalFair = 0;
            try
            {
                totalFair = distance * MIN_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            //if total fare is less than minimum fare 
            return Math.Max(totalFair, MIN_FAIR);
        }
        //return type is invoicesummary class
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }

            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Rides are Null");
                }
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User Id");
            }
        }
    }
}


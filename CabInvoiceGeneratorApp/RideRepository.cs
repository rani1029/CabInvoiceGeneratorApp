using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGeneratorApp
{
    public class RideRepository
    {
        //Dictionary to store UserId and Rides List
        Dictionary<string, List<Ride>> userRides = null;

        //Constructor to Initialize Dictionary
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        //Function to add rides list to specify userId into array
        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Rides are Null");
            }
        }

        //Function to get Rides List as an array for specified UserID
        public Ride[] GetRides(string userId)
        {
            try
            {
                return this.userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserId");
            }
        }
    }
}

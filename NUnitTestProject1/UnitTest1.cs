using NUnit.Framework;
using CabInvoiceGeneratorApp;

namespace NUnitTestProject1
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;
        //uc1 test for checking CalculateFare method
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //Creating Instance of Invoice Generator  For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            //Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            //Asserting Values
            Assert.AreEqual(expected, fare);
        }
        [Test]
        //uc2 checking calculate fare function for multiple ride invoice summary
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            //Creating Instance of Invoice Generator  For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            //Generating Summary for Rides
            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            //Asserting Values
            Assert.AreEqual(expectedSummary, invoiceSummary);

        }
    }
}
using System;

namespace CabInvoiceGeneratorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To CAB Invoice Generator!");
            //uc-1 
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0, 5);
            Console.WriteLine("Fare=" + fare);
        }
    }
}

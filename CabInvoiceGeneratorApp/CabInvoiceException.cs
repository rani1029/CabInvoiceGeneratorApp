using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGeneratorApp
{

    public class CabInvoiceException : Exception
    {
        public ExceptionType type;
        public CabInvoiceException(ExceptionType type, String messange) : base(messange)
        {
            this.type = type;
        }
        public enum ExceptionType
        {
            INVALID_DISTANCE,
            INVALID_TIME,
            INVALID_RIDE_TYPE,
            NULL_RIDE
        }
    }


}
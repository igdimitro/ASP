using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuitarShop.App_Code
{
    public class DTDException : Exception
    {
        public DTDException(string msg) : base(msg) { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuitarShop.App_Code
{
    public class XMLParserException: Exception
    {
        public XMLParserException(string msg) : base(msg) { }
    }
}


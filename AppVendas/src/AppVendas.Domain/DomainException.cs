using System;
using System.Collections.Generic;
using System.Text;

namespace AppVendas.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string error) : base(error)
        {

        }
        public static void When(bool valid, string error)
        {
            if (!valid) throw new DomainException(error);
        }
    }
}

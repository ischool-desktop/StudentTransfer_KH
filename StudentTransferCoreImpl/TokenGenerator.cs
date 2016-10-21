using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentTransferCoreImpl
{
    internal static class TokenGenerator
    {
        public static  string Random()
        {
            Guid g = Guid.NewGuid();
            return g.ToString().Split('-')[0].ToUpper();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCH.Domain.Exceptions
{
    public class InfoIsNotInJsonFormatException:Exception
    {
        public InfoIsNotInJsonFormatException(string value, Exception ex)
            :base($"The info cannot be created from non Json format. Current value: {value}", ex)
        {

        }
    }
}

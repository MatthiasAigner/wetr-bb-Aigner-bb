using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wetr.Simulator
{
    public class ChartValuePairs
    {
        public ChartValuePairs(DateTime time, double value)
        {
            Time = time;
            Value = value;
        }

        public DateTime Time { get; set; }
        public double Value { get; set; }
    }
}

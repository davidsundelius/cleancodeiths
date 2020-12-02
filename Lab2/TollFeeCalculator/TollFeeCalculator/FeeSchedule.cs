using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
    public class FeeSchedule
    {
        public readonly TimeSpan endTime;
        public readonly int fee;

        public FeeSchedule(TimeSpan endtime, int fee)
        {
            this.endTime = endtime;
            this.fee = fee;
        }
    }
}

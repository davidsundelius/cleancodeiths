using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculator
{
    public class TollFee
    {
        public readonly TimeSpan endTime;
        public readonly int fee;

        public TollFee(TimeSpan endtime, int fee)
        {
            this.endTime = endtime;
            this.fee = fee;
        }

        internal static readonly TollFee[] feeSchedule = new[]
        {
            new TollFee(new TimeSpan(6,0,0), 0),
            new TollFee(new TimeSpan(6,30,0), 8),
            new TollFee(new TimeSpan(7,0,0), 13),
            new TollFee(new TimeSpan(8,0,0), 18),
            new TollFee(new TimeSpan(8,30,0), 13),
            new TollFee(new TimeSpan(15,0,0), 8),
            new TollFee(new TimeSpan(15,30,0), 13),
            new TollFee(new TimeSpan(17,0,0), 18),
            new TollFee(new TimeSpan(18,0,0), 13),
            new TollFee(new TimeSpan(18,30,0), 8),
        };
    }
}

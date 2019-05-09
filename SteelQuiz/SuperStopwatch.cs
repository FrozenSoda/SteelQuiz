using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteelQuiz
{
    public class SuperStopwatch : Stopwatch
    {
        public TimeSpan StartOffset { get; set; } = new TimeSpan();

        public new long ElapsedMilliseconds
        {
            get
            {
                return base.ElapsedMilliseconds + (long)StartOffset.TotalMilliseconds;
            }
        }

        public new long ElapsedTicks
        {
            get
            {
                return base.ElapsedTicks + StartOffset.Ticks;
            }
        }

        public new void Reset()
        {
            StartOffset = new TimeSpan();
            base.Reset();
        }

        public void Reset(TimeSpan startOffset)
        {
            StartOffset = startOffset;
            base.Reset();
        }
    }
}

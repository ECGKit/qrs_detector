namespace QrsDetectorManaged
{
    using System;
    using System.Linq;

    public static class QrsDetector
    {
        public static int[] Detect(double[] signal, double samplingRate)
        {
            if (signal == null)
                throw new ArgumentNullException("signal");

            if (signal.Length == 0)
                throw new ArgumentException("signal");

            if (samplingRate <= 1.0)
                throw new ArgumentException("samplingRate");

            var positions = new byte[signal.Length];
            var count = Native.DetectQrsPeaks(signal, signal.Length, positions, samplingRate);
            if (count > 0)
            {
                return positions.Select((r, i) => new { i, r })
                    .Where(t => t.r == Native.MARK_QRS)
                    .Select(t => t.i)
                    .ToArray();
            }
            else
            {
                return new int[0];
            }
        }
    }
}

// References:
// [LINQ to find array indexes of a value](https://stackoverflow.com/questions/13291788/linq-to-find-array-indexes-of-a-value)
// [Get indexes of all matching values from list using Linq](https://stackoverflow.com/questions/13055391/get-indexes-of-all-matching-values-from-list-using-linq)

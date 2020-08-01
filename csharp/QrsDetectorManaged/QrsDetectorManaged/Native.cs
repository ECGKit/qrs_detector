namespace QrsDetectorManaged
{
    using System;
    using System.Runtime.InteropServices;

    internal static class Native
    {
        public const byte MARK_NO_QRS = 0;
        public const byte MARK_QRS = 1;

        [DllImport("qrs_detector.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "DetectQrsPeaks")]
        public static extern int DetectQrsPeaks([In] double[] signal, int length, [Out] byte[] positions, double samplingRate);
    }
}

// References:
// [Passing a char array from c# to c++ dll](https://stackoverflow.com/questions/38146181/passing-a-char-array-from-c-sharp-to-c-dll)

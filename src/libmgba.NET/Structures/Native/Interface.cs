
using System.Runtime.InteropServices;

namespace libmgba.NET
{
    public enum RTCGenericType
    {
        RTC_NO_OVERRIDE = 0,
        RTC_FIXED = 1,
        RTC_FAKE_EPOCH = 2,
        RTC_CUSTOM_START = 0x1000
    }

    public enum CoreFeature
    {
        CORE_FEATURE_OPENGL = 1,
    };

    public struct RTCSource
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void sample(ref RTCSource src);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long unixTime(ref RTCSource src);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void serialize(ref RTCSource src, ref StateExtdataItem item);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool deserialize(ref RTCSource src, ref StateExtdataItem item);
    };

    public struct RTCGenericSource
    {
        public RTCSource d;
        // Core*
        public IntPtr p;
        public RTCGenericType Override;
        public long value;
        // RTCSource*
        public IntPtr custom;
    }
}

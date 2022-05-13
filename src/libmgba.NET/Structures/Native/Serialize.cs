
namespace libmgba.NET
{
    public enum StateExtdataTag
    {
        EXTDATA_NONE = 0,
        EXTDATA_SCREENSHOT = 1,
        EXTDATA_SAVEDATA = 2,
        EXTDATA_CHEATS = 3,
        EXTDATA_RTC = 4,
        EXTDATA_META_TIME = 0x101,
        EXTDATA_META_CREATOR = 0x102,
        EXTDATA_MAX = 0x103
    }

    public struct StateExtdataItem
    {
        public int size;
        public IntPtr data;
        public delegate void clean(IntPtr data);
    }

    public struct StateExtdata
    {
        // mStateExtdataItem data[EXTDATA_MAX]
        public IntPtr data;
    }
}

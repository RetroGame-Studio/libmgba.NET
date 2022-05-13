
namespace libmgba.NET
{
    public static partial class MGBA
    {
        // Interface
        public const int BYTES_PER_PIXEL = 4;

        // Serialize
        public const int SAVESTATE_SCREENSHOT = 1;
        public const int SAVESTATE_SAVEDATA = 2;
        public const int SAVESTATE_CHEATS = 4;
        public const int SAVESTATE_RTC = 8;
        public const int SAVESTATE_METADATA = 16;
    }
}

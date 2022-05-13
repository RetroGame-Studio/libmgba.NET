#if _WIN64
    using size_t = UInt64;
#else
    using size_t = System.UInt32;
#endif


namespace libmgba.NET
{
	public struct InputMap
    {
        // InputMapImpl*
        public IntPtr maps;
        size_t numMaps;
        // InputPlatformInfo*
        public IntPtr info;
    };
}

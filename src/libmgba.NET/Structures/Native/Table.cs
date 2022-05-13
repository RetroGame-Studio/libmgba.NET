#if _WIN64
    using size_t = UInt64;
#else
    using size_t = System.UInt32;
#endif

using System.Runtime.InteropServices;

namespace libmgba.NET
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void deinitializer(IntPtr ptr);

    public unsafe partial struct Table
    {
        // TableList
        public Table* table;
        public size_t tableSize;
        public size_t size;
        public IntPtr deinitializer;
        public uint seed;
    }
}

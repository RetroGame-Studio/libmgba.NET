#if _WIN64
    using size_t = UInt64;
#else
    using size_t = System.UInt32;
#endif

using System.Runtime.InteropServices;

namespace libmgba.NET
{
    public enum MapMode
    {
        MAP_READ = 1,
        MAP_WRITE = 2
    }

    public enum VFSType
    {
        VFS_UNKNOWN = 0,
        VFS_FILE = 1,
        VFS_DIRECTORY = 2
    }

    public struct VFile
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool close(ref VFile vf);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long seek(ref VFile vf, long offset, int whence);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate size_t read(ref VFile vf, IntPtr buffer, size_t size);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate size_t readline(ref VFile vf, string buffer, size_t size);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate size_t write(ref VFile vf, IntPtr buffer, size_t size);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr map(ref VFile vf, size_t size, int flags);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void unmap(ref VFile vf, IntPtr memory, size_t size);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void truncate(ref VFile vf, size_t size);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate size_t size(ref VFile vf);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool sync(ref VFile vf, IntPtr buffer, size_t size);
    };

    public struct VDirEntry
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate string name(ref VDirEntry vde);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate VFSType type(ref VDirEntry vde);
    }

    public struct VDir
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool close(ref VDir vd);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void rewind(ref VDir vd);
        // return VDirEntry*
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr listNext(ref VDir vd);
        // return VFile*
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr openFile(ref VDir vd, string name, int mode);
        // return VDir*
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr openDir(ref VDir vd, string name);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool deleteFile(ref VDir vd, string name);
    };
}

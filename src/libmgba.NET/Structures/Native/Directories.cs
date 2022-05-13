
namespace libmgba.NET
{
    public struct DirectorySet
    {
        public string baseName;
        // VDir*
        public IntPtr Base;
        public IntPtr archive;
        public IntPtr save;
        public IntPtr patch;
        public IntPtr state;
        public IntPtr screenshot;
        public IntPtr cheats;
    }
}

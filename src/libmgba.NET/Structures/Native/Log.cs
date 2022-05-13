
namespace libmgba.NET
{
    public enum LogLevel
    {
        LOG_FATAL = 0x01,
        LOG_ERROR = 0x02,
        LOG_WARN = 0x04,
        LOG_INFO = 0x08,
        LOG_DEBUG = 0x10,
        LOG_STUB = 0x20,
        LOG_GAME_ERROR = 0x40,

        LOG_ALL = 0x7F
    }

    public unsafe delegate void _log(IntPtr logger, int category, LogLevel level, byte* format, byte* args);

    public unsafe partial struct Logger
    {
        public IntPtr log;
        public IntPtr filter;
    }
    public unsafe partial struct LoggerPtr
    {
        public Logger* NativePtr { get; }
        public LoggerPtr(Logger* nativePtr) => NativePtr = nativePtr;
        public LoggerPtr(IntPtr nativePtr) => NativePtr = (Logger*)nativePtr;
        public LoggerPtr(Logger structure) => NativePtr = (LoggerPtr)MarshalHelper.StructureToIntPtr(structure);
        public LoggerPtr(Logger[] structureArray) => NativePtr = (LoggerPtr)MarshalHelper.StructureArrayToIntPtr(structureArray);
        public static implicit operator LoggerPtr(Logger* nativePtr) => new LoggerPtr(nativePtr);
        public static implicit operator Logger*(LoggerPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator LoggerPtr(IntPtr nativePtr) => new LoggerPtr(nativePtr);
        public IntPtr Log => NativePtr->log;
    }

}

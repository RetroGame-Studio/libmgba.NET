
namespace libmgba.NET
{
    public enum VideoLoggerInjectionPoint
    {
        LOGGER_INJECTION_IMMEDIATE = 0,
        LOGGER_INJECTION_FIRST_SCANLINE = 1,
    }

    public enum DebuggerType
    {
        DEBUGGER_NONE = 0,
        DEBUGGER_CUSTOM = 1,
        DEBUGGER_CLI = 2,
        DEBUGGER_GDB = 3,
        DEBUGGER_MAX = 4
    }
}

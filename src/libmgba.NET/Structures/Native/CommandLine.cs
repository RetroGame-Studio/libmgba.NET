
using System.Runtime.InteropServices;
using ImGuiNET;

namespace libmgba.NET
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool parse(ref SubParser parser, int option, string arg);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool parseLong(ref SubParser parser, string option, string arg);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void apply(ref SubParser parser, ref CoreConfig config);

    public unsafe partial struct Arguments
    {
        public byte* FileName;
        public byte* Patch;
        public byte* CheatsFile;
        public byte* SaveState;
        public byte* Bios;
        public int LogLevel;
        public int FrameSkip;
        // Table
        public IntPtr ConfigOverrides;
        public DebuggerType DebuggerType;
        public bool DebugAtStart;
        public bool ShowHelp;
        public bool ShowVersion;
    }
    public unsafe partial struct ArgumentsPtr
    {
        public Arguments* NativePtr { get; }
        public ArgumentsPtr(Arguments* nativePtr) => NativePtr = nativePtr;
        public ArgumentsPtr(IntPtr nativePtr) => NativePtr = (Arguments*)nativePtr;
        public ArgumentsPtr(Arguments structure) => NativePtr = (ArgumentsPtr)MarshalHelper.StructureToIntPtr(structure);
        public ArgumentsPtr(Arguments[] structureArray) => NativePtr = (ArgumentsPtr)MarshalHelper.StructureArrayToIntPtr(structureArray);
        public static implicit operator ArgumentsPtr(Arguments* nativePtr) => new ArgumentsPtr(nativePtr);
        public static implicit operator Arguments*(ArgumentsPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator ArgumentsPtr(IntPtr nativePtr) => new ArgumentsPtr(nativePtr);
        public NullTerminatedString FileName => new NullTerminatedString(NativePtr->FileName);
    }

    public unsafe partial struct Option
    {
        public byte* Name;
        public bool Arg;
        public char ShortEquiv;
    }

    public unsafe partial struct SubParser
    {
        public byte* Usage;

        public IntPtr ParseFuncPtr;
        public IntPtr ParseLongFuncPtr;
        public IntPtr ApplyFuncPtr;
        
        public byte* ExtraOptions;
        // Option*
        public IntPtr LongOptions;
        public IntPtr Opts;
    }
    public unsafe partial struct SubParserPtr
    {
        public SubParser* NativePtr { get; }
        public SubParserPtr(SubParser* nativePtr) => NativePtr = nativePtr;
        public SubParserPtr(IntPtr nativePtr) => NativePtr = (SubParser*)nativePtr;
        public SubParserPtr(SubParser structure) => NativePtr = (SubParserPtr)MarshalHelper.StructureToIntPtr(structure);
        public SubParserPtr(SubParser[] structureArray) => NativePtr = (SubParserPtr)MarshalHelper.StructureArrayToIntPtr(structureArray);
        public static implicit operator SubParserPtr(SubParser* nativePtr) => new SubParserPtr(nativePtr);
        public static implicit operator SubParser*(SubParserPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator SubParserPtr(IntPtr nativePtr) => new SubParserPtr(nativePtr);
        public NullTerminatedString Usage => new NullTerminatedString(NativePtr->Usage);
    }

    public unsafe partial struct GraphicsOpts
    {
        public int Multiplier;
        public bool Fullscreen;
    }


}

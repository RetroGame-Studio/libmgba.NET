
using System.Runtime.CompilerServices;

namespace libmgba.NET
{
    public unsafe partial struct Blip_t
    {
        public UInt64 Factor;
        public UInt64 Offset;
        public int Avail;
        public int Size;
        public int Integrator;
    }
    public unsafe partial struct Blip_tPtr
    {
        public Blip_t* NativePtr { get; }
        public Blip_tPtr(Blip_t* nativePtr) => NativePtr = nativePtr;
        public Blip_tPtr(IntPtr nativePtr) => NativePtr = (Blip_t*)nativePtr;
        public static implicit operator Blip_tPtr(Blip_t* nativePtr) => new Blip_tPtr(nativePtr);
        public static implicit operator Blip_t*(Blip_tPtr wrappedPtr) => wrappedPtr.NativePtr;
        public static implicit operator Blip_tPtr(IntPtr nativePtr) => new Blip_tPtr(nativePtr);
        public ref UInt64 Factor => ref Unsafe.AsRef<UInt64>(&NativePtr->Factor);
    }
}


using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace libmgba.NET
{
    //public class AutoFreeStringPtr : CriticalFinalizerObject, IDisposable
    //{
    //    public IntPtr Ptr { get; private set; }

    //    public AutoFreeStringPtr(string managedString)
    //    {
    //        Ptr = Marshal.StringToHGlobalAnsi(managedString);
    //    }

    //    ~AutoFreeStringPtr()
    //    {
    //        if (Ptr != IntPtr.Zero)
    //        {
    //            Marshal.FreeHGlobal(Ptr);
    //            Ptr = IntPtr.Zero;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        if (Ptr != IntPtr.Zero)
    //        {
    //            Marshal.FreeHGlobal(Ptr);
    //            Ptr = IntPtr.Zero;
    //        }
    //        GC.SuppressFinalize(this);
    //    }

    //    public static implicit operator IntPtr(AutoFreeStringPtr autoFreeStringPtr)
    //    {
    //        return autoFreeStringPtr.Ptr;
    //    }
    //}

    //public class AutoFreeBufferPtr : CriticalFinalizerObject, IDisposable
    //{
    //    public IntPtr Ptr { get; private set; }

    //    public AutoFreeBufferPtr(int cb)
    //    {
    //        Ptr = Marshal.AllocHGlobal(cb);
    //    }

    //    ~AutoFreeBufferPtr()
    //    {
    //        if (Ptr != IntPtr.Zero)
    //        {
    //            Marshal.FreeHGlobal(Ptr);
    //            Ptr = IntPtr.Zero;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        if (Ptr != IntPtr.Zero)
    //        {
    //            Marshal.FreeHGlobal(Ptr);
    //            Ptr = IntPtr.Zero;
    //        }
    //        GC.SuppressFinalize(this);
    //    }

    //    public static implicit operator IntPtr(AutoFreeBufferPtr autoFreeBufferPtr)
    //    {
    //        return autoFreeBufferPtr.Ptr;
    //    }
    //}

    //public class AutoFreeStructPtr : CriticalFinalizerObject, IDisposable
    //{
    //    public IntPtr Ptr { get; private set; }

    //    public AutoFreeStructPtr(object obj)
    //    {
    //        Ptr = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
    //        Marshal.StructureToPtr(obj, Ptr, false);
    //    }

    //    ~AutoFreeStructPtr()
    //    {
    //        if (Ptr != IntPtr.Zero)
    //        {
    //            Marshal.FreeHGlobal(Ptr);
    //            Ptr = IntPtr.Zero;
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        if (Ptr != IntPtr.Zero)
    //        {
    //            Marshal.FreeHGlobal(Ptr);
    //            Ptr = IntPtr.Zero;
    //        }
    //        GC.SuppressFinalize(this);
    //    }

    //    public static implicit operator IntPtr(AutoFreeStructPtr autoFreeStructPtr)
    //    {
    //        return autoFreeStructPtr.Ptr;
    //    }
    //}

    public static class MarshalHelper
    {
        #region Public Methods

        public static void FreeMemory()
        {
            foreach (IntPtr ptr in s_ptrSet)
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        public static IntPtr StringArrayToIntPtr(string[] strArray)
        {
            if (strArray.Length <= 0)
            {
                return IntPtr.Zero;
            }
            IntPtr[] strPtrs = new IntPtr[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                strPtrs[i] = Marshal.StringToHGlobalAnsi(strArray[i]);
            }
            GCHandle handle = GCHandle.Alloc(strPtrs, GCHandleType.Pinned);
            try
            {
                return handle.AddrOfPinnedObject();
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }
        }

        public static IntPtr StructureToIntPtr<T>(T structure) where T : struct
        {

            IntPtr structurePtr = Marshal.AllocHGlobal(Marshal.SizeOf(structure));
            s_ptrSet.Add(structurePtr);
            Marshal.StructureToPtr(structure, structurePtr, false);
            return structurePtr;
        }

        public static T IntPtrToStructure<T>(IntPtr structurePtr) where T : struct
        {
            T structure = Marshal.PtrToStructure<T>(structurePtr);
            return structure;
        }

        public static IntPtr StructureArrayToIntPtr<T>(T[] structureArray) where T : struct
        {
            if (structureArray.Length <= 0)
            {
                return IntPtr.Zero;
            }
            IntPtr[] ptrs = new IntPtr[structureArray.Length];
            for (int i = 0; i < structureArray.Length; i++)
            {
                ptrs[i] = StructureToIntPtr(structureArray[i]);
            }
            GCHandle ptrHandle = GCHandle.Alloc(ptrs, GCHandleType.Pinned);
            try
            {
                return ptrHandle.AddrOfPinnedObject();
            }
            finally
            {
                if (ptrHandle.IsAllocated)
                {
                    ptrHandle.Free();
                }
            }
        }

        public static T[] IntPtrToStructureArray<T>(IntPtr ptr, int length) where T : struct
        {
            if (length <= 0)
            {
                return Array.Empty<T>();
            }
            int size = Marshal.SizeOf(typeof(T));
            T[] structureArray = new T[length];
            for (int i = 0; i < length; i++)
            {
                IntPtr ins = new(ptr.ToInt64() + i * size);
                structureArray[i] = IntPtrToStructure<T>(ins);
            }
            return structureArray;
        }

        #endregion

        private static HashSet<IntPtr> s_ptrSet = new HashSet<IntPtr>();
    }

}

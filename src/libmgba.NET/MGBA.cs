
using System.Diagnostics;
using System.Text;

namespace libmgba.NET
{
    public static unsafe partial class MGBA
    {
        #region Native-Wrapped API Methods

        public static void Usage(string arg0, string prologue, string epilogue, SubParserPtr subParserPtr, int nSubParsers)
        {
            byte* native_arg0;
            int arg0_byteCount = 0;
            if (arg0 != null)
            {
                arg0_byteCount = Encoding.UTF8.GetByteCount(arg0);
                if (arg0_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_arg0 = Util.Allocate(arg0_byteCount + 1);
                }
                else
                {
                    byte* native_arg0_stackBytes = stackalloc byte[arg0_byteCount + 1];
                    native_arg0 = native_arg0_stackBytes;
                }
                int native_arg0_offset = Util.GetUtf8(arg0, native_arg0, arg0_byteCount);
                native_arg0[native_arg0_offset] = 0;
            }
            else { native_arg0 = null; }

            byte* native_prologue;
            int prologue_byteCount = 0;
            if (prologue != null)
            {
                prologue_byteCount = Encoding.UTF8.GetByteCount(prologue);
                if (prologue_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_prologue = Util.Allocate(prologue_byteCount + 1);
                }
                else
                {
                    byte* native_prologue_stackBytes = stackalloc byte[prologue_byteCount + 1];
                    native_prologue = native_prologue_stackBytes;
                }
                int native_prologue_offset = Util.GetUtf8(prologue, native_prologue, prologue_byteCount);
                native_prologue[native_prologue_offset] = 0;
            }
            else { native_prologue = null; }

            byte* native_epilogue;
            int epilogue_byteCount = 0;
            if (epilogue != null)
            {
                epilogue_byteCount = Encoding.UTF8.GetByteCount(epilogue);
                if (epilogue_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_epilogue = Util.Allocate(epilogue_byteCount + 1);
                }
                else
                {
                    byte* native_epilogue_stackBytes = stackalloc byte[epilogue_byteCount + 1];
                    native_epilogue = native_epilogue_stackBytes;
                }
                int native_epilogue_offset = Util.GetUtf8(epilogue, native_epilogue, epilogue_byteCount);
                native_epilogue[native_epilogue_offset] = 0;
            }
            else { native_epilogue = null; }

            MGBA_Native.usage(native_arg0, native_prologue, native_epilogue, subParserPtr,  nSubParsers);
            if (arg0_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_arg0);
            }
            if (prologue_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_prologue);
            }
            if (epilogue_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_epilogue);
            }
        }

        public static void Version(string arg0)
        {
            byte* native_arg0;
            int arg0_byteCount = 0;
            if (arg0 != null)
            {
                arg0_byteCount = Encoding.UTF8.GetByteCount(arg0);
                if (arg0_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_arg0 = Util.Allocate(arg0_byteCount + 1);
                }
                else
                {
                    byte* native_arg0_stackBytes = stackalloc byte[arg0_byteCount + 1];
                    native_arg0 = native_arg0_stackBytes;
                }
                int native_arg0_offset = Util.GetUtf8(arg0, native_arg0, arg0_byteCount);
                native_arg0[native_arg0_offset] = 0;
            }
            else { native_arg0 = null; }
            MGBA_Native.version(native_arg0);
            if (arg0_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_arg0);
            }
        }

        public static void ArgumentsApply(ArgumentsPtr argsPtr, SubParserPtr subParsersPtr, int nSubParsers, IntPtr coreConfigPtr)
        {
            MGBA_Native.mArgumentsApply(argsPtr, subParsersPtr, nSubParsers, coreConfigPtr);
        }

        public static bool ArgumentsParse(ArgumentsPtr argsPtr, string[] argv, SubParserPtr subParsersPtr, int nSubParsers)
        {
            int* argv_byteCounts = stackalloc int[argv.Length];
            int argv_byteCount = 0;
            for (int i = 0; i < argv.Length; i++)
            {
                string s = argv[i];
                argv_byteCounts[i] = Encoding.UTF8.GetByteCount(s);
                argv_byteCount += argv_byteCounts[i] + 1;
            }
            byte* native_argv_data = stackalloc byte[argv_byteCount];
            int offset = 0;
            for (int i = 0; i < argv.Length; i++)
            {
                string s = argv[i];
                fixed (char* sPtr = s)
                {
                    offset += Encoding.UTF8.GetBytes(sPtr, s.Length, native_argv_data + offset, argv_byteCounts[i]);
                    native_argv_data[offset] = 0;
                    offset += 1;
                }
            }
            byte** native_argv = stackalloc byte*[argv.Length];
            offset = 0;
            for (int i = 0; i < argv.Length; i++)
            {
                native_argv[i] = &native_argv_data[offset];
                offset += argv_byteCounts[i] + 1;
            }
            return MGBA_Native.mArgumentsParse(argsPtr, argv.Length, native_argv, subParsersPtr, nSubParsers);
        }

        public static void ArgumentsFree(ArgumentsPtr argsPtr)
        {
            MGBA_Native.mArgumentsDeinit(argsPtr);
        }

        public static void LogSetDefaultLogger(LoggerPtr logger)
        {
            MGBA_Native.mLogSetDefaultLogger(logger);
        }

        public static void LogSetNoLog()
        {
            MGBA_Native.mLogSetNoLogLogger();
        }

        public static IntPtr CoreFind(string path)
        {
            byte* native_path;
            int path_byteCount = 0;
            if (path != null)
            {
                path_byteCount = Encoding.UTF8.GetByteCount(path);
                if (path_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_path = Util.Allocate(path_byteCount + 1);
                }
                else
                {
                    byte* native_arg0_stackBytes = stackalloc byte[path_byteCount + 1];
                    native_path = native_arg0_stackBytes;
                }
                int native_arg0_offset = Util.GetUtf8(path, native_path, path_byteCount);
                native_path[native_arg0_offset] = 0;
            }
            else { native_path = null; }
            IntPtr corePtr = MGBA_Native.mCoreFind(native_path);
            if (path_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_path);
            }
            return corePtr;

        }

        public static void Core_Init(IntPtr corePtr)
        {
            MGBA_Native.mCore_Init(corePtr);
        }

        public static void Core_DesiredVideoDimensions(IntPtr corePtr, out uint width, out uint height)
        {
            MGBA_Native.mCore_DesiredVideoDimensions(corePtr, out width, out height);
        }

        public static void Core_SetVideoBuffer(IntPtr corePtr, IntPtr frameBufferPtr, int bufferSize, uint stride)
        {
            MGBA_Native.mCore_SetVideoBuffer(corePtr, frameBufferPtr, new UIntPtr(stride));
        }

        public static bool CoreLoadFile(IntPtr corePtr, string path)
        {
            byte* native_path;
            int path_byteCount = 0;
            if (path != null)
            {
                path_byteCount = Encoding.UTF8.GetByteCount(path);
                if (path_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_path = Util.Allocate(path_byteCount + 1);
                }
                else
                {
                    byte* native_arg0_stackBytes = stackalloc byte[path_byteCount + 1];
                    native_path = native_arg0_stackBytes;
                }
                int native_arg0_offset = Util.GetUtf8(path, native_path, path_byteCount);
                native_path[native_arg0_offset] = 0;
            }
            else { native_path = null; }
            bool ret = MGBA_Native.mCoreLoadFile(corePtr, native_path);
            if (path_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_path);
            }
            return ret;
        }

        public static IntPtr CoreConfigGet(IntPtr corePtr)
        {
            return MGBA_Native.mCore_GetConfig(corePtr);
        }

        public static void CoreConfigInit(IntPtr coreConfigPtr, string port)
        {
            byte* native_port;
            int port_byteCount = 0;
            if (port != null)
            {
                port_byteCount = Encoding.UTF8.GetByteCount(port);
                if (port_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_port = Util.Allocate(port_byteCount + 1);
                }
                else
                {
                    byte* native_port_stackBytes = stackalloc byte[port_byteCount + 1];
                    native_port = native_port_stackBytes;
                }
                int native_port_offset = Util.GetUtf8(port, native_port, port_byteCount);
                native_port[native_port_offset] = 0;
            }
            else { native_port = null; }
            MGBA_Native.mCoreConfigInit(coreConfigPtr, native_port);
            if (port_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_port);
            }
        }

        public static bool CoreConfigLoad(IntPtr coreConfigPtr)
        {
            return MGBA_Native.mCoreConfigLoad(coreConfigPtr);
        }

        public static void CoreConfigSetDefaultValue(IntPtr coreConfigPtr, string key, string value)
        {
            byte* native_key;
            int key_byteCount = 0;
            if (key != null)
            {
                key_byteCount = Encoding.UTF8.GetByteCount(key);
                if (key_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_key = Util.Allocate(key_byteCount + 1);
                }
                else
                {
                    byte* native_key_stackBytes = stackalloc byte[key_byteCount + 1];
                    native_key = native_key_stackBytes;
                }
                int native_key_offset = Util.GetUtf8(key, native_key, key_byteCount);
                native_key[native_key_offset] = 0;
            }
            else { native_key = null; }
            byte* native_value;
            int value_byteCount = 0;
            if (value != null)
            {
                value_byteCount = Encoding.UTF8.GetByteCount(value);
                if (value_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_value = Util.Allocate(value_byteCount + 1);
                }
                else
                {
                    byte* native_value_stackBytes = stackalloc byte[value_byteCount + 1];
                    native_value = native_value_stackBytes;
                }
                int native_value_offset = Util.GetUtf8(value, native_value, value_byteCount);
                native_value[native_value_offset] = 0;
            }
            else { native_value = null; }
            MGBA_Native.mCoreConfigSetDefaultValue(coreConfigPtr, native_key, native_value);
            if (key_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_key);
            }
            if (value_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_value);
            }
        }

        public static void CoreLoadConfig(IntPtr corePtr)
        {
            MGBA_Native.mCoreLoadConfig(corePtr);
        }

        public static bool CoreConfigGetIntValue(IntPtr coreConfig, string key, IntPtr valuePtr)
        {
            byte* native_key;
            int key_byteCount = 0;
            if (key != null)
            {
                key_byteCount = Encoding.UTF8.GetByteCount(key);
                if (key_byteCount > Util.StackAllocationSizeLimit)
                {
                    native_key = Util.Allocate(key_byteCount + 1);
                }
                else
                {
                    byte* native_key_stackBytes = stackalloc byte[key_byteCount + 1];
                    native_key = native_key_stackBytes;
                }
                int native_key_offset = Util.GetUtf8(key, native_key, key_byteCount);
                native_key[native_key_offset] = 0;
            }
            else { native_key = null; }
            bool ret = MGBA_Native.mCoreConfigGetIntValue(coreConfig, native_key, valuePtr);
            if (key_byteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(native_key);
            }
            return ret;
        }

        public static void Core_Reset(IntPtr corePtr)
        {
            MGBA_Native.mCore_Reset(corePtr);
        }

        public static void Core_SetKeys(IntPtr corePtr, uint keys)
        {
            MGBA_Native.mCore_SetKeys(corePtr, keys);
        }

        public static void Core_RunFrame(IntPtr corePtr)
        {
            MGBA_Native.mCore_RunFrame(corePtr);
        }

        public static int Core_GetFrequency(IntPtr corePtr)
        {
            return MGBA_Native.mCore_Frequency(corePtr);
        }

        public static IntPtr Core_GetAudioChannel(IntPtr core, int ch)
        {
            return MGBA_Native.mCore_GetAudioChannel(core, ch);
        }

        public static void CoreConfigDeinit(IntPtr coreConfigPtr)
        {
            MGBA_Native.mCoreConfigDeinit(coreConfigPtr);
        }

        public static void Core_Deinit(IntPtr corePtr)
        {
            MGBA_Native.mCore_Deinit(corePtr);
        }

        public static void BlipSetRates(IntPtr blip, double clockRate, double sampleRate)
        {
            MGBA_Native.blip_set_rates(blip, clockRate, sampleRate);
        }

        public static int BlipSamplesAvail(IntPtr blip)
        {
            return MGBA_Native.blip_samples_avail(blip);
        }

        public static int BlipReadSamples(IntPtr blip, IntPtr outDataPtr, int count, bool stereo)
        {
            return MGBA_Native.blip_read_samples(blip, outDataPtr, count, stereo ? 1 : 0);
        }

        public static void BlipClear(IntPtr blip)
        {
            MGBA_Native.blip_clear(blip);
        }

        public static float GBA_AudioCalculateRatio(float inputSampleRate, float desiredFPS, float desiredSampleRate)
        {
            return MGBA_Native.GBAAudioCalculateRatio(inputSampleRate, desiredFPS, desiredSampleRate);
        }

        #endregion

        #region Custom Methods

        public static void FreeNativeMemory()
        {
            MarshalHelper.FreeMemory();
        }

        public static void ZeroMemory(IntPtr Safebuffer, int count)
        {
            if (count == 0) return;
            byte* buffer = (byte*)Safebuffer.ToPointer();
            ZeroMemory(buffer, count);
        }

        public static void ZeroMemory(byte* buffer, int count)
        {
            if (count == 0) return;
            while (count-- > 0)
            {
                buffer[count] = 0;
            }
        }

        public static short[] SampleBufferGet(IntPtr sampleBufferPtr, int sampleRate)
        {
            if (s_sampleBuffer == null)
            {
                s_sampleBuffer = new short[sampleRate];
            }
            else if (s_sampleBuffer.Length < sampleRate)
            {
                s_sampleBuffer = new short[sampleRate];
            }

            short* ptr = (short*)sampleBufferPtr.ToPointer();
            for (int i = 0; i < sampleRate; i++)
            {
                s_sampleBuffer[i] = ptr[i];
            }

            return s_sampleBuffer;
        }

        public static void FrameBufferIgnoreAlphaApply(IntPtr frameBufferPtr, int width, int height)
        {
            byte* ptr = (byte*)frameBufferPtr.ToPointer();

            int offset = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    ptr[offset + 3] = 255;
                    offset += 4;
                }
            }
        }

        public static byte[] FrameBufferBytesGet(IntPtr frameBufferPtr, int width, int height)
        {
            if (s_frameBufferBytes == null)
            {
                s_frameBufferBytes = new byte[width * height * BYTES_PER_PIXEL];
            }
            else if (s_frameBufferBytes.Length < width * height * BYTES_PER_PIXEL)
            {
                s_frameBufferBytes = new byte[width * height * BYTES_PER_PIXEL];
            }

            byte* ptr = (byte*)frameBufferPtr.ToPointer();

            int offset = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    s_frameBufferBytes[offset + 0] = ptr[offset + 0];
                    s_frameBufferBytes[offset + 1] = ptr[offset + 1];
                    s_frameBufferBytes[offset + 2] = ptr[offset + 2];
                    s_frameBufferBytes[offset + 3] = 255;
                    offset += 4;
                }
            }

            return s_frameBufferBytes;
        }

        public static MColor[,] FrameBufferPixelsGet(IntPtr frameBufferPtr, int width, int height)
        {
            if (s_frameBufferPixels == null)
            {
                s_frameBufferPixels = new MColor[height, width];
            }
            else if (s_frameBufferPixels.Length < width * height)
            {
                s_frameBufferPixels = new MColor[height, width];
            }

            byte* ptr = (byte*)frameBufferPtr.ToPointer();

            int offset = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {

                    byte r = ptr[offset + 0];
                    byte g = ptr[offset + 1];
                    byte b = ptr[offset + 2];
                    offset += 4;
                    s_frameBufferPixels[i, j] = new MColor(r, g, b);
                }
            }

            return s_frameBufferPixels;
        }

        #endregion

        #region Static Var

        private static byte[] s_frameBufferBytes;

        private static MColor[,] s_frameBufferPixels;

        private static short[] s_sampleBuffer;

        #endregion

    }
}

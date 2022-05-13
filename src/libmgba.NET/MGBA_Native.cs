

using System.Runtime.InteropServices;

namespace libmgba.NET
{
    public static unsafe partial class MGBA_Native
    {
        // Command Line API
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void usage(byte* arg0, byte* prologue, byte* epilogue, SubParser* subParsers, int nSubParsers);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void version(byte* arg0);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mArgumentsParse(Arguments* args, int argc, byte** argv, SubParser* subParsers, int nSubParsers);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mArgumentsApply(Arguments* args, SubParser* subParsers, int nSubParsers, IntPtr config);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mArgumentsDeinit(Arguments* args);

        // Logger API
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mLogSetDefaultLogger(Logger* logger);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mLogSetNoLogLogger();

        // Core API
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr mCoreFind(byte* path);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCore_Init(IntPtr core);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCore_DesiredVideoDimensions(IntPtr core, out uint width, out uint height);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCore_SetVideoBuffer(IntPtr core, IntPtr buffer, UIntPtr stride);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mCoreLoadFile(IntPtr core, byte* path);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr mCore_GetConfig(IntPtr core);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCoreConfigInit(IntPtr coreConfig, byte* port);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mCoreConfigLoad(IntPtr coreConfig);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCoreConfigSetDefaultValue(IntPtr coreConfig, byte* key, byte* value);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCoreLoadConfig(IntPtr core);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool mCoreConfigGetIntValue(IntPtr coreConfig, byte* key, IntPtr value);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCore_Reset(IntPtr core);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCore_SetKeys(IntPtr core, uint keys);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCore_RunFrame(IntPtr core);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern int mCore_Frequency(IntPtr core);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr mCore_GetAudioChannel(IntPtr core, int ch);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCoreConfigDeinit(IntPtr coreConfig);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mCore_Deinit(IntPtr core);

        // Audio API
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void blip_set_rates(IntPtr blip, double clockRate, double sampleRate);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern int blip_samples_avail(IntPtr blip);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern int blip_read_samples(IntPtr blip, IntPtr outData, int count, int stereo);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern void blip_clear(IntPtr blip);
        [DllImport("libmgba", CallingConvention = CallingConvention.Cdecl)]
        public static extern float GBAAudioCalculateRatio(float inputSampleRate, float desiredFPS, float desiredSampleRate);
    }
}

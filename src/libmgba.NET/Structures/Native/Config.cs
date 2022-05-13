#if _WIN64
    using size_t = UInt64;
#else
    using size_t = System.UInt32;
#endif

namespace libmgba.NET
{
    public enum CoreConfigLevel
    {
        CONFIG_LEVEL_DEFAULT = 0,
        CONFIG_LEVEL_CUSTOM = 1,
        CONFIG_LEVEL_OVERRIDE = 2,
    }

    public unsafe partial struct CoreConfig
    {
        public Configuration configTable;
        public Configuration defaultsTable;
        public Configuration overridesTable;
        public byte* port;
    }

    public struct CoreOptions
    {
        public string bios;
        public bool skipBios;
        public bool useBios;
        public int logLevel;
        public int frameskip;
        public bool rewindEnable;
        public int rewindBufferCapacity;
        public float fpsTarget;
        public size_t audioBuffers;
        public uint sampleRate;
        public int fullscreen;
        public int width;
        public int height;
        public bool lockAspectRatio;
        public bool lockIntegerScaling;
        public bool interframeBlending;
        public bool resampleVideo;
        public bool suspendScreensaver;
        public string shader;
        public string savegamePath;
        public string savestatePath;
        public string screenshotPath;
        public string patchPath;
        public string cheatsPath;

        public int volume;
        public bool mute;

        public bool videoSync;
        public bool audioSync;
    }
}

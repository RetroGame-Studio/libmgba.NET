
namespace libmgba.NET
{
	public struct CoreSync
    {
        public int videoFramePending;
        public bool videoFrameWait;
        public IntPtr videoFrameMutex;
        public IntPtr videoFrameAvailableCond;
        public IntPtr videoFrameRequiredCond;

        public bool audioWait;
        public IntPtr audioRequiredCond;
        public IntPtr audioBufferMutex;

        public float fpsTarget;
    };
}

// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace libmgba.NET.ConsoleTest
{
    internal class Program
    {
        static void RunGame(ArgumentsPtr argumentsPtr, SubParserPtr subParsersPtr, int nSubParsers)
        {
            IntPtr corePtr = MGBA.CoreFind(argumentsPtr.FileName);

            // Initialize the received core.
            MGBA.Core_Init(corePtr);

            // Get the dimensions required for this core and send them to the client.
            MGBA.Core_DesiredVideoDimensions(corePtr, out uint width, out uint height);

            int bufferSize = (int)width * (int)height * MGBA.BYTES_PER_PIXEL;

            Console.WriteLine($"{width} {height} {bufferSize}");

            Console.WriteLine("#1");

            // Create a video buffer and tell the core to use it.
            // If a core isn't told to use a video buffer, it won't render any graphics.
            // This may be useful in situations where everything except for displayed
            // output is desired.
            IntPtr frameBufferPtr = Marshal.AllocHGlobal(bufferSize);
            MGBA.Core_SetVideoBuffer(corePtr, frameBufferPtr, bufferSize, width);

            Console.WriteLine("#2");

            // Tell the core to actually load the file.
            MGBA.CoreLoadFile(corePtr, argumentsPtr.FileName);

            Console.WriteLine("#3");

            // Initialize the configuration system and load any saved settings for
            // this frontend. The second argument to mCoreConfigInit should either be
            // the name of the frontend, or NULL if you're not loading any saved
            // settings from disk.
            IntPtr coreConfigPtr = MGBA.CoreConfigGet(corePtr);

            Console.WriteLine("#4");

            MGBA.CoreConfigInit(coreConfigPtr, "test");

            Console.WriteLine("#5");

            MGBA.CoreConfigLoad(coreConfigPtr);

            Console.WriteLine("#6");

            // Take any settings overrides from the command line and make sure they get
            // loaded into the config system, as well as manually overriding the
            // "idleOptimization" setting to ensure cores that can detect idle loops
            // will attempt the detection.
            MGBA.ArgumentsApply(argumentsPtr, subParsersPtr, nSubParsers, coreConfigPtr);

            Console.WriteLine("#7");

            MGBA.CoreConfigSetDefaultValue(coreConfigPtr, "idleOptimization", "detect");

            Console.WriteLine("#8");

            // Tell the core to apply the configuration in the associated config object.
            MGBA.CoreLoadConfig(corePtr);

            Console.WriteLine("#9");

            // Set our logging level to be the logLevel in the configuration object.
            //int logLevel = 0;
            //IntPtr logLevelPtr = new IntPtr(logLevel);
            //MGBA.mCoreConfigGetIntValue(coreConfigPtr, "logLevel", logLevelPtr);

            Console.WriteLine("#10");

            // Reset the core. This is needed before it can run.
            MGBA.Core_Reset(corePtr);

            Console.WriteLine("#11");

            //float ratio = MGBA.GBA_AudioCalculateRatio(1, 60, 1);
            //IntPtr leftBlip = MGBA.Core_GetAudioChannel(corePtr, 0);
            //IntPtr rightBlip = MGBA.Core_GetAudioChannel(corePtr, 1);
            //int coreFrequency = MGBA.Core_GetFrequency(corePtr);
            //MGBA.BlipSetRates(leftBlip, coreFrequency, 44100 * ratio);
            //MGBA.BlipSetRates(rightBlip, coreFrequency, 44100 * ratio);
            //IntPtr leftBlipData = Marshal.AllocHGlobal(44100);

            // Emulate 60 Frames with no input.

            //Task.Factory.StartNew(() =>
            //{
            //    for (int i = 0; i < 60; i++)
            //    {
            //        int avail = MGBA.BlipSamplesAvail(leftBlip);
            //        MGBA.BlipReadSamples(leftBlip, leftBlipData, avail, false);
            //        // MGBA.BlipReadSamples(rightBlip, rightBlipData, avail, false);
            //        short[] samples = MGBA.SampleBufferGet(leftBlipData, avail);
            //    }
            //});

            for (int i = 0; i < 60; i++)
            {
                MGBA.Core_SetKeys(corePtr, 0);
                MGBA.Core_RunFrame(corePtr);
            }

            Console.WriteLine("#12");

            // Get buffer data
            MColor[,] frameBuffer = MGBA.FrameBufferPixelsGet(frameBufferPtr, (int)width, (int)height);

            Console.WriteLine("#13");

            // Creates a new image with empty pixel data. 
            using (Image<Rgba32> image = new((int)width, (int)height))
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        MColor pixel = frameBuffer[i, j];
                        image[j, i] = new Rgba32(pixel.R, pixel.G, pixel.B);
                    }
                }
                image.Save("frame.png");
            } // Dispose - releasing memory into a memory pool ready for the next image you wish to process.

            string imageFullPath = Path.GetFullPath("frame.png");

            Console.WriteLine("#14");

            if (OperatingSystem.IsWindows())
            {
                Process.Start("powershell", imageFullPath);
            }
            else
            {
                Process.Start("bash", $"-c \"open {imageFullPath}\"");
            }

            // Deinitialization associated with the core.

            Console.WriteLine("#15");

            MGBA.CoreConfigDeinit(coreConfigPtr);

            Console.WriteLine("#16");

            MGBA.Core_Deinit(corePtr);

            Console.WriteLine("#17");

            // Marshal.FreeHGlobal(leftBlipData);
            Marshal.FreeHGlobal(frameBufferPtr);
            MGBA.FreeNativeMemory();
        }

        static unsafe void  Main(string[] args)
        {
            var argv = Environment.GetCommandLineArgs();
            argv[0] = argv[0].Replace("dll", "exe");

            Arguments arguments = new Arguments();
            ArgumentsPtr argumentsPtr = new ArgumentsPtr(arguments);

            SubParser[] subParsers = Array.Empty<SubParser>();
            SubParserPtr subParsersPtr = new SubParserPtr(subParsers);

            bool parsed = MGBA.ArgumentsParse(argumentsPtr, argv, subParsersPtr, subParsers.Length);

            Console.WriteLine(argumentsPtr.FileName);

            if (string.IsNullOrEmpty(argumentsPtr.FileName))
            {
                parsed = false;
            }

            if (!parsed || arguments.ShowHelp)
            {
                MGBA.Usage(argv[0], null, null, subParsersPtr, subParsers.Length);
                MGBA.ArgumentsFree(argumentsPtr);
                return;
            }

            if (arguments.ShowVersion)
            {
                MGBA.Version(argv[0]);
                MGBA.ArgumentsFree(argumentsPtr);
                return;
            }

            MGBA.LogSetNoLog();

            RunGame(argumentsPtr, subParsersPtr, subParsers.Length);
        }
    }
}



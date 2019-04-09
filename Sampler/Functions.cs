using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.WindowsAzure.Storage.Blob;
using NAudio.Wave;

namespace Sampler
{
    public class Functions
    {
        public static void GenerateSample(
        [QueueTrigger("samplemaker")] String blobInfo,
        [Blob("musicgallery/songs/{queueTrigger}")] CloudBlockBlob inputBlob,
        [Blob("musicgallery/samples/{queueTrigger}")] CloudBlockBlob outputBlob, TextWriter logger)
        {
            //use log.WriteLine() rather than Console.WriteLine() for trace output
            logger.WriteLine("GenerateSample() started...");
            logger.WriteLine("Input blob is: " + blobInfo);

            // Open streams to blobs for reading and writing as appropriate.
            // Pass references to application specific methods
            using (Stream input = inputBlob.OpenRead())
            using (Stream output = outputBlob.OpenWrite())
            {
                CreateSample(input, output, 20);
                outputBlob.Metadata["Title"] = inputBlob.Metadata["Title"];

            }
            logger.WriteLine("GenerateSample() completed...");
        }

        private static void CreateSample(Stream input, Stream output, int duration)
        {
            using (var reader = new Mp3FileReader(input, wave => new NLayer.NAudioSupport.Mp3FrameDecompressor(wave)))
            {
                Mp3Frame frame;
                frame = reader.ReadNextFrame();
                int frameTimeLength = (int)(frame.SampleCount / (double)frame.SampleRate * 1000.0);
                int framesRequired = (int)(duration / (double)frameTimeLength * 1000.0);

                int frameNumber = 0;
                while ((frame = reader.ReadNextFrame()) != null)
                {
                    frameNumber++;

                    if (frameNumber <= framesRequired)
                    {
                        output.Write(frame.RawData, 0, frame.RawData.Length);
                    }
                    else break;
                }
            }
        }


    }
}

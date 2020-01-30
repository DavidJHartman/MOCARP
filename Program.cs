using System;
using System.Threading;
using System.Media;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
namespace MOCARP
{
    class Program
    {
        static void Main(string[] args)
        {
            var audioFile = new AudioFileReader("Sleep.wav");
            var outputDevice = new WaveOutEvent();
            var trimmed = new OffsetSampleProvider(audioFile);
            trimmed.SkipOver = TimeSpan.FromSeconds(15);

            outputDevice.Init(trimmed);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing) 
            {
                Thread.Sleep(1000);
                Random random = new Random();
                int num = random.Next(5000);
                audioFile.Position = num;
                outputDevice.Stop();
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }

        }
    }
}

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
            AudioParsing.WAV newWav = new AudioParsing.WAV("Don't Care.wav");
            var audioFile = new AudioFileReader("Don't Care.wav");
            var outputDevice = new WaveOutEvent();
            var trimmed = new OffsetSampleProvider(audioFile);
            trimmed.SkipOver = TimeSpan.FromSeconds(15);

            outputDevice.Init(audioFile);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing) 
            {
                Thread.Sleep(1000);
                outputDevice.Pause();
                Random random = new Random();
                int num = random.Next(checked((int)newWav.dataSize));
                audioFile.Position = num;
                outputDevice.Play();
            }

        }
    }
}

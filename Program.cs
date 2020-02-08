using System;
using System.Threading;
using System.IO;
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
            var ms = new MemoryStream(newWav.wavFile);
            var rs = new RawSourceWaveStream(ms, new WaveFormat((int)newWav.dwSamplesPerSec, (int)newWav.dwBitsPerSample, (int)newWav.wChannels));
            var outputDevice = new WaveOutEvent();

            outputDevice.Init(rs);
            outputDevice.Play();
            while (outputDevice.PlaybackState == PlaybackState.Playing) 
            {
                Thread.Sleep(1000);
                outputDevice.Pause();
                Random random = new Random();
                int num = random.Next(checked((int)newWav.dataSize));
                rs.Position = num;
                outputDevice.Play();
            }

        }
    }
}

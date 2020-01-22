using System;
using System.Media;

namespace MOCARP
{
    class Program
    {
        static void Main(string[] args)
        {
            AudioParsing.WAV testies = new AudioParsing.WAV();
            testies.loadWAVFile("Sleep.wav");
            Console.WriteLine("Beebis");
            testies.fileLength();
            SoundPlayer bebis = new SoundPlayer("Sleep.wav");
            bebis.Load();
            bebis.PlaySync();
        }
    }
}

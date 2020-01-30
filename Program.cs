using System;
using System.Media;

namespace MOCARP
{
    class Program
    {
        static void Main(string[] args)
        {
            //AudioParsing.WAV testWAV = new AudioParsing.WAV( "Sleep.wav" );
            AudioManipulation.AudioManipulator test = new AudioManipulation.AudioManipulator();
            test.playFrom("Sleep.wav", 45);
        }
    }
}

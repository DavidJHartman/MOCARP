using System;
using System.Media;
using NAudio.Wave;

namespace AudioManipulation {

    class AudioManipulator {
        // Class responsible for playing WAV from different starting point, trimming audio, and other TBD audio manipulation
        public void playFrom(string wavFilePath, double startPoint){
            var wavFile = new AudioFileReader(wavFilePath);
            //var trimmedAudio = new OffsetSampleProvider(wavFile);
            //trimmedAudio.SkipOver = TimeSpan.FromSeconds(startPoint);

            var player = new WaveOutEvent();
            player.Init(wavFile);
            player.Play();

        }

    }
}
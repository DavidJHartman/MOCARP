using System;
using System.IO;

namespace AudioParsing {

    class WAV{

        byte[] wavFile;

        public void loadWAVFile(string fileName) => wavFile = File.ReadAllBytes(fileName);
        public byte[] WavFile { get => wavFile; set => wavFile = value; }
    }

}
using System;
using System.IO;

namespace AudioParsing {

    class WAV{

        byte[] wavFile;

        public void loadWAVFile(string fileName) => wavFile = File.ReadAllBytes(fileName);
        public byte[] WavFile { get => wavFile; set => wavFile = value; }

        public void fileLength(){
            byte[] test = {0,0,0,0};
            for (int h = 0; h < 4; h++ ){
                test[h] = wavFile[h+4];
            }
            int i = BitConverter.ToInt32( test, 0);
            Console.WriteLine( i );
        }
    }

}
using System;
using System.IO;

namespace AudioParsing {

    class WAV{
        // Header information for the WAV File
        char[]  _sGroupID;
        uint dwFileLength;
        char[]  sRiffType;

        // Format information for the WAV File
        char[]  sGroupID;
        uint    dwChunkSize;
        ushort  wFormatTag;
        ushort  wChannels;
        uint    dwSamplesPerSec;
        uint    dwAvgBytesPerSec;
        ushort  wBlockAlign;
        uint    dwBitsPerSample;
    
        // The byte array for the actual wave file. This is unmodified and stores the byte data straight from the harddrive.
        byte[] wavFile;

        public WAV( string fileName ){

            wavFile = File.ReadAllBytes( fileName );
            _sGroupID = System.Text.Encoding.ASCII.GetString(wavFile[0..4]).ToCharArray();
            dwFileLength = BitConverter.ToUInt32( wavFile[4..8], 0 );

        }

        public void loadWAVFile(string fileName) => wavFile = File.ReadAllBytes(fileName);
        public byte[] WavFile { get => wavFile; set => wavFile = value; }


    }

}
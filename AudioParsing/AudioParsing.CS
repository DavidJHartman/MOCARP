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
        ushort    dwBitsPerSample;
    
        // The byte array for the actual wave file. This is unmodified and stores the byte data straight from the harddrive.
        byte[] wavFile;

        public WAV( string fileName ){

            wavFile = File.ReadAllBytes( fileName );
            // Header Parsing
            _sGroupID = System.Text.Encoding.ASCII.GetString(wavFile[0..4]).ToCharArray();
            dwFileLength = BitConverter.ToUInt32( wavFile[4..8], 0 );
            sRiffType = System.Text.Encoding.ASCII.GetString(WavFile[8..12]).ToCharArray();

            // Format Parsing
            sGroupID = System.Text.Encoding.ASCII.GetString(wavFile[12..16]).ToCharArray();
            dwChunkSize = BitConverter.ToUInt32( wavFile[16..20], 0 );
            wFormatTag = BitConverter.ToUInt16( wavFile[20..22], 0);
            wChannels = BitConverter.ToUInt16( wavFile[22..24], 0);
            dwSamplesPerSec = BitConverter.ToUInt32( wavFile[24..28], 0);
            dwAvgBytesPerSec = BitConverter.ToUInt32( wavFile[28..32], 0);
            wBlockAlign = BitConverter.ToUInt16( wavFile[32..34], 0);
            dwBitsPerSample = BitConverter.ToUInt16( wavFile[34..36], 0);

            Console.WriteLine( _sGroupID );
            Console.WriteLine( dwFileLength );
            Console.WriteLine( sRiffType );

            Console.WriteLine( sGroupID );
            Console.WriteLine( dwChunkSize );
            Console.WriteLine( wFormatTag );
            Console.WriteLine( wChannels );
            Console.WriteLine( dwSamplesPerSec );
            Console.WriteLine( dwAvgBytesPerSec );
            Console.WriteLine( wBlockAlign );
            Console.WriteLine( dwBitsPerSample );


        }

        public void loadWAVFile(string fileName) => wavFile = File.ReadAllBytes(fileName);
        public byte[] WavFile { get => wavFile; set => wavFile = value; }


    }

}
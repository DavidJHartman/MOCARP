using System;
using System.IO;
using MathNet.Numerics.IntegralTransforms;

namespace AudioParsing {

    class WAV{
        // Header information for the WAV File
        string  _sGroupID;
        uint dwFileLength;
        string  sRiffType;

        // Format information for the WAV File
        string  sGroupID;
        uint    dwChunkSize;
        ushort  wFormatTag;
        public ushort  wChannels;
        public uint    dwSamplesPerSec;
        uint    dwAvgBytesPerSec;
        ushort  wBlockAlign;
        public ushort  dwBitsPerSample;
        public uint    dataSize;
    
        // The byte array for the actual wave file. This is unmodified and stores the byte data straight from the harddrive.
        public byte[] wavFile;
        int[][] audio;

        public WAV( string fileName ){

            wavFile = File.ReadAllBytes( fileName );
            // Header Parsing
            if ((_sGroupID = System.Text.Encoding.ASCII.GetString(wavFile[0..4])) != "RIFF"){
                Console.WriteLine( "Header chunk missing or out of alignment");
                return;
            }
            dwFileLength = BitConverter.ToUInt32( wavFile[4..8], 0 );
            sRiffType = System.Text.Encoding.ASCII.GetString(WavFile[8..12]);

            // Format Parsing
            if ((sGroupID = System.Text.Encoding.ASCII.GetString(wavFile[12..16])) != "fmt "){
                Console.WriteLine( "fmt chunk missing or out of alignment");
                return;
            }
            dwChunkSize = BitConverter.ToUInt32( wavFile[16..20], 0 );
            wFormatTag = BitConverter.ToUInt16( wavFile[20..22], 0);
            wChannels = BitConverter.ToUInt16( wavFile[22..24], 0);
            dwSamplesPerSec = BitConverter.ToUInt32( wavFile[24..28], 0);
            dwAvgBytesPerSec = BitConverter.ToUInt32( wavFile[28..32], 0);
            wBlockAlign = BitConverter.ToUInt16( wavFile[32..34], 0);
            dwBitsPerSample = BitConverter.ToUInt16( wavFile[34..36], 0);

            // Data Parsing
            if ( System.Text.Encoding.ASCII.GetString(wavFile[36..40]) == "data" ){
                dataSize = BitConverter.ToUInt32( wavFile[40..44], 0);
                audio = new int[wChannels][];
                byte[] temp = new byte[dataSize];
                for ( int i = 0; i < wChannels; i++ ){
                    audio[i] = new int[dataSize / ( wChannels * dwBitsPerSample / 8)];
                }

                for ( int i = 0; i < audio[0].Length; i++ ){
                    for ( int j = 0; j < wChannels; j++ ) {
                        // WORKING ON PARSING BYTE DATA
                    }
                }
            }

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
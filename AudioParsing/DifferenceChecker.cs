using System;
using System.Collections.Generic;
using MathNet.Numerics.IntegralTransforms;

namespace AudioParsing {

    class DifferenceChecker {
        
        Dictionary< int, List<int> > matches;
        public void buildList( AudioParsing.WAV file, int threshold, int resolution ){

            // initialize data storage, chunked data is a collection of samples, where resolution is number of samples per chunk.
            // matches is a dictionary that stores a sample's index and a list of all other samples indicies that are deemed similar enough

            matches = new Dictionary<int, List<int>>();
            int[][] chunkedData  = new int[2][];

            for ( int i = 0; i+resolution < file.audio[0].Length; i+= resolution ) {
                
                // initialize chunkedData[0] as the chunk we are comparing the rest of the samples to
                // and initialize it to a slice of size resolution from i-i+resolution of samples
                chunkedData[0] = file.audio[0][i..(i+resolution)];

                // we have to initialize every new entry in matches to store a list, entries with an empty list will not jump anywhere
                matches[i] = new List<int>();

                for ( int j = 0; j+resolution < file.audio[0].Length; j += resolution ) {
                    
                    // if we're on the same sample, we skip it otherwise a sample could jump to itself
                    if ( i == j)
                        continue;
                    
                    chunkedData[1] = file.audio[0][j..(j+resolution)];

                    // here we have to go through chunkedData sample by sample and check the difference.
                    // if it is within a threshold decided by the user, they're similar enough to jump to.
                    for ( int k = 0; k < resolution; k++ ){

                        chunkedData[0][k] = chunkedData[0][k] - chunkedData[1][k];

                        if (Math.Abs(chunkedData[0][k]) > threshold){
                            break;
                        }
                        matches[i].Add(j);

                    }
                }
            }
            Console.WriteLine( "found all matches" );
        }

    }

}
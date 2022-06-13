using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ShortestPathIOA.ForwardStar_;
using static ShortestPathIOA.Constants;

namespace ShortestPathIOA
{
    class SietSR
    {
        public SietSR()
        {
            int tmpCountNodes = 342162;

            int tmpLoadedConnected = -1;

            ForwardStar tmpStar = new ForwardStar(tmpCountNodes);

            Dictionary<int, Vector2> tmpCoordinates = new Dictionary<int, Vector2>(9);

            using (StreamReader file = new StreamReader(@"SuradniceSR/SR_nodes.vec"))
            {
                int counter = 0;
                string ln;

                int tmpNumberEdge = -1;

                while ((ln = file.ReadLine()) != null)
                {


                    string[] tmpCoordinatesString;

                    // Cislo vrcholu
                    if (counter % 2 == 0)
                    {
                        string[] tmpParsed = ln.Split(' ');
                        tmpNumberEdge = Int32.Parse(tmpParsed[0]);
                    }
                    // Suradnice
                    else
                    {
                        tmpCoordinatesString = ln.Split(' ');
                        tmpCoordinates.Add(tmpNumberEdge, new Vector2(Single.Parse(tmpCoordinatesString[1], CultureInfo.InvariantCulture), Single.Parse(tmpCoordinatesString[3], CultureInfo.InvariantCulture)));
                        tmpStar.AddCoordinate(tmpNumberEdge, new Vector2(Single.Parse(tmpCoordinatesString[1], CultureInfo.InvariantCulture), Single.Parse(tmpCoordinatesString[3], CultureInfo.InvariantCulture)));
                    }

                    counter++;
                }
                file.Close();
            }

            int tmpCountOfMaxConnected = ((tmpCountNodes - 1) * (tmpCountNodes)) / 2;

            ConnectedEdges[] tmpConnectedEdges = new ConnectedEdges[tmpCountOfMaxConnected];

            using (StreamReader file = new StreamReader(@"SuradniceSR/SR_edges_incid.txt"))
            {
                int counter = 0;
                string ln;
                string ln2;

                StreamReader file2 = new StreamReader(@"SuradniceSR/SR_edges.atr");


                while ((ln = file.ReadLine()) != null && (ln2 = file2.ReadLine()) != null)
                {

                    string[] tmpConnectedString = ln.Split(' '); // 3 a 6
                    string[] tmpLengthString = ln2.Split(' '); // 1
                    tmpConnectedEdges[counter] = new ConnectedEdges(Int32.Parse(tmpConnectedString[3]), Int32.Parse(tmpConnectedString[6]));

                    if (counter == 35)
                    {
                        Console.WriteLine();
                    }

                    float tmpCoordinate = Single.Parse(tmpLengthString[1], CultureInfo.InvariantCulture);


                    tmpStar.Add(Int32.Parse(tmpConnectedString[3]), Int32.Parse(tmpConnectedString[6]), tmpCoordinate);
                    tmpStar.Add(Int32.Parse(tmpConnectedString[6]), Int32.Parse(tmpConnectedString[3]), tmpCoordinate);


                    counter++;
                    tmpLoadedConnected = counter;
                }
                file.Close();
            }


            tmpStar.Finalise();

            var test = tmpStar.Find(2, 3);

            var conneted = tmpStar.FindAllConnected(2);



            Console.WriteLine("--------------------------- Djikstra ---------------------------");
            Console.WriteLine();
            Djikstra tmpDjikstra = new Djikstra(tmpStar);

            ForwardStar tmpDjikstraStar = new ForwardStar(tmpCountNodes);
            ForwardStar tmpGbfsStar = new ForwardStar(tmpCountNodes);
            
            int tmpPerfDjikstra = 0;

            

            DistanceWPerformance tmpDistWPerf = tmpDjikstra.DjikstaShortestPath(0, 1500);
            tmpPerfDjikstra += tmpDistWPerf.Performance;
            tmpDjikstraStar.Add(0, 1500, tmpDistWPerf.Distance);
                


           

            Console.WriteLine();
            Console.WriteLine("--------------------------- Greedy Best First Search ---------------------------");
            Console.WriteLine();



            GreedyBestFirstSearch tmpGBFS = new GreedyBestFirstSearch(tmpStar, false);

            int tmpPerfGreedyBFS = 0;

            DistanceWPerformance tmpGBFSPerf = tmpGBFS.GreedyBFS(0, 1500, tmpStar);
            tmpPerfGreedyBFS += tmpGBFSPerf.Performance;
            tmpGbfsStar.Add(0, 8, tmpGBFSPerf.Distance);


            Console.WriteLine();
            Console.WriteLine("Djikstra: ");
            Console.WriteLine("Distance " + tmpDistWPerf.Distance);
            Console.WriteLine("Perf " + tmpPerfDjikstra);
            Console.WriteLine("Greedy BFS: ");
            Console.WriteLine("Distance " + tmpGBFSPerf.Distance);
            Console.WriteLine("Perf " + tmpPerfGreedyBFS);
          



        }
    }
    }

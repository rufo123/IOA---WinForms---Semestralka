using ShortestPathIOA.ForwardStar_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using IOA___WinForms.SemestralkaPart1;
using IOA___WinForms.SemestralkaPart1.ForwardStarSemestralka;
using static ShortestPathIOA.Constants;

namespace ShortestPathIOA
{
    public class TestovacieSiet
    {

        private ForwardStarSem aStar;

        public ForwardStarSem Star
        {
            get => aStar;
            set => aStar = value;
        }

        public TestovacieSiet()
        {

            int tmpCountNodes = 9;

            int tmpLoadedConnected = -1;

            aStar = new ForwardStarSem(tmpCountNodes);

            Dictionary<int, Vector2> tmpCoordinates = new Dictionary<int, Vector2>(9);

            using (StreamReader file = new StreamReader(@"suradnice.txt"))
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
                        tmpNumberEdge = Int32.Parse(ln);
                    }
                    // Suradnice
                    else
                    {
                        tmpCoordinatesString = ln.Split(',');
                        tmpCoordinates.Add(tmpNumberEdge, new Vector2(Int32.Parse(tmpCoordinatesString[0]), Int32.Parse(tmpCoordinatesString[1])));
                        aStar.AddCoordinate(tmpNumberEdge, new Vector2(Int32.Parse(tmpCoordinatesString[0]), Int32.Parse(tmpCoordinatesString[1])));
                    }

                    counter++;
                }
                file.Close();
            }

            int tmpCountOfMaxConnected = ((tmpCountNodes - 1) * (tmpCountNodes)) / 2;

            ConnectedEdges[] tmpConnectedEdges = new ConnectedEdges[tmpCountOfMaxConnected];

            using (StreamReader file = new StreamReader(@"vrcholy_spoj.txt"))
            {
                int counter = 0;
                string ln;


                while ((ln = file.ReadLine()) != null)
                {

                    string[] tmpConnectedString = ln.Split(',');
                    tmpConnectedEdges[counter] = new ConnectedEdges(Int32.Parse(tmpConnectedString[0]), Int32.Parse(tmpConnectedString[1]));

                    Vector2 tmpCoordinate1 = new Vector2();
                    Vector2 tmpCoordinate2 = new Vector2();

                    tmpCoordinates.TryGetValue(Int32.Parse(tmpConnectedString[0]), out tmpCoordinate1);
                    tmpCoordinates.TryGetValue(Int32.Parse(tmpConnectedString[1]), out tmpCoordinate2);

                    Node tmpNode1 = new Node(NodeType.Unspecified, 0, Int32.Parse(tmpConnectedString[0]),
                        aStar.GetCoordinate(Int32.Parse(tmpConnectedString[0])));
                    Node tmpNode2 = new Node(NodeType.Unspecified, 0, Int32.Parse(tmpConnectedString[1]),
                        aStar.GetCoordinate(Int32.Parse(tmpConnectedString[1])));

                    aStar.Add(tmpNode1, tmpNode2, Vector2.Distance(tmpCoordinate1, tmpCoordinate2));
                    aStar.Add(tmpNode2, tmpNode1, Vector2.Distance(tmpCoordinate1, tmpCoordinate2));

                    counter++;
                    tmpLoadedConnected = counter;
                }
                file.Close();
            }


            aStar.Finalise();
            

        }


    }
}

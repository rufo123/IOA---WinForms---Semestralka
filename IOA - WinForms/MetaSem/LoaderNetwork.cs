using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace IOA___WinForms.MetaSem
{
    class LoaderNetwork
    {
        // 1 - Length
        private Dictionary<int, MetaNode> aDictionaryNodes;

        private int aSize;

        public LoaderNetwork()
        {
        }

        public Dictionary<int, MetaNode> Load(out int parOutSize)
        {
            aDictionaryNodes = new Dictionary<int, MetaNode>();
            aSize = 0;

            string tmpFolderName = "MetaSem/";

            StreamReader tmpStreamReaderID = new StreamReader(tmpFolderName + "ID_Nodes.txt");
            StreamReader tmpStreamReaderPosition = new StreamReader(tmpFolderName + "COORDS_Nodes.txt");
            StreamReader tmpStreamReaderName = new StreamReader(tmpFolderName + "NAME_Nodes.txt");

            tmpStreamReaderID.DiscardBufferedData();
            tmpStreamReaderPosition.DiscardBufferedData();
            tmpStreamReaderName.DiscardBufferedData();


            aSize = Int32.Parse(tmpStreamReaderName.ReadLine());
            tmpStreamReaderID.ReadLine();
            tmpStreamReaderPosition.ReadLine();

            int tmpCounter = 1;

            while (!tmpStreamReaderID.EndOfStream && !tmpStreamReaderPosition.EndOfStream && !tmpStreamReaderName.EndOfStream)
            {



                int tmpID = Int32.Parse(tmpStreamReaderID.ReadLine(), CultureInfo.InvariantCulture);
                int tmpPosition = Int32.Parse(tmpStreamReaderPosition.ReadLine(), CultureInfo.InvariantCulture);
                string tmpName = tmpStreamReaderName.ReadLine();

                aDictionaryNodes.TryAdd(tmpCounter, new MetaNode(tmpID, tmpPosition, tmpName));

                tmpCounter++;


            }

            tmpStreamReaderID.Close();
            tmpStreamReaderPosition.Close();
            tmpStreamReaderName.Close();

            parOutSize = aSize;

            return aDictionaryNodes;

         
        }
    }
}

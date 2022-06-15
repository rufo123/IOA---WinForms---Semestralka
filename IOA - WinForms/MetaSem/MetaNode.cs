using System;
using System.Collections.Generic;
using System.Text;

namespace IOA___WinForms.MetaSem
{
    class MetaNode
    {
        private int aID;

        private int aPosition;

        private string aName;

        public int Id
        {
            get => aID;
            set => aID = value;
        }

        public int Position
        {
            get => aPosition;
            set => aPosition = value;
        }

        public string Name
        {
            get => aName;
            set => aName = value;
        }

        public MetaNode(int parId, int parPosition, string parName)
        {
            aID = parId;
            aPosition = parPosition;
            aName = parName;
        }
    }
}

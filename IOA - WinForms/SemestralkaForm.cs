using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using IOA___WinForms.SemestralkaPart1;
using IOA___WinForms.SemestralkaPart1.ForwardStarSemestralka;
using IOA___WinForms.SemestralkaPart1.ForwardStarShortest;
using Microsoft.VisualBasic;
using RTree;
using Point = System.Drawing.Point;
using Rectangle = RTree.Rectangle;
using Microsoft.VisualBasic;

namespace IOA___WinForms
{

    public partial class SemestralkaForm : Form
    {

        private int aSize;

        private int aZoomFactor;

        private Point aZoomedFrom;

        private Vector2 aRealCoordinates;

        private double aXOffset;

        private double aYOffset;

        private RTree<Node> aTestTree;

        private RTree.Rectangle aActualSizeRectangle;

        private Node aOldClicked;

        private Node aSecondClickedNode;

        private Edge aSelectedEdge;

        private ForwardStarSem aForwardStar;

        private DjikstraSem aDjikstraSem;

        private ForwardStarShortestPath aForwardStarShortestPath;

        private Clarke_Wrigth_Primary aClarkeWrigthPrimary;

        private Node aPrimarySource;

        private Routes aSelectedRoute;

        private List<Routes> aResultRoutes;

        private bool aDrawResults;

        public SemestralkaForm(ForwardStarSem parStar, DjikstraSem parDjikstra)
        {

            aSize = 100;

            aZoomedFrom = new Point(0, 0);

            InitializeComponent();

            this.pictureBox1.MouseWheel += pictureBox1_MouseWheel;

            aZoomFactor = 1;

            aRealCoordinates = new Vector2(0, 0);

            aXOffset = 25;
            aYOffset = 25;

            aTestTree = new RTree<Node>();


            aActualSizeRectangle = new Rectangle(0, 0, aSize, aSize, 0, 0);

            aOldClicked = null;

            aSecondClickedNode = null;

            aForwardStar = parStar;

            aSelectedEdge = new Edge();

            AddToRTree();

            aDjikstraSem = parDjikstra;

            aForwardStarShortestPath = new ForwardStarShortestPath();

            Random tmpRandom = new Random();

            int tmpCounter = 0;
            foreach (var zmazat in aForwardStar.GetListNodes())
            {
                if (tmpCounter == 0)
                {
                    zmazat.NodeType = NodeType.PrimarySource;
                }
                else
                {
                    zmazat.NodeType = NodeType.Customer;
                    zmazat.Capacity = tmpRandom.Next(1, 50);
                }

                tmpCounter++;
            }

            aClarkeWrigthPrimary = new Clarke_Wrigth_Primary(aForwardStarShortestPath);

            aPrimarySource = new Node();

            aSelectedRoute = new Routes();

            aResultRoutes = new List<Routes>();


        }

        public void AddToRTree()
        {


            foreach (var tmpNode in aForwardStar.GetListNodes())
            {
                aTestTree.Add(new RTree.Rectangle(tmpNode.Coordinates.X, tmpNode.Coordinates.Y, tmpNode.Coordinates.X, tmpNode.Coordinates.Y, 0, 0), tmpNode);
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Pixel;
            DrawHelpGrid(e.Graphics, aSize);
            DrawNodes(e.Graphics);
            DrawLines(e.Graphics);
            DrawAdjacentEdges(e.Graphics);
            DrawConnectedInfo();

            if (aDrawResults)
            {
                DrawResultsKlarke(e.Graphics, aSelectedRoute, aPrimarySource);
            }
        }


        private void DrawLines(Graphics graphics)
        {

            var test = aTestTree.Contains(aActualSizeRectangle);

            var pen1 = new Pen(Brushes.Black);
            var brush = new SolidBrush(Color.Black);

            int tmpWidth = aZoomFactor * 5;

            foreach (var tester in test)
            {

                Vector2 tmpGraphCoordinatesInitial = ConvertCoordinatesToMouseCoordinates(tester.Coordinates, tmpWidth);

                List<ForwardStarItemSem> tmpItems = aForwardStar.FindAllConnected(tester);

                if (tmpItems != null && tmpItems.Count > 0)
                {

                    foreach (var tmpConnectedTo in tmpItems)
                    {


                        Vector2 tmpGraphCoordinatesEnd = ConvertCoordinatesToMouseCoordinates(tmpConnectedTo.EndNode.Coordinates, tmpWidth);

                        graphics.DrawLine(pen1, tmpGraphCoordinatesInitial.X, tmpGraphCoordinatesInitial.Y, tmpGraphCoordinatesEnd.X, tmpGraphCoordinatesEnd.Y);

                    }
                }


            }

        }

        private void DrawResultsKlarke(Graphics graphics, Routes parRoute, Node parPrimarySource)
        {

            var test = aTestTree.Contains(aActualSizeRectangle);

            var pen1 = new Pen(Brushes.White, 1f);

            int tmpWidth = aZoomFactor * 5;



            Node tmpOldNode = parPrimarySource;

            pen1 = new Pen(parRoute.DrawnRouteColor, 1f);

            if (parRoute != null && parRoute.Route != null)
            {

                foreach (var tmpNode in parRoute.Route)
                {


                    Vector2 tmpGraphCoordinatesInitial =
                        ConvertCoordinatesToMouseCoordinates(tmpOldNode.Coordinates, tmpWidth);

                    Vector2 tmpGraphCoordinatesEnd =
                        ConvertCoordinatesToMouseCoordinates(tmpNode.Coordinates, tmpWidth);

                    graphics.DrawLine(pen1, tmpGraphCoordinatesInitial.X, tmpGraphCoordinatesInitial.Y,
                        tmpGraphCoordinatesEnd.X, tmpGraphCoordinatesEnd.Y);


                    graphics.DrawLine(pen1, tmpGraphCoordinatesInitial.X, tmpGraphCoordinatesInitial.Y,
                        tmpGraphCoordinatesEnd.X, tmpGraphCoordinatesEnd.Y);

                    tmpOldNode = tmpNode;

                }
            }


        }


        private void DrawNodes(Graphics graphics)
        {
            var test = aTestTree.Contains(aActualSizeRectangle);

            var pen1 = new Pen(Brushes.Red);
            var brush = new SolidBrush(Color.Red);

            int tmpWidth = aZoomFactor * 5;

            foreach (var tester in test)
            {

                Vector2 tmpGraphCoordinates = ConvertCoordinatesToMouseCoordinates(tester.Coordinates, tmpWidth);

                if (tester.Clicked && tester == aOldClicked)
                {
                    pen1.Brush = Brushes.Purple;
                    brush.Color = Color.Purple;
                }

                if (tester.Clicked && tester == aSecondClickedNode)
                {
                    pen1.Brush = Brushes.LawnGreen;
                    brush.Color = Color.LawnGreen;
                }

                graphics.DrawEllipse(pen1, tmpGraphCoordinates.X - tmpWidth / 2, tmpGraphCoordinates.Y - tmpWidth / 2, tmpWidth, tmpWidth);
                graphics.FillEllipse(brush, tmpGraphCoordinates.X - tmpWidth / 2, tmpGraphCoordinates.Y - tmpWidth / 2, tmpWidth, tmpWidth);

                pen1.Brush = Brushes.Red;
                brush.Color = Color.Red;

            }
        }


        public void DrawAdjacentEdges(Graphics graphics)
        {


            var pen1 = new Pen(Brushes.Green);
            var brush = new SolidBrush(Color.Green);

            int tmpWidth = aZoomFactor * 5;

            Node tmpSelectedNode = aOldClicked;

            if (tmpSelectedNode != null)
            {

                Vector2 tmpGraphCoordinatesInitial =
                    ConvertCoordinatesToMouseCoordinates(tmpSelectedNode.Coordinates, tmpWidth);

                List<ForwardStarItemSem> tmpItems = aForwardStar.FindAllConnected(tmpSelectedNode);

                if (tmpItems != null && tmpItems.Count > 0)
                {

                    foreach (var tmpConnectedTo in tmpItems)
                    {


                        Vector2 tmpGraphCoordinatesEnd =
                            ConvertCoordinatesToMouseCoordinates(tmpConnectedTo.EndNode.Coordinates, tmpWidth);

                        graphics.DrawLine(pen1, tmpGraphCoordinatesInitial.X, tmpGraphCoordinatesInitial.Y,
                            tmpGraphCoordinatesEnd.X, tmpGraphCoordinatesEnd.Y);

                    }
                }

            }

            var penNew = new Pen(Brushes.DeepSkyBlue);

            if (aSelectedEdge != null && aSelectedEdge.FirstNode != null && aSelectedEdge.SecondNode != null)
            {
                Vector2 tmpConvertedCoordinatesStart =
                    ConvertCoordinatesToMouseCoordinates(aSelectedEdge.FirstNode.Coordinates, tmpWidth);

                Vector2 tmpConvertedCoordinatesEnd =
                    ConvertCoordinatesToMouseCoordinates(aSelectedEdge.SecondNode.Coordinates, tmpWidth);

                graphics.DrawLine(penNew, tmpConvertedCoordinatesStart.X, tmpConvertedCoordinatesStart.Y,
                    tmpConvertedCoordinatesEnd.X, tmpConvertedCoordinatesEnd.Y);
            }
        }


        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            Vector2 tmpGraphLocation = new Vector2(e.Location.X - 25, e.Location.Y - 25);


            // 0 - 700

            float tmpOffsetX = (float)aXOffset;
            float tmpOffsetY = (float)aYOffset;

            float width = pictureBox1.ClientSize.Width - 50;

            float tmpRatio = width / (aSize / (float)aZoomFactor);

            Vector2 tmpRealLocation = new Vector2((tmpGraphLocation.X / tmpRatio) + (tmpOffsetX),
                ((tmpGraphLocation.Y / tmpRatio) + (tmpOffsetY)));

            Debug.WriteLine(tmpGraphLocation);
            Debug.WriteLine(aZoomFactor);
            Debug.WriteLine(tmpRealLocation);

            double tmpRangeToShow = aSize / (double)aZoomFactor;

            double tmpLeftOffsetNumber = aXOffset;

            aRealCoordinates = new Vector2((float)(tmpRealLocation.X), (float)(tmpRealLocation.Y));

            Debug.WriteLine(aRealCoordinates);


            if (e.Delta > 0)
            {
                aZoomFactor++;
            }
            else
            {
                if (aZoomFactor > 1)
                {
                    aZoomFactor--;
                }
            }



            pictureBox1.Invalidate();


        }

        public Vector2 ConvertCoordinatesToMouseCoordinates(Vector2 parNodeCoordinates, int parWidth)
        {
            float width = pictureBox1.ClientSize.Width - 50;

            float tmpRatio = width / (aSize / (float)aZoomFactor);

            float tmpOffsetX = (float)aXOffset;
            float tmpOffsetY = (float)aYOffset;

            return new Vector2((parNodeCoordinates.X - tmpOffsetX) * tmpRatio + 25, (parNodeCoordinates.Y - tmpOffsetY) * tmpRatio + 25);
        }

        public Vector2 ConvertCoordinatesToGraphCoordinates(Vector2 parMouseCoordinates, int parWidth)
        {
            Vector2 tmpGraphLocation = new Vector2(parMouseCoordinates.X - 25, parMouseCoordinates.Y - 25);

            float tmpOffsetX = (float)aXOffset;
            float tmpOffsetY = (float)aYOffset;

            float width = pictureBox1.ClientSize.Width - 50;

            float tmpRatio = width / (aSize / (float)aZoomFactor);

            Vector2 tmpRealLocation = new Vector2((tmpGraphLocation.X / tmpRatio) + (tmpOffsetX),
                ((tmpGraphLocation.Y / tmpRatio) + (tmpOffsetY)));

            return tmpRealLocation;
        }



        private void DrawHelpGrid(Graphics graphic, int parSize)
        {

            float tmpCountOfLines = 20;

            float tmpOffset = 25;

            float width = pictureBox1.ClientSize.Width - tmpOffset * 2;
            float height = pictureBox1.ClientSize.Height - tmpOffset * 2;


            float xShift = width / tmpCountOfLines;
            float yShift = height / tmpCountOfLines;

            float max = Math.Max(width, height);
            var pen1 = new Pen(Brushes.LightGray, 0.1f);
            var pen2 = new Pen(Brushes.DarkGray, 0.1f);
            bool mainLine = true;

            double tmpNumberLabelX = 0.00;
            double tmpNumberLabelY = 0.00;

            double tmpRangeToShow = aSize / (double)aZoomFactor;

            double tmpYOffsetNumber = 0.00;
            double tmpXOffsetNumber = 0.00;

            if (aZoomFactor > 1)
            {
                tmpYOffsetNumber = (aRealCoordinates.Y) - (tmpRangeToShow / (double)2);
                tmpXOffsetNumber = (aRealCoordinates.X) - (tmpRangeToShow / (double)2);
            }
            else
            {
                tmpYOffsetNumber = (aSize / (double)2) - (tmpRangeToShow / (double)2);
                tmpXOffsetNumber = (aSize / (double)2) - (tmpRangeToShow / (double)2);
            }

            aYOffset = tmpYOffsetNumber;
            aXOffset = tmpXOffsetNumber;



            tmpNumberLabelX = Math.Round(tmpXOffsetNumber, 2);
            tmpNumberLabelY = Math.Round(tmpYOffsetNumber, 2);


            for (float index = tmpOffset; index < max; index += xShift)
            {
                Pen pen = mainLine ? pen2 : pen1;

                // Make main line little longer
                int ext = mainLine ? 2 : 0;



                if (index <= height)
                {
                    // Y - Coordinate
                    graphic.DrawLine(pen, tmpOffset, index, width + ext, index);
                    if (mainLine)
                    {
                        graphic.DrawString(tmpNumberLabelY + "",
                            SystemFonts.MenuFont,
                            Brushes.Blue,
                            width + 5, index - 2);
                    }
                }

                if (index <= width)
                {
                    // X - Coordinate
                    graphic.DrawLine(pen, index, tmpOffset, index, height + ext);
                    if (mainLine)
                    {
                        graphic.DrawString(tmpNumberLabelX + "",
                            SystemFonts.MenuFont,
                            Brushes.Blue,
                            index - 3, height + 5);
                    }
                }
                mainLine = !mainLine;

                tmpNumberLabelX += tmpRangeToShow / (double)tmpCountOfLines;
                tmpNumberLabelY += tmpRangeToShow / (double)tmpCountOfLines;

                tmpNumberLabelX = Math.Round(tmpNumberLabelX, 2);
                tmpNumberLabelY = Math.Round(tmpNumberLabelY, 2);
            }

            aActualSizeRectangle = new Rectangle((float)tmpXOffsetNumber, (float)tmpYOffsetNumber, (float)tmpXOffsetNumber + (float)tmpRangeToShow, (float)tmpYOffsetNumber + (float)tmpRangeToShow, 0, 0);

        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            aSize = Int32.Parse(textBoxSize.Text);
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            switch (e.Button)
            {
                case MouseButtons.Left:

                    if (CheckInsideCircle(sender, e))
                    {
                        return;
                    }

                    CheckClickedEdge(sender, e);

                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:

                    Vector2 tmpRealCoordinates = ConvertCoordinatesToGraphCoordinates(new Vector2(e.X, e.Y), 0);

                    ShowDialog(tmpRealCoordinates);

                    break;
                case MouseButtons.Middle:

                    if (CheckInsideCircleConnectToNode(sender, e))
                    {
                        return;
                    }

                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }







        }

        public bool CheckInsideCircle(object sender, MouseEventArgs e)
        {
            var test = aTestTree.Contains(aActualSizeRectangle);

            int tmpWidth = aZoomFactor * 5;


            Vector2 tmpConvertedCoords = ConvertCoordinatesToGraphCoordinates(new Vector2(e.X, e.Y), tmpWidth);


            // Clicking on Node

            bool tmpDidBreak = false;

            foreach (var tester in test)
            {

                Vector2 tmpConvertedCoordsE = ConvertCoordinatesToMouseCoordinates(tester.Coordinates, 0);

                // IsInside((int)tmpConvertedCoords.X, (int)tmpConvertedCoords.X,(int)tester.Coordinates.X, (int)tester.Coordinates.Y, (int)tmpWidth / 2, (int)tmpWidth / 2))
                // InsideCircle((int)tester.Coordinates.X, (int)tester.Coordinates.X, (int)tmpWidth / 2, (int)tmpConvertedCoords.X, (int)tmpConvertedCoords.Y)

                if (InsideCircle((int)tmpConvertedCoordsE.X, (int)tmpConvertedCoordsE.Y, (int)tmpWidth, (int)e.X, (int)e.Y))
                {


                    if (aOldClicked != null)
                    {
                        aOldClicked.Clicked = false;
                    }

                    if (aSecondClickedNode != null)
                    {
                        aSecondClickedNode.Clicked = false;
                    }

                    tester.Clicked = true;
                    ShowNodeInfo(tester);
                    aOldClicked = tester;
                    pictureBox1.Invalidate();
                    tmpDidBreak = true;
                    if (aSelectedEdge != null)
                    {
                        aSelectedEdge = null;
                        GC.Collect();
                        aSelectedEdge = new Edge();
                        listBoxSelectedNode.Items.Clear();
                    }

                    break;

                }


            }

            if (tmpDidBreak)
            {
                return true;
            }

            return false;
        }

        public bool CheckInsideCircleConnectToNode(object sender, MouseEventArgs e)
        {
            var test = aTestTree.Contains(aActualSizeRectangle);

            int tmpWidth = aZoomFactor * 5;


            Vector2 tmpConvertedCoords = ConvertCoordinatesToGraphCoordinates(new Vector2(e.X, e.Y), tmpWidth);


            // Clicking on Node

            bool tmpDidBreak = false;

            foreach (var tester in test)
            {

                Vector2 tmpConvertedCoordsE = ConvertCoordinatesToMouseCoordinates(tester.Coordinates, 0);

                // IsInside((int)tmpConvertedCoords.X, (int)tmpConvertedCoords.X,(int)tester.Coordinates.X, (int)tester.Coordinates.Y, (int)tmpWidth / 2, (int)tmpWidth / 2))
                // InsideCircle((int)tester.Coordinates.X, (int)tester.Coordinates.X, (int)tmpWidth / 2, (int)tmpConvertedCoords.X, (int)tmpConvertedCoords.Y)

                if (InsideCircle((int)tmpConvertedCoordsE.X, (int)tmpConvertedCoordsE.Y, (int)tmpWidth, (int)e.X, (int)e.Y))
                {

                    if (aSecondClickedNode != null)
                    {
                        aSecondClickedNode.Clicked = false;
                    }

                    tester.Clicked = true;
                    ShowNodeInfo(tester);
                    aSecondClickedNode = tester;
                    pictureBox1.Invalidate();
                    tmpDidBreak = true;
                    if (aSelectedEdge != null)
                    {
                        aSelectedEdge = null;
                        GC.Collect();
                        aSelectedEdge = new Edge();
                        listBoxSelectedNode.Items.Clear();
                    }

                    break;

                }


            }

            if (tmpDidBreak)
            {
                return true;
            }

            return false;
        }

        public void CheckClickedEdge(object sender, MouseEventArgs e)
        {
            if (aOldClicked != null)
            {
                var tmpListConnected = aForwardStar.FindAllConnected(aOldClicked);

                Vector2 tmpConvertedCoordsStartNode = ConvertCoordinatesToMouseCoordinates(aOldClicked.Coordinates, 0);

                if (tmpListConnected != null && tmpListConnected.Count > 0)
                {

                    foreach (var tmpConnected in tmpListConnected)
                    {

                        Vector2 tmpConvertedCoordsEndNode = ConvertCoordinatesToMouseCoordinates(tmpConnected.EndNode.Coordinates, 0);

                        float tmpM = (tmpConvertedCoordsEndNode.Y - tmpConvertedCoordsStartNode.Y) /
                                     (tmpConvertedCoordsEndNode.X - tmpConvertedCoordsStartNode.X);
                        float tmpB = tmpConvertedCoordsStartNode.Y - tmpM * tmpConvertedCoordsStartNode.X;

                        float tmpDistance = tmpM * e.X + tmpB - e.Y;

                        if (tmpDistance > -5 && tmpDistance < 5)
                        {

                            aSelectedEdge = new Edge(aOldClicked, tmpConnected.EndNode,
                                aForwardStar.GetEuclideanDistance(aOldClicked.Id, tmpConnected.EndNode.Id));

                            ShowEdgeInfo(aSelectedEdge);

                        }
                    }
                }

            }


            pictureBox1.Invalidate();
        }

        public bool InsideCircle(int xc, int yc, int r, int x, int y)
        {
            int dx = xc - x;
            int dy = yc - y;
            return dx * dx + dy * dy <= r * r;
        }

        public bool IsInside(int mouseX, int mouseY, int rectX, int rectY, int width, int height)
        {
            return
                mouseX >= rectX &&
                mouseX <= rectX + width &&
                mouseY >= rectY &&
                mouseY <= rectY + height;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBoxNodeInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ShowNodeInfo(Node parNode)
        {
            listBoxNodeInfo.Show();
            listBoxNodeInfo.Items.Clear();
            listBoxNodeInfo.Items.Add("Information about clicked Node:");
            listBoxNodeInfo.Items.Add("");
            listBoxNodeInfo.Items.Add("Identifier: " + parNode.Id);
            listBoxNodeInfo.Items.Add("Coordinates: " + parNode.Coordinates);
            listBoxNodeInfo.Items.Add("Capacity: " + parNode.Capacity);
            listBoxNodeInfo.Items.Add("Node Type: " + parNode.NodeType);
            labelNodeID.Text = @"Id: " + parNode.Id;
            textBoxNodeCoords.Text = parNode.Coordinates.ToString();
            textBoxNodeCapac.Text = parNode.Capacity.ToString();
            labelNodeType.Text = @"Type: " + parNode.NodeType.ToString();

        }

        public void ShowEdgeInfo(Edge parEdge)
        {
            listBoxSelectedNode.Show();
            listBoxSelectedNode.Items.Clear();
            listBoxSelectedNode.Items.Add("Information about clicked Edge:");
            listBoxSelectedNode.Items.Add("");
            listBoxSelectedNode.Items.Add("Start Node: " + aSelectedEdge.FirstNode.Id);
            listBoxSelectedNode.Items.Add("End Node: " + aSelectedEdge.SecondNode.Id);
            listBoxSelectedNode.Items.Add("Distance: " + aSelectedEdge.Distance);
        }

        private void listBoxNodeInfo_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Vector2 tmpMouseCoordinates = ConvertCoordinatesToGraphCoordinates(new Vector2(e.Location.X, e.Location.Y), 0);

            textBoxMouseCoordinates.Text = @"< " + tmpMouseCoordinates.X + @" , " + tmpMouseCoordinates.Y + @" >";
        }


        public bool ShowDialog(Vector2 parCoordinates)
        {
            DialogBox testDialog = new DialogBox();

            testDialog.LabelInfo.Text = @"Súradnice Bodu";
            testDialog.TextBoxInput.Text = Math.Round(parCoordinates.X, 2) + " , " + Math.Round(parCoordinates.Y, 2);

            Vector2 tmpNewCoordinates = new Vector2();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.ShowDialog(this) == DialogResult.OK)
            {

                string[] tmpParsedCoordinatesString = testDialog.TextBoxInput.Text.Split(',');

                tmpNewCoordinates =
                    new Vector2(float.Parse(tmpParsedCoordinatesString[0], CultureInfo.InvariantCulture),
                        float.Parse(tmpParsedCoordinatesString[1], CultureInfo.InvariantCulture));

                // Read the contents of testDialog's TextBox.
                Debug.WriteLine(tmpNewCoordinates);
                testDialog.Dispose();

                Node tmpNewNode = new Node(NodeType.Unspecified, 0, aForwardStar.GetLastIdUsed() + 1, tmpNewCoordinates);

                aForwardStar.AddCoordinate(tmpNewNode.Id, tmpNewCoordinates);
                aForwardStar.AddAloneNode(tmpNewNode);
                aTestTree.Add(new Rectangle(tmpNewCoordinates.X, tmpNewCoordinates.Y, tmpNewCoordinates.X, tmpNewCoordinates.Y, 0, 0), tmpNewNode);
                aForwardStar.Finalise();
                pictureBox1.Invalidate();

                return true;
            }
            else
            {
                Debug.WriteLine("Canceled");
                testDialog.Dispose();
                return false;
            }


            return true;
        }

        private void buttonNodeType_Click(object sender, EventArgs e)
        {
            if (aOldClicked != null)
            {
                switch (aOldClicked.NodeType)
                {
                    case NodeType.PrimarySource:
                        aOldClicked.NodeType = NodeType.Customer;
                        break;
                    case NodeType.Customer:
                        aOldClicked.NodeType = NodeType.PossibleTransShipLocation;
                        break;
                    case NodeType.PossibleTransShipLocation:
                        aOldClicked.NodeType = NodeType.Unspecified;
                        break;
                    case NodeType.Unspecified:
                        aOldClicked.NodeType = NodeType.PrimarySource;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            ShowNodeInfo(aOldClicked);
            pictureBox1.Invalidate();
        }


        public void DrawConnectedInfo()
        {

            bool tmpInvalidate = false;

            if (aOldClicked != null)
            {
                labelStartNode.Text = "Starting Node: " + aOldClicked.Id;
                tmpInvalidate = true;
            }

            if (aSecondClickedNode != null)
            {
                labelEndNode.Text = "Ending Node: " + aSecondClickedNode.Id;
                tmpInvalidate = true;
            }

            if (tmpInvalidate)
            {
                pictureBox1.Invalidate();
            }
        }

        private void buttonSaveNodeInfo_Click(object sender, EventArgs e)
        {
            string tmpTrimmedString = textBoxNodeCoords.Text.Trim('<', '>');
            string[] tmpCoordinateString = tmpTrimmedString.Split(',');
            Vector2 tmpVectorCoordinates =
                new Vector2(float.Parse(tmpCoordinateString[0], CultureInfo.InvariantCulture),
                    float.Parse(tmpCoordinateString[1], CultureInfo.InvariantCulture));

            aOldClicked.Coordinates = tmpVectorCoordinates;

            aOldClicked.Capacity = Int32.Parse(textBoxNodeCapac.Text, CultureInfo.InvariantCulture);

            pictureBox1.Invalidate();
        }

        private void SemestralkaForm_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Delete)
            {

                if (aSelectedEdge != null && aSelectedEdge.FirstNode != null && aSelectedEdge.SecondNode != null)
                {
                    // Je zvolená hrana
                    aForwardStar.DeleteEdge(aSelectedEdge);
                    pictureBox1.Invalidate();
                    return;

                }
                if (aOldClicked != null)
                {
                    aForwardStar.DeleteNode(aOldClicked);

                    aTestTree.Delete(new RTree.Rectangle(aOldClicked.Coordinates.X, aOldClicked.Coordinates.Y,
                        aOldClicked.Coordinates.X, aOldClicked.Coordinates.Y, 0, 0), aOldClicked);
                    aOldClicked = null;
                    pictureBox1.Invalidate();
                    // Je zvolený vrchol
                }

            }

        }

        private void buttonConnected_Click(object sender, EventArgs e)
        {
            if (aOldClicked != null && aSecondClickedNode != null)
            {
                aForwardStar.AddEdge(new Edge(aOldClicked, aSecondClickedNode, 0));
            }
        }

        private void buttonShortestPath_Click(object sender, EventArgs e)
        {

            aDjikstraSem.CalculateDistanceMatrix(aForwardStarShortestPath);

            labelAllNodesConnectedTrueFalse.Text = aForwardStarShortestPath.IsNetworkInterConnected().ToString();



        }

        private void buttonStartKlarke_Click(object sender, EventArgs e)
        {

            List<Routes> tmpRoutesList = new List<Routes>();

            aDjikstraSem.CalculateDistanceMatrix(aForwardStarShortestPath);

            labelConnNetworkClarkText.Text = aForwardStarShortestPath.IsNetworkInterConnected().ToString();



            List<Node> tmpListNodes = aForwardStar.GetListNodes();
            List<Node> tmpPrimarySources = new List<Node>();

            bool tmpCustomersOkay = true;

            int tmpPrimarySourceCounter = 0;
            int tmpCustomersCounter = 0;

            foreach (var tmpNode in tmpListNodes)
            {
                if (tmpNode.NodeType == NodeType.PrimarySource)
                {
                    tmpPrimarySourceCounter++;
                    tmpPrimarySources.Add(tmpNode);
                }

                else if (tmpNode.NodeType == NodeType.Customer)
                {
                    tmpCustomersCounter++;
                    if (tmpNode.Capacity <= 0)
                    {
                        tmpCustomersOkay = false;
                    }
                }
                else
                {
                    tmpCustomersOkay = false;
                }
            }
            if (tmpCustomersOkay)
            {
                labelCustomersText.Text = @"Customers: All Okay - Count: " + (tmpListNodes.Count - 1);
            }
            else if (tmpCustomersCounter == tmpListNodes.Count - 1)
            {
                labelCustomersText.Text = @"Customers: Missing " + (tmpListNodes.Count - 1 - tmpCustomersCounter);
            }

            if (tmpPrimarySourceCounter != 1)
            {
                labelPrimarySourceText.Text = @"Primary Source: " + @" Error, is " + tmpPrimarySourceCounter + @" must be 1";
            }
            else
            {
                labelPrimarySourceText.Text = @"Primary Source: " + tmpListNodes[0].Id;
            }

            if (tmpPrimarySourceCounter == 1 && tmpCustomersCounter == tmpListNodes.Count - 1 && tmpCustomersOkay && aForwardStarShortestPath.IsNetworkInterConnected() && numericUpDownK.Value > 0)
            {
                tmpRoutesList = aClarkeWrigthPrimary.CalculateCoefficients(tmpListNodes[0], Convert.ToInt32(Math.Round(numericUpDownK.Value, 0)));

                aPrimarySource = tmpPrimarySources[0];

                aDrawResults = true;

                aResultRoutes = tmpRoutesList;
            }



            listBoxRoutes.Items.Clear();

            for (int i = 0; i < tmpRoutesList.Count; i++)
            {
                string tmpRouteString = string.Empty;

                tmpRouteString += tmpPrimarySources[0].Id;

                for (int j = 0; j < tmpRoutesList[i].Route.Count; j++)
                {
                    tmpRouteString += " - " + tmpRoutesList[i].Route[j].Id;
                }

                tmpRouteString += " - " + tmpPrimarySources[0].Id + " ---------- Cost: " + tmpRoutesList[i].Capacity;

                listBoxRoutes.Items.Add(tmpRouteString);

            }



        }

        private void listBoxRoutes_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void listBoxRoutes_Click(object sender, EventArgs e)
        {
            if (listBoxRoutes.SelectedItem != null)
            {
                aSelectedRoute = aResultRoutes[listBoxRoutes.SelectedIndex];
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Txt File|*.txt";
            saveFileDialog1.Title = "Save Text File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
             

                aForwardStar.SaveFile(fs);

                fs.Close();
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Txt File|*.txt";
            openFileDialog.Title = "Save Text File";
            openFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (openFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)openFileDialog.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.


                aForwardStar.LoadFile(fs);

                fs.Close();
            }

            aTestTree = new RTree<Node>();
            
            AddToRTree();

            pictureBox1.Invalidate();

        }


        
    }
}

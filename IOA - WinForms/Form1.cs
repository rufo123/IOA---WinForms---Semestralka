using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShortestPathIOA;

namespace IOA___WinForms
{
    public partial class Form1 : Form
    {
        public Form1(TestovacieSiet parTestovaciaSiet)
        {
            aTestovacieSiet = parTestovaciaSiet;

            InitializeComponent();

            DrawNetwork();

            aMoveX = 0;
            aMoveY = 0;

            aRotation = 0;


        }

        public void DrawNetwork()
        {


            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(myBrush, new Rectangle(0, 0, 200, 300));
            myBrush.Dispose();
            formGraphics.Dispose();
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen tmpPen = new Pen(Color.Blue);

            float tmpSizeX = panel1.Size.Width;
            float tmpSizeY = panel1.Size.Height;

            float tmpXOffset = tmpSizeX / 3;
            float tmpYOffset = -1 * (tmpSizeY / 4);

            foreach (var itemNode in aTestovacieSiet.Star.GetListNodes())
            {
                Vector2 tmpCoordinate = Vector2.Zero;

                switch (aFunctionality)
                {
                    case 0:
                        tmpCoordinate = aTestovacieSiet.Star.GetCoordinate(itemNode.Id) * 3;
                        break;
                    case 1:

                        float tmpX = aTestovacieSiet.Star.GetCoordinate(itemNode.Id).X + aMoveX;
                        float tmpY = aTestovacieSiet.Star.GetCoordinate(itemNode.Id).Y + aMoveY;
                        tmpCoordinate = new Vector2(tmpX, tmpY) * 3;
                        break;
                    case 2:
                        float tmpXNotRotated = aTestovacieSiet.Star.GetCoordinate(itemNode.Id).X;
                        float tmpYNotRotated = aTestovacieSiet.Star.GetCoordinate(itemNode.Id).Y;

                        float tmpXRotateArount = 50;
                        float tmpYRotateAround = 50;

                        double tmpRotatedX = (tmpXNotRotated - tmpXRotateArount) * Math.Cos(aRotation) -
                            (tmpYNotRotated - tmpYRotateAround) * Math.Sin(aRotation) + tmpXRotateArount;

                        double tmpRotatedY = (tmpXNotRotated - tmpXRotateArount) * Math.Sin(aRotation) +
                            (tmpYNotRotated - tmpYRotateAround) * Math.Cos(aRotation) + tmpXRotateArount;

                        // double tmpRotatedX = tmpXNotRotated * Math.Cos(90) - tmpYNotRotated * Math.Sin(90);
                        // double tmpRotatedY = tmpXNotRotated * Math.Sin(90) + tmpYNotRotated * Math.Cos(90);
                        tmpCoordinate = new Vector2((float)tmpRotatedX, (float)tmpRotatedY) * 3;

                        break;
                }

                e.Graphics.DrawEllipse(tmpPen, tmpXOffset + tmpCoordinate.X - 5, tmpYOffset + tmpSizeY - tmpCoordinate.Y - 5, 10, 10);

                foreach (var itemNode2 in aTestovacieSiet.Star.FindAllConnected(itemNode))
                {
                    Vector2 tmpCoordinate2 = Vector2.Zero;


                    switch (aFunctionality)
                    {
                        case 0:
                            tmpCoordinate2 = aTestovacieSiet.Star.GetCoordinate(itemNode2.EndNode.Id) * 3;
                            break;
                        case 1:
                            float tmpX = aTestovacieSiet.Star.GetCoordinate(itemNode2.EndNode.Id).X + aMoveX;
                            float tmpY = aTestovacieSiet.Star.GetCoordinate(itemNode2.EndNode.Id).Y + aMoveY;
                            tmpCoordinate2 = new Vector2(tmpX, tmpY) * 3;
                            break;
                        case 2:
                            float tmpXNotRotated = aTestovacieSiet.Star.GetCoordinate(itemNode2.EndNode.Id).X;
                            float tmpYNotRotated = aTestovacieSiet.Star.GetCoordinate(itemNode2.EndNode.Id).Y;

                            Debug.WriteLine(tmpXNotRotated + " " + tmpYNotRotated);

                            float tmpXRotateArount = 50;
                            float tmpYRotateAround = 50;

                            double tmpRotatedX = (tmpXNotRotated - tmpXRotateArount) * Math.Cos(aRotation) -
                               (tmpYNotRotated - tmpYRotateAround) * Math.Sin(aRotation) + tmpXRotateArount;

                            

                            double tmpRotatedY = (tmpXNotRotated - tmpXRotateArount) * Math.Sin(aRotation) +
                                                 (tmpYNotRotated - tmpYRotateAround) * Math.Cos(aRotation) + tmpXRotateArount;

                            //  double tmpRotatedX = tmpXNotRotated * Math.Cos(90) - tmpYNotRotated * Math.Sin(90);
                            //  double tmpRotatedY = tmpXNotRotated * Math.Sin(90) + tmpYNotRotated * Math.Cos(90);
                            tmpCoordinate2 = new Vector2((float)tmpRotatedX, (float)tmpRotatedY) * 3;

                            Debug.WriteLine(tmpRotatedX + " " + tmpRotatedY);

                            break;
                    }


                    e.Graphics.DrawLine(tmpPen, tmpXOffset + tmpCoordinate.X, tmpYOffset + tmpSizeY - tmpCoordinate.Y, tmpXOffset + tmpCoordinate2.X, tmpYOffset + tmpSizeY - tmpCoordinate2.Y);

                }

            }
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            aFunctionality = 0;
            aMoveX = 0;
            aMoveY = 0;
            aRotation = 0;
            panel1.Invalidate();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            aFunctionality = 1;
            aMoveX += 20;
            aMoveY += 10;
            panel1.Invalidate();
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            aFunctionality = 2;
            aMoveX = 0;
            aMoveY = 0;
            aRotation += Math.PI * 90 / 180.0;

            panel1.Invalidate();
        }

    }
}

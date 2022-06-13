using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Numerics;
using System.Windows.Forms;
using IOA___WinForms;
using IOA___WinForms.MetodaSZRohu;
using IOA___WinForms.SemestralkaPart1;
using IOA___WinForms.SemestralkaPart1.ForwardStarSemestralka;
using RTree;
using ShortestPathIOA.ForwardStar_;
using static ShortestPathIOA.Constants;

namespace ShortestPathIOA
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            TestovacieSiet tmpTestovacieSiet = new TestovacieSiet();

            IOA___WinForms.SemestralkaPart1.DjikstraSem tmpDjikstraSem =
                new IOA___WinForms.SemestralkaPart1.DjikstraSem(tmpTestovacieSiet.Star);

   


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SemestralkaForm(tmpTestovacieSiet.Star, tmpDjikstraSem));


            // SZCorner tmpSzCorner = new SZCorner();}}
            // return;

            // PartialRecalculationsMethod tmpMetodaCiastocnychPrepoctov = new PartialRecalculationsMethod();

            //TestovacieSiet tmpTestovacieSiet = new TestovacieSiet();}}
            //  SietSR tmpSietSR = new SietSR();

            /* Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form1(tmpTestovacieSiet));
            */
        }
    }
}

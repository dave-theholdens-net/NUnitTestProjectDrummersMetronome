using NUnit.Framework;
using Drummers_metronome_Windows;
using System.Drawing;

namespace NUnitTest_Drummers_metronome_Windows
{
    
    public class BeatBoxTests
    {
        [Test]
        public void TestCreate()
        {
            BeatBox bb = new BeatBox();
            Assert.Pass();
        }
        [Test]
        public void TestPropertyAssignments()
        {
            BeatBox bb = new BeatBox();

            bb.Height = 1;
            Assert.IsTrue(bb.Height == 1);

            bb.Width = 2;
            Assert.IsTrue(bb.Width == 2);

            bb.Left = 3;
            Assert.IsTrue(bb.Left == 3);

            bb.Top = 5;
            Assert.IsTrue(bb.Top == 5);

            bb.GutterWidth = 6;
            Assert.IsTrue(bb.GutterWidth == 6);

            bb.IsActive = true;
            Assert.IsTrue(bb.IsActive);
            bb.IsActive = false;
            Assert.IsFalse(bb.IsActive);

            bb.ActiveColor = Color.FromName("Green");
            Assert.IsTrue(bb.ActiveColor == Color.FromName("Green"));
            bb.ActiveColor = Color.FromName("Red");
            Assert.IsTrue(bb.ActiveColor == Color.FromName("Red"));

            bb.InactiveColor = Color.FromName("Yellow");
            Assert.IsTrue(bb.InactiveColor == Color.FromName("Yellow"));
            bb.InactiveColor = Color.FromName("Purple");
            Assert.IsTrue(bb.InactiveColor == Color.FromName("Purple"));

        }


    }

    public class BeatBoxListTests
    {
        [Test]
        public void TestBoxSizing()
        {
            int boxTop;
            int boxLeft;
            int boxHeight;
            int boxWidth;
            int containerWidth = 800;
            int containerHeight = 250;
            int containerTop = 50;
            int containerLeft = 10;
            int gutter = 8;
            int beatsPerMeasure = 4;
            int ctr = 0;

            BeatBoxList bbl = new BeatBoxList(
                containerWidth,
                containerHeight,
                containerTop,     
                containerLeft,
                gutter,
                beatsPerMeasure);
            bbl.MakeBars();

            boxTop = containerTop + gutter;
            boxHeight = containerHeight - (gutter * 2);
            boxWidth = containerWidth / beatsPerMeasure - gutter;

            // Cycle through boxes (hard-coded default number of boxes is 4)
            foreach (BeatBox bb in bbl)
            {
                boxLeft = containerLeft + gutter + (containerWidth / beatsPerMeasure * ctr);
                Assert.IsTrue(bb.BarHeight == boxHeight);
                Assert.IsTrue(bb.BarWidth == boxWidth);
                Assert.IsTrue(bb.BarLeft == boxLeft);
                Assert.IsTrue(bb.BarTop == boxTop);
                ctr++;
            }

        }
    }
 
}

using Drummers_metronome_Windows;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest_Drummers_metronome_Windows
{
    public class BeepMakerTests
    {
        OutputDeviceList outDeviceList = new OutputDeviceList();

        [Test]
        public void TestCreate()
        {
            OutputDevice outDevice = outDeviceList.FirstOrDefault();
            BeepMaker bm = new BeepMaker(outDevice);
            Assert.Pass();
        }
        [Test]
        public void TestVolume()
        {
            OutputDevice outDevice = outDeviceList.FirstOrDefault();
            BeepMaker bm = new BeepMaker(outDevice);
            bm.Volume = 0.75F;
            Assert.IsTrue(bm.Volume == 0.75F);
        }
        [Test]
        public void TestDisposal()
        {
            OutputDevice outDevice = outDeviceList.FirstOrDefault();
            BeepMaker bm = new BeepMaker(outDevice);
            bm.Dispose();
            Assert.Pass();
        }
        [Test]
        public void TestBeatSound()
        {
            OutputDevice outDevice = outDeviceList.FirstOrDefault();
            BeepMaker bm = new BeepMaker(outDevice);
            bm.MakeBeatSound();
            Assert.Pass();
        }
        [Test]
        public void TestAccentSound()
        {
            OutputDevice outDevice = outDeviceList.FirstOrDefault();
            BeepMaker bm = new BeepMaker(outDevice);
            bm.MakeAccentSound();
            Assert.Pass();
        }
    }
}

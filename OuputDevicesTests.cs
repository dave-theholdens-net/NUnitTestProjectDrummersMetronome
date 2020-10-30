using NUnit.Framework;
using NAudio.Wave;

namespace NUnitTest_Drummers_metronome_Windows
{
    public class OutputDeviceTests
    {

        [Test]
        public void TestCreate()
        {
            OutputDevice od = new OutputDevice();
            od = new OutputDevice(1, "Test Device");
            Assert.IsTrue(od.DeviceNumber == 1 && od.DeviceName == "Test Device");
        }
        [Test]
        public void TestSetNameProperty()
        {
            OutputDevice od = new OutputDevice();
            od.DeviceName = "Test Name";
            Assert.AreEqual("Test Name", od.DeviceName);
        }
        [Test]
        public void TestSetIdProperty()
        {
            OutputDevice od = new OutputDevice();
            od.DeviceNumber = 12;
            Assert.AreEqual(12, od.DeviceNumber);
        }
        [Test]
        public void TestEquality()
        {
            OutputDevice od1 = new OutputDevice();
            od1.DeviceNumber = 12;
            od1.DeviceName = "Device 1";

            OutputDevice od2 = new OutputDevice();
            od2.DeviceNumber = 11;
            od2.DeviceName = "Device 2";

            OutputDevice od3 = new OutputDevice();

            Assert.IsTrue(od1.Equals(od1));
            Assert.IsFalse(od1.Equals(od2));
            Assert.IsFalse(od1.Equals(od3));

        }
    }

    public class OutputDeviceListTests
    {
        [Test]
        public void TestCreate()
        {
            var dl = new OutputDeviceList();
            Assert.IsTrue(dl.Count == WaveOut.DeviceCount);
        }
        [Test]
        public void TestTranscription()
        {
            var dl = new OutputDeviceList();
            for (int n = 0; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                Assert.IsTrue(dl.Exists(x => x.DeviceName == caps.ProductName));
            }
        }
        [Test]
        public void TestRefresh()
        {
            var dl = new OutputDeviceList();
            dl.Refresh();
            Assert.IsTrue(dl.Count == WaveOut.DeviceCount);
        }
    }
 
}
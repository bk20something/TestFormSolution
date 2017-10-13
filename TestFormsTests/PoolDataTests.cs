using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestForms;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForms.Tests
{
    [TestClass()]
    public class PoolDataTests
    {
        [TestMethod()]
        public void PoolDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PoolDataTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getXMLTest()
        {
            System.Diagnostics.Trace.WriteLine("TEST START");
            Solider testSolider1 = new Solider("Jeff", "Banister", "BA1234", false, 5.6, 125, 'M');
            PoolData testData1 = new PoolData(testSolider1,DateTime.Now,PoolData.Pool.CRCM);
            System.Diagnostics.Trace.WriteLine(testData1.getXML().ToString());
            Assert.Fail();
        }
    }
}
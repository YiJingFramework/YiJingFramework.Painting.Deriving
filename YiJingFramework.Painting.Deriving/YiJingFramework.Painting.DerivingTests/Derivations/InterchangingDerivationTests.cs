using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Painting.Deriving.Derivations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Deriving.Derivations.Tests
{
    [TestClass()]
    public class InterchangingDerivationTests
    {
        readonly Random random = new Random();
        private IDerivation GetDerivation()
        {
            return new InterchangingDerivation();
        }
        [TestMethod()]
        public void DeriveTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var d = GetDerivation();
                var lineCount = 6;
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                List<Core.YinYang> r2 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                }
                r2.Add(r1[3]);
                r2.Add(r1[4]);
                r2.Add(r1[5]);
                r2.Add(r1[0]);
                r2.Add(r1[1]);
                r2.Add(r1[2]);
                Assert.AreEqual(new Core.Painting(r2), d.Derive(new Core.Painting(r1)));
            }
        }
    }
}
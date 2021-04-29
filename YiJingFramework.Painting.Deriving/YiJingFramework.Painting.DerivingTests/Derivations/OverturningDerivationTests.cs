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
    public class OverturningDerivationTests
    {
        readonly Random random = new Random();
        private IDerivation GetDerivation()
        {
            return new OverturningDerivation();
        }
        [TestMethod()]
        public void DeriveTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var d = GetDerivation();
                var lineCount = random.Next(0, 1000);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                }
                Assert.AreEqual(
                    new Core.Painting(((IEnumerable<Core.YinYang>)r1).Reverse()),
                    d.Derive(new Core.Painting(r1)));
            }
        }
    }
}
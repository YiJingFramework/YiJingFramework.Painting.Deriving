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
    public class FunctionDerivationTests
    {
        [TestMethod()]
        public void FunctionDerivationTest()
        {
            _ = GetCopying();
            _ = GetPureYang();
        }
        private IDerivation GetCopying()
        {
            return new FunctionDerivation(new CopyingDerivation());
        }
        private IDerivation GetPureYang()
        {
            return new FunctionDerivation((x) => {
                IEnumerable<Core.YinYang> Yangs()
                {
                    for (; ; )
                        yield return Core.YinYang.Yang;
                }
                return new Core.Painting(Yangs().Take(x.Count));
            });
        }


        readonly Random random = new Random();
        [TestMethod()]
        public void DeriveTest()
        {
            var cpy = GetCopying();
            for (int i = 0; i < 1000; i++)
            {
                var d = cpy;
                var lineCount = random.Next(0, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                }
                Assert.AreEqual(new Core.Painting(r1), d.Derive(new Core.Painting(r1)));
            }
            var py = GetPureYang();
            for (int i = 0; i < 1000; i++)
            {
                var d = py;
                var lineCount = random.Next(0, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                List<Core.YinYang> r2 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                    r2.Add(Core.YinYang.Yang);
                }
                Assert.AreEqual(new Core.Painting(r2), d.Derive(new Core.Painting(r1)));
            }
        }
    }
}
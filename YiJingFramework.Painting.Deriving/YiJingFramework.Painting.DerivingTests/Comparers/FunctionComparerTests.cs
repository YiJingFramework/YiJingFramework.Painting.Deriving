using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Painting.Deriving.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Derivations;
using YiJingFramework.Painting.Deriving.Extensions;

namespace YiJingFramework.Painting.Deriving.Comparers.Tests
{
    [TestClass()]
    public class FunctionComparerTests
    {
        private (IDerivation,IComparer<bool>) GetCopying()
        {
            return (new FunctionDerivation(new CopyingDerivation()),new FunctionComparer(new CopyingDerivation()));
        }
        private (IDerivation, IComparer<bool>) GetPureYang()
        {
            return (new FunctionDerivation((x) => {
                IEnumerable<Core.YinYang> Yangs()
                {
                    for (; ; )
                        yield return Core.YinYang.Yang;
                }
                return new Core.Painting(Yangs().Take(x.Count));
            }),new FunctionComparer((x) => {
                IEnumerable<Core.YinYang> Yangs()
                {
                    for (; ; )
                        yield return Core.YinYang.Yang;
                }
                return new Core.Painting(Yangs().Take(x.Count));
            }));
        }


        readonly Random random = new Random();

        [TestMethod()]
        public void FunctionComparerTest()
        {
            _ = GetCopying();
            _ = GetPureYang();
        }

        [TestMethod()]
        public void CompareTest()
        {
            var cpy = GetCopying();
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(1, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                }
                Assert.IsTrue(cpy.Item2.Compare(new Core.Painting(r1), cpy.Item1.Derive(new Core.Painting(r1))));
                Assert.IsFalse(cpy.Item2.Compare(new Core.Painting(r1).ChangeLines(0), cpy.Item1.Derive(new Core.Painting(r1))));
            }

            var py = GetPureYang();
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(1, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                List<Core.YinYang> r2 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                    r2.Add(Core.YinYang.Yang);
                }
                Assert.IsTrue(py.Item2.Compare(new Core.Painting(r1), py.Item1.Derive(new Core.Painting(r1))));
                Assert.IsTrue(py.Item2.Compare(new Core.Painting(r1).ChangeLines(0), py.Item1.Derive(new Core.Painting(r1))));
                Assert.IsFalse(py.Item2.Compare(new Core.Painting(r1), py.Item1.Derive(new Core.Painting(r1)).ChangeLines(0)));
            }
        }
    }
}
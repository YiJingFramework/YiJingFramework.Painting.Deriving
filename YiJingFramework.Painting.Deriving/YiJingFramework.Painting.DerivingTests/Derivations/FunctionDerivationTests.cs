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
                IEnumerable<Core.LineAttribute> Yangs()
                {
                    for (; ; )
                        yield return Core.LineAttribute.Yang;
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
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                }
                Assert.AreEqual(new Core.Painting(r1), d.Derive(new Core.Painting(r1)));
            }
            var py = GetPureYang();
            for (int i = 0; i < 1000; i++)
            {
                var d = py;
                var lineCount = random.Next(0, 10);
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                List<Core.LineAttribute> r2 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                    r2.Add(Core.LineAttribute.Yang);
                }
                Assert.AreEqual(new Core.Painting(r2), d.Derive(new Core.Painting(r1)));
            }
        }
    }
}
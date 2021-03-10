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
    public class LaterallyLinkingDerivationTests
    {
        readonly Random random = new Random();
        private IDerivation GetDerivation()
        {
            return new LaterallyLinkingDerivation();
        }
        [TestMethod()]
        public void DeriveTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var d = GetDerivation();
                var lineCount = random.Next(0, 10);
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                List<Core.LineAttribute> r2 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                    r2.Add((Core.LineAttribute)Convert.ToInt32(!Convert.ToBoolean(line)));
                }
                Assert.AreEqual(new Core.Painting(r2), d.Derive(new Core.Painting(r1)));
                Assert.AreEqual(new Core.Painting(r1), d.Derive(new Core.Painting(r2)));
            }
        }
    }
}
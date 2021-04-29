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
    public class ChangingDerivationTests
    {
        [TestMethod()]
        public void ChangingDerivationTest()
        {
            _ = new ChangingDerivation();
            _ = new ChangingDerivation(1, 2, 3);
            _ = new ChangingDerivation(new int[] { 1, 2, 3 });
            for (int i = 0; i < 100; i++) 
                _ = GetRandomDerivation();
        }

        readonly Random random = new Random();
        private (IDerivation,int[]) GetRandomDerivation()
        {
            var q = random.Next(0, 10);
            List<int> list = new List<int>();
            for(int i = 0;i < q;i++)
            {
                list.Add(random.Next(0, 10));
            }
            return (new ChangingDerivation(list), list.ToArray());
        }
        [TestMethod()]
        public void DeriveTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var (d, t) = GetRandomDerivation();
                var lineCount = random.Next(0, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                List<Core.YinYang> r2 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                    if (t.Contains(j))
                        r2.Add((Core.YinYang)Convert.ToInt32(!Convert.ToBoolean(line)));
                    else
                        r2.Add((Core.YinYang)line);
                }
                Assert.AreEqual(new Core.Painting(r2), d.Derive(new Core.Painting(r1)));
                Assert.AreEqual(new Core.Painting(r1), d.Derive(new Core.Painting(r2)));
            }
        }
    }
}
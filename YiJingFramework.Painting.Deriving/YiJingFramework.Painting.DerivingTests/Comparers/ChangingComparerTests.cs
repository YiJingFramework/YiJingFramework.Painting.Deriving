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
    public class ChangingComparerTests
    {
        readonly Random random = new Random();
        private (IDerivation, int[]) GetRandomDerivation()
        {
            var q = random.Next(0, 10);
            List<int> list = new List<int>();
            for (int i = 0; i < q; i++)
            {
                list.Add(random.Next(0, 10));
            }
            return (new ChangingDerivation(list), list.ToArray());
        }

        [TestMethod()]
        public void CompareTest()
        {
           var cc = new ChangingComparer();
            for (int i = 0; i < 1000; i++)
            {
                var (_, t) = GetRandomDerivation();
                var lineCount = random.Next(1, 10);
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                List<Core.LineAttribute> r2 = new List<Core.LineAttribute>();
                List<int> c = new List<int>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                    if (t.Contains(j))
                    {
                        r2.Add((Core.LineAttribute)Convert.ToInt32(!Convert.ToBoolean(line)));
                        c.Add(j);
                    }
                    else
                        r2.Add((Core.LineAttribute)line);
                }
                Assert.IsTrue(cc.Compare(new Core.Painting(r2), new Core.Painting(r1))
                    .SequenceEqual(c));
                Assert.IsFalse(cc.Compare(new Core.Painting(r1).ChangeLines(0), new Core.Painting(r2))
                    .SequenceEqual(c));
            }
        }
    }
}
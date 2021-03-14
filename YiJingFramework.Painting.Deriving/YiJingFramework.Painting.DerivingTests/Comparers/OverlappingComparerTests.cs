using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Painting.Deriving.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Deriving.Comparers.Tests
{
    [TestClass()]
    public class OverlappingComparerTests
    {
        readonly Random random = new Random();
        [TestMethod()]
        public void CompareTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = 6;
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                List<Core.LineAttribute> r2 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                }
                r2.Add(r1[1]);
                r2.Add(r1[2]);
                r2.Add(r1[3]);
                r2.Add(r1[2]);
                r2.Add(r1[3]);
                r2.Add(r1[4]);
                Assert.IsTrue(new OverlappingComparer().Compare(new Core.Painting(r1), new Core.Painting(r2)));
                if (new Core.Painting(r1).ToString() is not "000000" and not "111111")
                    Assert.IsFalse(new OverlappingComparer().Compare(new Core.Painting(r2), new Core.Painting(r1)));
            }
        }
    }
}
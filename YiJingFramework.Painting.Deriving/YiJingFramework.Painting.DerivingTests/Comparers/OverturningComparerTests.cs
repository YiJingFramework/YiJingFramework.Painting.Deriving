using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Painting.Deriving.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Extensions;

namespace YiJingFramework.Painting.Deriving.Comparers.Tests
{
    [TestClass()]
    public class OverturningComparerTests
    {
        readonly Random random = new Random();
        [TestMethod()]
        public void CompareTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(1, 1000);
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                }
                Assert.IsTrue(
                    new OverturningComparer().Compare(
                    new Core.Painting(((IEnumerable<Core.LineAttribute>)r1).Reverse()),
                    new Core.Painting(r1)));
                Assert.IsFalse(
                    new OverturningComparer().Compare(
                    new Core.Painting(((IEnumerable<Core.LineAttribute>)r1).Reverse()).ChangeLines(0),
                    new Core.Painting(r1)));
            }
        }
    }
}
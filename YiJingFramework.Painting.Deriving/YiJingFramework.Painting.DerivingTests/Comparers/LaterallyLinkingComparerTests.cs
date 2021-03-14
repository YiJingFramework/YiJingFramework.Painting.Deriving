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
    public class LaterallyLinkingComparerTests
    {
        readonly Random random = new Random();
        [TestMethod()]
        public void CompareTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(1, 10);
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                List<Core.LineAttribute> r2 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                    r2.Add((Core.LineAttribute)Convert.ToInt32(!Convert.ToBoolean(line)));
                }
                Assert.IsTrue(new LaterallyLinkingComparer().Compare(new Core.Painting(r2), new Core.Painting(r1)));
                Assert.IsFalse(new LaterallyLinkingComparer().Compare(new Core.Painting(r1).ChangeLines(0), new Core.Painting(r2)));
            }
        }
    }
}
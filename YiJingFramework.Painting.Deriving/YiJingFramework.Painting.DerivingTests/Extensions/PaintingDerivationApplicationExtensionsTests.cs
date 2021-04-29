using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Painting.Deriving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Derivations;

namespace YiJingFramework.Painting.Deriving.Extensions.Tests
{
    [TestClass()]
    public class PaintingDerivationApplicationExtensionsTests
    {
        readonly Random random = new Random();
        [TestMethod()]
        public void ApplyDerivationTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(0, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                }
                Assert.AreEqual(new Core.Painting(r1),
                    new Core.Painting(r1).ApplyDerivation(new CopyingDerivation()));
            }
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(0, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                List<Core.YinYang> r2 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                    r2.Add(Core.YinYang.Yang);
                }
                Assert.AreEqual(new Core.Painting(r2), new Core.Painting(r1).ApplyDerivation(
                   (x) =>
                   {
                       IEnumerable<Core.YinYang> Yangs()
                       {
                           for (; ; )
                               yield return Core.YinYang.Yang;
                       }
                       return new Core.Painting(Yangs().Take(x.Count));
                   }));
            }
        }

        [TestMethod()]
        public void ChangeLinesTest()
        {
            int[] GetRandomDerivation()
            {
                var q = random.Next(0, 10);
                List<int> list = new List<int>();
                for (int i = 0; i < q; i++)
                {
                    list.Add(random.Next(0, 10));
                }
                return list.ToArray();
            }

            for (int i = 0; i < 1000; i++)
            {
                var t = GetRandomDerivation();
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
                Assert.AreEqual(new Core.Painting(r2), new Core.Painting(r1).ChangeLines(t));
                Assert.AreEqual(new Core.Painting(r1), new Core.Painting(r2).ChangeLines((IEnumerable<int>)(t)));
            }
        }

        [TestMethod()]
        public void CopyTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(0, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                }
                Assert.AreEqual(new Core.Painting(r1), new Core.Painting(r1).Copy());
            }
        }

        [TestMethod()]
        public void ToLaterallyLinkedTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(0, 10);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                List<Core.YinYang> r2 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                    r2.Add((Core.YinYang)Convert.ToInt32(!Convert.ToBoolean(line)));
                }
                Assert.AreEqual(new Core.Painting(r2), new Core.Painting(r1).ToLaterallyLinked());
                Assert.AreEqual(new Core.Painting(r1), new Core.Painting(r2).ToLaterallyLinked());
            }
        }

        [TestMethod()]
        public void ToOverlappingTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = 6;
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                List<Core.YinYang> r2 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                }
                r2.Add(r1[1]);
                r2.Add(r1[2]);
                r2.Add(r1[3]);
                r2.Add(r1[2]);
                r2.Add(r1[3]);
                r2.Add(r1[4]);
                Assert.AreEqual(new Core.Painting(r2), new Core.Painting(r1).ToOverlapping());
            }
        }

        [TestMethod()]
        public void ToOverturnedTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(0, 1000);
                List<Core.YinYang> r1 = new List<Core.YinYang>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.YinYang)line);
                }
                Assert.AreEqual(
                    new Core.Painting(((IEnumerable<Core.YinYang>)r1).Reverse()),
                    new Core.Painting(r1).ToOverturned());
            }
        }
    }
}
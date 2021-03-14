using Microsoft.VisualStudio.TestTools.UnitTesting;
using YiJingFramework.Painting.Deriving.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Derivations;
using YiJingFramework.Painting.Deriving.Comparers;

namespace YiJingFramework.Painting.Deriving.Extensions.Tests
{
    [TestClass()]
    public class PaintingComparingExtensionsTests
    {
        readonly Random random = new Random();
        [TestMethod()]
        public void IsDerivedFromTest()
        {
            (IDerivation, IComparer<bool>) GetCopying()
            {
                return (new FunctionDerivation(new CopyingDerivation()), new FunctionComparer(new CopyingDerivation()));
            }
            (IDerivation, IComparer<bool>) GetPureYang()
            {
                return (new FunctionDerivation((x) => {
                    IEnumerable<Core.LineAttribute> Yangs()
                    {
                        for (; ; )
                            yield return Core.LineAttribute.Yang;
                    }
                    return new Core.Painting(Yangs().Take(x.Count));
                }), new FunctionComparer((x) => {
                    IEnumerable<Core.LineAttribute> Yangs()
                    {
                        for (; ; )
                            yield return Core.LineAttribute.Yang;
                    }
                    return new Core.Painting(Yangs().Take(x.Count));
                }));
            }

            var cpy = GetCopying();
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(1, 10);
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                }
                Assert.IsTrue(cpy.Item1.Derive(new Core.Painting(r1)).IsDerivedFrom(new Core.Painting(r1), cpy.Item1));
                Assert.IsFalse(cpy.Item1.Derive(new Core.Painting(r1)).IsDerivedFrom(new Core.Painting(r1).ChangeLines(0), cpy.Item1));
            }

            var py = GetPureYang();
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(1, 10);
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                List<Core.LineAttribute> r2 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                    r2.Add(Core.LineAttribute.Yang);
                }
                Assert.IsTrue(py.Item1.Derive(new Core.Painting(r1)).IsDerivedFrom(new Core.Painting(r1),
                    (x) => {
                        IEnumerable<Core.LineAttribute> Yangs()
                        {
                            for (; ; )
                                yield return Core.LineAttribute.Yang;
                        }
                        return new Core.Painting(Yangs().Take(x.Count));
                    }));
                Assert.IsTrue(py.Item1.Derive(new Core.Painting(r1)).IsDerivedFrom(new Core.Painting(r1).ChangeLines(0),
                    (x) => {
                        IEnumerable<Core.LineAttribute> Yangs()
                        {
                            for (; ; )
                                yield return Core.LineAttribute.Yang;
                        }
                        return new Core.Painting(Yangs().Take(x.Count));
                    }));
                Assert.IsFalse(py.Item1.Derive(new Core.Painting(r1)).ChangeLines(0).IsDerivedFrom(new Core.Painting(r1),
                    (x) => {
                        IEnumerable<Core.LineAttribute> Yangs()
                        {
                            for (; ; )
                                yield return Core.LineAttribute.Yang;
                        }
                        return new Core.Painting(Yangs().Take(x.Count));
                    }));
            }
        }

        [TestMethod()]
        public void GetDifferentLinesBetweenTest()
        {
            (IDerivation, int[]) GetRandomDerivation()
            {
                var q = random.Next(0, 10);
                List<int> list = new List<int>();
                for (int i = 0; i < q; i++)
                {
                    list.Add(random.Next(0, 10));
                }
                return (new ChangingDerivation(list), list.ToArray());
            }

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
                Assert.IsTrue(new Core.Painting(r1).GetDifferentLinesBetween(new Core.Painting(r2))
                    .SequenceEqual(c));
                Assert.IsFalse(new Core.Painting(r2).ChangeLines(0)
                    .GetDifferentLinesBetween(new Core.Painting(r1))
                    .SequenceEqual(c));
            }
        }

        [TestMethod()]
        public void IsTheSameAsTest()
        {
            for (int i = 0; i < 1000; i++)
            {
                var lineCount = random.Next(1, 10);
                List<Core.LineAttribute> r1 = new List<Core.LineAttribute>();
                for (int j = 0; j < lineCount; j++)
                {
                    var line = random.Next(0, 1);
                    r1.Add((Core.LineAttribute)line);
                }
                Assert.IsTrue(new Core.Painting(r1).IsTheSameAs(new Core.Painting(r1)));
                Assert.IsFalse(new Core.Painting(r1).ChangeLines(0).IsTheSameAs(new Core.Painting(r1)));
            }
        }

        [TestMethod()]
        public void IsInterchangedFromTest()
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
                r2.Add(r1[3]);
                r2.Add(r1[4]);
                r2.Add(r1[5]);
                r2.Add(r1[0]);
                r2.Add(r1[1]);
                r2.Add(r1[2]);
                Assert.IsTrue(new Core.Painting(r1).IsInterchangedFrom(new Core.Painting(r2)));
                Assert.IsFalse(new Core.Painting(r1).ChangeLines(4).IsInterchangedFrom(new Core.Painting(r2)));
            }
        }

        [TestMethod()]
        public void IsLaterallyLinkedWithTest()
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
                Assert.IsTrue(new Core.Painting(r1).IsLaterallyLinkedWith(new Core.Painting(r2)));
                Assert.IsFalse(new Core.Painting(r2).ChangeLines(0).IsLaterallyLinkedWith(new Core.Painting(r1)));
            }
        }

        [TestMethod()]
        public void IsOverlappedFromTest()
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
                Assert.IsTrue(new Core.Painting(r2).IsOverlappedFrom(new Core.Painting(r1)));
                if (new Core.Painting(r1).ToString() is not "000000" and not "111111")
                    Assert.IsFalse(new Core.Painting(r1).IsOverlappedFrom(new Core.Painting(r2)));
            }
        }

        [TestMethod()]
        public void IsOverturnedFromTest()
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
                    new Core.Painting(((IEnumerable<Core.LineAttribute>)r1).Reverse()).IsOverturnedFrom(
                    new Core.Painting(r1)));
                Assert.IsFalse(
                    new Core.Painting(((IEnumerable<Core.LineAttribute>)r1).Reverse()).ChangeLines(0).IsOverturnedFrom(
                    new Core.Painting(r1)));
            }
        }
    }
}
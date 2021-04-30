using System;
using System.Diagnostics;
using System.Linq;
using YiJingFramework.Core;
using YiJingFramework.Painting.Deriving;
using YiJingFramework.Painting.Deriving.Derivations;
using YiJingFramework.Painting.Deriving.Comparers;
using YiJingFramework.Painting.Deriving.Extensions;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            #region to derive from a painting
            _ = Painting.TryParse("110000", out Painting painting);
            Debug.Assert(painting is not null);

            // Traditionally:
            IDerivation derivation = new OverturningDerivation();
            Console.WriteLine($"110000 -o> {derivation.Derive(painting)}");
            Console.WriteLine();
            // Output: 110000 -o> 000011

            derivation = new ChangingDerivation(3, 4);
            Console.WriteLine($"110000 -c> {derivation.Derive(painting)}");
            Console.WriteLine();
            // Output: 110000 -c> 110110

            derivation = new FunctionDerivation((painting) =>
            {
                return new Painting(painting.Select((_, _) => YinYang.Yang));
            });
            // This derivation will turn all the lines to yang lines.
            Console.WriteLine($"110000 -f> {derivation.Derive(painting)}");
            Console.WriteLine();
            // Output: 110000 -f> 111111

            // With extension methods:
            Console.WriteLine($"110000 -o2> {painting.ToOverlapping()}");
            Console.WriteLine();
            // Output: 110000 -o2> 100000

            Console.WriteLine($"110000 -o2> " +
                $"{painting.ApplyDerivation((_) => new Painting(YinYang.Yang))}");
            Console.WriteLine();
            // Output: 110000 -o2> 1
            #endregion

            #region to compare two paintings
            _ = Painting.TryParse("110000", out Painting painting1);
            _ = Painting.TryParse("000011", out Painting painting2);
            _ = Painting.TryParse("111111", out Painting painting3);
            Debug.Assert(painting1 is not null && painting2 is not null);

            // Traditionally:
            IComparer<bool> comparer = new OverlappingComparer();
            Console.WriteLine(comparer.Compare(painting1, painting2));
            Console.WriteLine();
            // Output: False

            comparer = new OverturningComparer();
            Console.WriteLine(comparer.Compare(painting1, painting2));
            Console.WriteLine();
            // Output: True

            comparer = new FunctionComparer(derivation);
            // The current derivation will turn all the lines to yang lines,
            // and now the compare will check that.
            Console.WriteLine($"{comparer.Compare(painting1, painting3)} " +
                $"{comparer.Compare(painting3, painting1)}");
            Console.WriteLine();
            // Output: True False

            // With extension methods:
            Console.WriteLine(painting1.IsOverturnedFrom(painting2));
            Console.WriteLine();
            // Output: True

            foreach (var lineIndex in painting1.GetDifferentLinesBetween(painting2))
                Console.Write(lineIndex);
            Console.WriteLine();
            Console.WriteLine();
            // Output: 0145
            #endregion
        }
    }
}

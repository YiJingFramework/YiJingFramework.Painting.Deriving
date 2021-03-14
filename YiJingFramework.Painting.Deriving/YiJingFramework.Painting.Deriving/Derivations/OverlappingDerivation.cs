using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Exceptions;

namespace YiJingFramework.Painting.Deriving.Derivations
{
    /// <summary>
    /// 生成互卦的卦画变换过程。
    /// 这里的互卦指的是由本卦的第二、三、四、三、四、五爻重新组成的新卦。
    /// 这一变换过程只适用于六爻卦。
    /// Represents a paintings' derivation that will produce a overlapping hexagram
    /// which will be made up of -- the second line, the third line, the fourth line,
    /// then the third line again, the fourth line again and the fifth line -- of the original hexagram.
    /// This derivation can only be applied to hexagrams.
    /// </summary>
    public sealed class OverlappingDerivation : IDerivation
    {
        /// <summary>
        /// 变换指定的卦画，产生新卦画。
        /// Derive a new painting from the given one.
        /// </summary>
        /// <param name="from">
        /// 要变换的卦画。
        /// The painting to derive from.
        /// </param>
        /// <returns>
        /// 变换结果。
        /// The derived painting.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="from"/> 是 <c>null</c>.
        /// <paramref name="from"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="PaintingDerivationException">
        /// 传入的卦不是六爻卦。
        /// The given painting isn't a hexagram.
        /// </exception>
        public Core.Painting Derive(Core.Painting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            if (from.Count != 6)
                throw new PaintingDerivationException("This derivation can only be applied to hexagrams.");

            return new Core.Painting(
                from[2 - 1], from[3 - 1], from[4 - 1],
                from[3 - 1], from[4 - 1], from[5 - 1]);
        }
    }
}

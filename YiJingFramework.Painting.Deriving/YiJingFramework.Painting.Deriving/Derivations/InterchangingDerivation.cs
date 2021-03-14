using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Exceptions;

namespace YiJingFramework.Painting.Deriving.Derivations
{
    /// <summary>
    /// 生成交卦的卦画变换过程。
    /// 这一变换过程只适用于六爻卦。
    /// Represents a paintings' derivation that will produce a interchanged hexagram
    /// by swapping the upper trigram and the lower trigram.
    /// This derivation can only be applied to hexagrams.
    /// </summary>
    public sealed class InterchangingDerivation : IDerivation
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
                from[3], from[4], from[5],
                from[0], from[1], from[2]);
        }
    }
}

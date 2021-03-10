using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Deriving.Derivations
{
    /// <summary>
    /// 生成综卦的卦画变换过程。
    /// Represents a paintings' derivation that will produce a overturned hexagram
    /// which becomes by turning the original one upside down.
    /// </summary>
    public sealed class OverturningDerivation : IDerivation
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
        public Core.Painting Derive(Core.Painting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            return new Core.Painting(from.Reverse());
        }
    }
}

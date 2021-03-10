using System;
using CorePainting = YiJingFramework.Core.Painting;
using YiJingFramework.Painting.Deriving.Exceptions;

namespace YiJingFramework.Painting.Deriving
{
    /// <summary>
    /// 卦画变换过程。
    /// A paintings' derivation.
    /// </summary>
    public interface IDerivation
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
        /// 变换失败。这通常表示此变换过程不适用于指定的卦画。
        /// Derivation failed. This often means that the derivation doesn't fit the given painting.
        /// </exception>
        CorePainting Derive(CorePainting from);
    }
}

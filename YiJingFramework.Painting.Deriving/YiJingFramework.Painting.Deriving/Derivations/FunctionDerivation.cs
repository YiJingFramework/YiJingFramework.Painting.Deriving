using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Exceptions;
using CorePainting = YiJingFramework.Core.Painting;

namespace YiJingFramework.Painting.Deriving.Derivations
{
    /// <summary>
    /// 由传入方法决定的卦画变换过程。
    /// Represents a paintings' derivation that depends on a given function.
    /// </summary>
    public sealed class FunctionDerivation : IDerivation
    {
        /// <summary>
        /// 可以进行卦画变换的函数。
        /// A function that can be used to derive a painting from another.
        /// </summary>
        /// <param name="from">
        /// 要变换的卦画。
        /// The painting to derive from.
        /// </param>
        /// <returns>
        /// 变换结果。
        /// The derived painting.
        /// </returns>
        /// <exception cref="Exception">
        /// 任何异常都是可接受的。
        /// Any exception is acceptable.
        /// </exception>
        public delegate CorePainting DerivationFunc(CorePainting from);
        private readonly DerivationFunc function;

        /// <summary>
        /// 创建一个新实例。
        /// Initialize a new instance.
        /// </summary>
        /// <param name="function">
        /// 在变换时使用的函数。
        /// The function to be used when deriving.
        /// </param>
        public FunctionDerivation(DerivationFunc function)
        {
            if (function is null)
                throw new ArgumentNullException(nameof(function));
            this.function = function;
        }

        /// <summary>
        /// 创建一个新实例。
        /// 这种创建方式会将 <paramref name="derivation"/> 的 <see cref="IDerivation.Derive(CorePainting)"/> 作为变换函数。
        /// Initialize a new instance.
        /// This will use <paramref name="derivation"/>'s <see cref="IDerivation.Derive(CorePainting)"/> as the derivation function.
        /// </summary>
        /// <param name="derivation">
        /// 在变换时使用的变换过程。
        /// The derivation to be used when deriving.
        /// </param>
        public FunctionDerivation(IDerivation derivation)
        {
            if (derivation is null)
                throw new ArgumentNullException(nameof(derivation));
            this.function = derivation.Derive;
        }
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
        public CorePainting Derive(CorePainting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            try
            {
                return this.function(from);
            }
            catch(Exception e)
            {
                throw new PaintingDerivationException("An exception occurred when deriving.", e);
            }
        }
    }
}

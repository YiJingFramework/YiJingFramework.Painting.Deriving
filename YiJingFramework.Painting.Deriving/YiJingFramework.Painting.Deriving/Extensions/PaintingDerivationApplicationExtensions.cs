using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Derivations;
using YiJingFramework.Painting.Deriving.Exceptions;
using static YiJingFramework.Painting.Deriving.Derivations.FunctionDerivation;

namespace YiJingFramework.Painting.Deriving.Extensions
{
    /// <summary>
    /// 使卦画变换体验更佳。
    /// Make the experience of applying derivations for paintings better.
    /// </summary>
    public static class PaintingDerivationApplicationExtensions
    {
        #region FunctionDerivation
        /// <summary>
        /// 应用指定变换。
        /// Apply the given derivation.
        /// </summary>
        /// <param name="from">
        /// 要变换的卦画。
        /// The painting to derive from.
        /// </param>
        /// <param name="derivation">
        /// 变换。
        /// The derivation.
        /// </param>
        /// <returns>
        /// 变换结果。
        /// The derived painting.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="from"/> 或 <paramref name="derivation"/> 是 <c>null</c>.
        /// <paramref name="from"/> or <paramref name="derivation"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="PaintingDerivationException">
        /// 变换失败。这通常表示此变换过程不适用于指定的卦画。
        /// Derivation failed. This often means that the derivation doesn't fit the given painting.
        /// </exception>
        public static Core.Painting ApplyDerivation(
            this Core.Painting from, IDerivation derivation)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            if (derivation is null)
                throw new ArgumentNullException(nameof(derivation));
            return derivation.Derive(from);
        }

        /// <summary>
        /// 应用指定变换函数。
        /// Apply the given derivation function.
        /// </summary>
        /// <param name="from">
        /// 要变换的卦画。
        /// The painting to derive from.
        /// </param>
        /// <param name="derivationFunction">
        /// 变换函数。
        /// The derivation function.
        /// </param>
        /// <returns>
        /// 变换结果。
        /// The derived painting.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="from"/> 或 <paramref name="derivationFunction"/> 是 <c>null</c>.
        /// <paramref name="from"/> or <paramref name="derivationFunction"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="PaintingDerivationException">
        /// 变换失败。这通常表示此变换过程不适用于指定的卦画。
        /// Derivation failed. This often means that the derivation doesn't fit the given painting.
        /// </exception>
        public static Core.Painting ApplyDerivation(
            this Core.Painting from, DerivationFunc derivationFunction)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            if (derivationFunction is null)
                throw new ArgumentNullException(nameof(derivationFunction));
            var derivation = new FunctionDerivation(derivationFunction);
            return derivation.Derive(from);
        }
        #endregion

        #region ChangingDerivation
        /// <summary>
        /// 获取变卦卦画。
        /// Get the changed painting.
        /// </summary>
        /// <param name="from">
        /// 要变换的卦画。
        /// The painting to derive from.
        /// </param>
        /// <param name="indexesOfTheChangingLines">
        /// 变爻的序号。从零开始计。
        /// The indexes of the changing lines, starting from zero.
        /// </param>
        /// <returns>
        /// 变换结果。
        /// The derived painting.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="from"/> 或 <paramref name="indexesOfTheChangingLines"/> 是 <c>null</c>.
        /// <paramref name="from"/> or <paramref name="indexesOfTheChangingLines"/> is <c>null</c>.
        /// </exception>
        public static Core.Painting ChangeLines(
            this Core.Painting from, params int[] indexesOfTheChangingLines)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            if (indexesOfTheChangingLines is null)
                throw new ArgumentNullException(nameof(indexesOfTheChangingLines));
            var derivation = new ChangingDerivation(indexesOfTheChangingLines);
            return derivation.Derive(from);
        }
        /// <summary>
        /// 获取变卦卦画。
        /// Get the changed painting.
        /// </summary>
        /// <param name="from">
        /// 要变换的卦画。
        /// The painting to derive from.
        /// </param>
        /// <param name="indexesOfTheChangingLines">
        /// 变爻的序号。从零开始计。
        /// The indexes of the changing lines, starting from zero.
        /// </param>
        /// <returns>
        /// 变换结果。
        /// The derived painting.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="from"/> 或 <paramref name="indexesOfTheChangingLines"/> 是 <c>null</c>.
        /// <paramref name="from"/> or <paramref name="indexesOfTheChangingLines"/> is <c>null</c>.
        /// </exception>
        public static Core.Painting ChangeLines(
            this Core.Painting from, IEnumerable<int> indexesOfTheChangingLines)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            if (indexesOfTheChangingLines is null)
                throw new ArgumentNullException(nameof(indexesOfTheChangingLines));
            var derivation = new ChangingDerivation(indexesOfTheChangingLines);
            return derivation.Derive(from);
        }
        #endregion

        #region CopyingDerivation
        private static readonly CopyingDerivation copyingDerivation = new CopyingDerivation();
        /// <summary>
        /// 复制卦画。
        /// Copy the painting.
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
        public static Core.Painting Copy(
            this Core.Painting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            return copyingDerivation.Derive(from);
        }
        #endregion

        #region InterchangingDerivation
        private static readonly InterchangingDerivation interchangingDerivation = new InterchangingDerivation();

        /// <summary>
        /// 获取交卦卦画。
        /// Get the interchanged painting.
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
        public static Core.Painting ToInterchanged(
            this Core.Painting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            return interchangingDerivation.Derive(from);
        }
        #endregion

        #region LaterallyLinkingDerivation
        private static readonly LaterallyLinkingDerivation laterallyLinkingDerivation = new LaterallyLinkingDerivation();
        /// <summary>
        /// 获取错卦卦画。
        /// Get the laterally linked painting.
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
        public static Core.Painting ToLaterallyLinked(
            this Core.Painting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            return laterallyLinkingDerivation.Derive(from);
        }
        #endregion

        #region OverlappingDerivation
        private static readonly OverlappingDerivation overlappingDerivation = new OverlappingDerivation();
        /// <summary>
        /// 获取互卦卦画。
        /// Get the overlapping painting.
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
        public static Core.Painting ToOverlapping(
            this Core.Painting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            return overlappingDerivation.Derive(from);
        }
        #endregion

        #region OverturningDerivation
        private static readonly OverturningDerivation overturningDerivation = new OverturningDerivation();
        /// <summary>
        /// 获取综卦卦画。
        /// Get the overturned painting.
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
        public static Core.Painting ToOverturned(
            this Core.Painting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            return overturningDerivation.Derive(from);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Comparers;
using YiJingFramework.Painting.Deriving.Derivations;
using YiJingFramework.Painting.Deriving.Exceptions;
using static YiJingFramework.Painting.Deriving.Derivations.FunctionDerivation;

namespace YiJingFramework.Painting.Deriving.Extensions
{
    /// <summary>
    /// 使卦画比较体验更佳。
    /// Make the experience of comparing paintings better.
    /// </summary>
    public static class PaintingComparingExtensions
    {
        #region FunctionComparer
        /// <summary>
        /// 判断一个卦画是否由另一个卦画，通过指定的方式变换而来。
        /// Judge whether the object painting is derived from the basis painting, 
        /// through the given derivation.
        /// </summary>
        /// <param name="obj">
        /// 要判断的目标卦画。
        /// The object painting to judge.
        /// </param>
        /// <param name="basis">
        /// 判断的基础卦画。
        /// The basis.
        /// </param>
        /// <param name="derivation">
        /// 变换过程。
        /// The derivation.
        /// </param>
        /// <returns>
        /// 判断结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="derivation"/> 或 <paramref name="obj"/> 是 <c>null</c> 。
        /// <paramref name="basis"/> or <paramref name="derivation"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public static bool IsDerivedFrom(
            this Core.Painting obj, Core.Painting basis, IDerivation derivation)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            if (derivation is null)
                throw new ArgumentNullException(nameof(derivation));
            var functionComparer = new FunctionComparer(derivation);
            return functionComparer.Compare(basis, obj);
        }

        /// <summary>
        /// 判断一个卦画是否由另一个卦画，通过指定的方式变换而来。
        /// Judge whether the object painting is derived from the basis painting, 
        /// through the given derivation function.
        /// </summary>
        /// <param name="obj">
        /// 要判断的目标卦画。
        /// The object painting to judge.
        /// </param>
        /// <param name="basis">
        /// 作为判断基础的卦画。
        /// The paintings to be used as the comparing basis.
        /// </param>
        /// <param name="derivationFunction">
        /// 变换过程函数。
        /// The derivation function.
        /// </param>
        /// <returns>
        /// 判断结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="derivationFunction"/> 或 <paramref name="obj"/> 是 <c>null</c> 。
        /// <paramref name="basis"/> or <paramref name="derivationFunction"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public static bool IsDerivedFrom(
            this Core.Painting obj, Core.Painting basis, DerivationFunc derivationFunction)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            if (derivationFunction is null)
                throw new ArgumentNullException(nameof(derivationFunction));
            var functionComparer = new FunctionComparer(derivationFunction);
            return functionComparer.Compare(basis, obj);
        }
        #endregion

        #region ChangingComparer
        private static readonly ChangingComparer changingComparer = new ChangingComparer();

        /// <summary>
        /// 获取变爻的序号。
        /// Get the indexes of the changed lines.
        /// </summary>
        /// <param name="obj">
        /// 要判断的目标卦画。
        /// The object painting to judge.
        /// </param>
        /// <param name="basis">
        /// 作为判断基础的卦画。
        /// The paintings to be used as the comparing basis.
        /// </param>
        /// <returns>
        /// 判断结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="obj"/> 是 <c>null</c> 。
        /// <paramref name="basis"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public static int[] GetDifferentLinesBetween(
            this Core.Painting obj, Core.Painting basis)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            return changingComparer.Compare(basis, obj);
        }
        #endregion

        #region CopyingComparer
        private static readonly CopyingComparer copyingComparer = new CopyingComparer();

        /// <summary>
        /// 判断两个卦是否相同。
        /// Judge whether the two paintings are the same.
        /// </summary>
        /// <param name="obj">
        /// 要判断的目标卦画。
        /// The object painting to judge.
        /// </param>
        /// <param name="basis">
        /// 作为判断基础的卦画。
        /// The paintings to be used as the comparing basis.
        /// </param>
        /// <returns>
        /// 判断结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="obj"/> 是 <c>null</c> 。
        /// <paramref name="basis"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public static bool IsTheSameAs(
            this Core.Painting obj, Core.Painting basis)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            return copyingComparer.Compare(basis, obj);
        }
        #endregion

        #region InterchangingComparer
        private static readonly InterchangingComparer interchangingComparer = new InterchangingComparer();

        /// <summary>
        /// 判断目标卦是否是基础卦的变卦。
        /// Judge whether the object painting is interchanged from the basis.
        /// </summary>
        /// <param name="obj">
        /// 要判断的目标卦画。
        /// The object painting to judge.
        /// </param>
        /// <param name="basis">
        /// 作为判断基础的卦画。
        /// The paintings to be used as the comparing basis.
        /// </param>
        /// <returns>
        /// 判断结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="obj"/> 是 <c>null</c> 。
        /// <paramref name="basis"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public static bool IsInterchangedFrom(
            this Core.Painting obj, Core.Painting basis)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            return interchangingComparer.Compare(basis, obj);
        }
        #endregion

        #region LaterallyLinkingComparer


        private static readonly LaterallyLinkingComparer laterallyLinkingComparer = new LaterallyLinkingComparer();

        /// <summary>
        /// 判断目标卦是否是基础卦的错卦。
        /// Judge whether the object painting is laterally linked with the basis.
        /// </summary>
        /// <param name="obj">
        /// 要判断的目标卦画。
        /// The object painting to judge.
        /// </param>
        /// <param name="basis">
        /// 作为判断基础的卦画。
        /// The paintings to be used as the comparing basis.
        /// </param>
        /// <returns>
        /// 判断结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="obj"/> 是 <c>null</c> 。
        /// <paramref name="basis"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public static bool IsLaterallyLinkedWith(
            this Core.Painting obj, Core.Painting basis)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            return laterallyLinkingComparer.Compare(basis, obj);
        }
        #endregion

        #region OverlappingComparer
        private static readonly OverlappingComparer overlappingComparer = new OverlappingComparer();

        /// <summary>
        /// 判断目标卦是否是基础卦的互卦。
        /// Judge whether the object painting is overlapped from the basis.
        /// </summary>
        /// <param name="obj">
        /// 要判断的目标卦画。
        /// The object painting to judge.
        /// </param>
        /// <param name="basis">
        /// 作为判断基础的卦画。
        /// The paintings to be used as the comparing basis.
        /// </param>
        /// <returns>
        /// 判断结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="obj"/> 是 <c>null</c> 。
        /// <paramref name="basis"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public static bool IsOverlappedFrom(
            this Core.Painting obj, Core.Painting basis)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            return overlappingComparer.Compare(basis, obj);
        }
        #endregion

        #region OverlappingComparer
        private static readonly OverturningComparer overturningComparer = new OverturningComparer();

        /// <summary>
        /// 判断目标卦是否是基础卦的综卦。
        /// Judge whether the object painting is overturned from the basis.
        /// </summary>
        /// <param name="obj">
        /// 要判断的目标卦画。
        /// The object painting to judge.
        /// </param>
        /// <param name="basis">
        /// 作为判断基础的卦画。
        /// The paintings to be used as the comparing basis.
        /// </param>
        /// <returns>
        /// 判断结果。
        /// The result.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="obj"/> 是 <c>null</c> 。
        /// <paramref name="basis"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public static bool IsOverturnedFrom(
            this Core.Painting obj, Core.Painting basis)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            return overturningComparer.Compare(basis, obj);
        }
        #endregion
    }
}

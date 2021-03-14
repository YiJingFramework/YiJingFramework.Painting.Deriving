using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YiJingFramework.Painting.Deriving.Exceptions;
using static YiJingFramework.Painting.Deriving.Derivations.FunctionDerivation;

namespace YiJingFramework.Painting.Deriving.Comparers
{
    /// <summary>
    /// 变换比较。
    /// Represents a paintings' comparer that will returns a value
    /// which indicates whether the two paintings meet the given derivation.
    /// </summary>
    public sealed class FunctionComparer : IComparer<bool>
    {
        private readonly DerivationFunc function;

        /// <summary>
        /// 创建一个新实例。
        /// Initialize a new instance.
        /// </summary>
        /// <param name="function">
        /// 在变换时使用的函数。
        /// The function to be used when deriving.
        /// </param>
        public FunctionComparer(DerivationFunc function)
        {
            if (function is null)
                throw new ArgumentNullException(nameof(function));
            this.function = function;
        }

        /// <summary>
        /// 创建一个新实例。
        /// 这种创建方式会将 <paramref name="derivation"/> 的 <see cref="IDerivation.Derive(Core.Painting)"/> 作为变换函数。
        /// Initialize a new instance.
        /// This will use <paramref name="derivation"/>'s <see cref="IDerivation.Derive(Core.Painting)"/> as the derivation function.
        /// </summary>
        /// <param name="derivation">
        /// 在变换时使用的变换过程。
        /// The derivation to be used when deriving.
        /// </param>
        public FunctionComparer(IDerivation derivation)
        {
            if (derivation is null)
                throw new ArgumentNullException(nameof(derivation));
            this.function = derivation.Derive;
        }


        /// <summary>
        /// 比较卦画。
        /// Compare the paintings.
        /// </summary>
        /// <param name="basis">
        /// 作为比较标准的卦画。
        /// The painting to be the comparing basis.
        /// </param>
        /// <param name="obj">
        /// 要比较的卦画。
        /// The painting to be compared.
        /// </param>
        /// <returns>
        /// 变换结果。
        /// The derived painting.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="basis"/> 或 <paramref name="obj"/> 是 <c>null</c>.
        /// <paramref name="basis"/> or <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        public bool Compare(Core.Painting basis, Core.Painting obj)
        {
            if (basis is null)
                throw new ArgumentNullException(nameof(basis));
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));
            try
            {
                return this.function(basis).Equals(obj);
            }
            catch
            {
                return false;
            }
        }
    }
}

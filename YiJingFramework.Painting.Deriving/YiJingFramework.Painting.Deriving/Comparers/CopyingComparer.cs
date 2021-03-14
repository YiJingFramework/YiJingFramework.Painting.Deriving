using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Deriving.Comparers
{
    /// <summary>
    /// 相同比较。
    /// Represents a paintings' comparer that will return a value
    /// which indicates whether the two paintings are the same.
    /// </summary>
    public sealed class CopyingComparer : IComparer<bool>
    {
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
            return basis.Equals(obj);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Deriving
{
    /// <summary>
    /// 卦画比较器。
    /// A paintings' comparer.
    /// </summary>
    /// <typeparam name="TResult">
    /// 比较结果的类型。
    /// Type of the comparing result.
    /// </typeparam>
    public interface IComparer<TResult>
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
        TResult Compare(Core.Painting basis, Core.Painting obj);
    }
}

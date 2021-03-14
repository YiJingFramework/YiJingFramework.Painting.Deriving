using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Deriving.Derivations
{
    /// <summary>
    /// 生成变卦的卦画变换过程。
    /// Represents a paintings' derivation that will produce a changed hexagram
    /// where the attributes of some lines will be changed to the other.
    /// </summary>
    public sealed class ChangingDerivation : IDerivation
    {
        private readonly List<int> indexesOfTheChangingLines;

        /// <summary>
        /// 创建一个新实例。
        /// Initialize a new instance.
        /// </summary>
        /// <param name="indexesOfTheChangingLines">
        /// 变爻的序号。从零开始计。
        /// The indexes of the changing lines, starting from zero.
        /// </param>
        public ChangingDerivation(params int[] indexesOfTheChangingLines)
            : this((IEnumerable<int>)indexesOfTheChangingLines) { }
        /// <summary>
        /// 创建一个新实例。
        /// Initialize a new instance.
        /// </summary>
        /// <param name="indexesOfTheChangingLines">
        /// 变爻的序号。从零开始计。
        /// The indexes of the changing lines, starting from zero.
        /// </param>
        public ChangingDerivation(IEnumerable<int> indexesOfTheChangingLines)
        {
            if (indexesOfTheChangingLines is null)
                throw new ArgumentNullException(nameof(indexesOfTheChangingLines));
            this.indexesOfTheChangingLines = new();
            this.indexesOfTheChangingLines.AddRange(indexesOfTheChangingLines);
        }
        private IEnumerable<Core.LineAttribute> GetDerivedLines(Core.Painting from)
        {
            int i = 0;
            foreach (var line in from)
            {
                yield return (Core.LineAttribute)
                    ((int)line ^ Convert.ToInt32(this.indexesOfTheChangingLines.Contains(i++)));
            }
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
        public Core.Painting Derive(Core.Painting from)
        {
            if (from is null)
                throw new ArgumentNullException(nameof(from));
            return new Core.Painting(this.GetDerivedLines(from));
        }
    }
}

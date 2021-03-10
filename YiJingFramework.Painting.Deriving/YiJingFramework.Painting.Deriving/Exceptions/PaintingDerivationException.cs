using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YiJingFramework.Painting.Deriving.Exceptions
{
    /// <summary>
    /// 卦画变换失败。
    /// Paintings' derivation failed.
    /// </summary>
    [Serializable]
    public class PaintingDerivationException : Exception
    {
        /// <summary>
        /// 初始化一个新实例。
        /// Initialize a new instance.
        /// </summary>
        /// <param name="message">
        /// 异常消息。
        /// The message.
        /// </param>
        /// <param name="inner">
        /// 内部异常。
        /// The inner exception.
        /// </param>
        public PaintingDerivationException(string? message = null, Exception? inner = null)
            : base(message, inner) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PaintingDerivationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

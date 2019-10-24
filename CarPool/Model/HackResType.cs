using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public enum HackResType
    {
        /// <summary>
        /// 0, 成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 1, 客户端参数错误
        /// </summary>
        ParameterError = 1,
        /// <summary>
        /// 2, 数据错误
        /// </summary>
        DataError = 2
    }
}

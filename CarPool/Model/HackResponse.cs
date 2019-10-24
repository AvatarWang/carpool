using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class HackResponse : IHackResponse
    {
        public HackResponse()
        {
            SetHackResponse(HackResType.DataError, HackRspCode.HackRspCode_3000, "未知错误", null);
        }
        public HackResponse(HackResType rspType, HackRspCode rspCode, string rspDesc, dynamic body)
        {
            SetHackResponse(rspType, rspCode, rspDesc, body);
        }

        private void SetHackResponse(HackResType rspType, HackRspCode rspCode, string rspDesc, dynamic body)
        {
            this.HackResType = rspType;
            this.HackRspCode = rspCode;
            this.HackResDesc = rspDesc;
            this.HackBody = body;
        }

        #region 属性
        /// <summary>
        /// 响应类型
        /// </summary>
        public HackResType HackResType { get; set; }
        /// <summary>
        /// 响应代码
        /// </summary>
        public HackRspCode HackRspCode { get; set; }
        /// <summary>
        /// 响应描述
        /// </summary>
        public string HackResDesc { get; set; }
        /// <summary>
        /// 应答结果数据
        /// </summary>
        public dynamic HackBody { get; set; }
        #endregion
    }
}

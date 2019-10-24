using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Model
{
    [DataContract]
    public class HackResponse : IHackResponse
    {
        public HackResponse()
        {
            SetHackResponse(HackResType.Success, HackRspCode.HackRspCode_0001, "查无结果", new { });
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
        [DataMember]
        public HackResType HackResType { get; set; }
        /// <summary>
        /// 响应代码
        /// </summary>
        [DataMember]
        public HackRspCode HackRspCode { get; set; }
        /// <summary>
        /// 响应描述
        /// </summary>
        [DataMember]
        public string HackResDesc { get; set; }
        /// <summary>
        /// 应答结果数据
        /// </summary>
        [DataMember]
        public dynamic HackBody { get; set; }
        #endregion
    }
}

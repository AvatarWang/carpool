using Model;
using Service;
using System.Web.Http;


namespace CarPool.Controllers
{
    public class UserInfoController : ApiController
    {
        UserInfoService service = new UserInfoService();
        public HackResponse Post([FromBody] UserInfoParam param)
        {
            UserInfo userinfo = service.GetUserInfo(param);
            if (userinfo == null)
            {

                bool isSuc = service.AddUserInfo(param);
                return
                    new HackResponse
                    (HackResType.Success, HackRspCode.HackRspCode_0000, "查询成功",
                    new { isSucess = isSuc });
            }
            else
            {
                return
                   new HackResponse
                   (HackResType.DataError, HackRspCode.HackRspCode_3000,
                   "重复添加", new { });
            }
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        [HttpPost]
        public HackResponse Post([FromBody] UserInfoParam param)
        {
            UserInfo userinfo = UserInfoService.GetUserInfo(param);
            if (userinfo == null)
            {

                bool isSuc = UserInfoService.AddUserInfo(param);
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
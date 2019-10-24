using Microsoft.AspNetCore.Mvc;
using Model;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverInfoController : ControllerBase
    {
        [HttpPost]
        public HackResponse Post([FromBody] UserParam param)
        {
            // User user = MemberService.GetUser(param);
            return
                new HackResponse
                (HackResType.Success, HackRspCode.HackRspCode_0000, "查询成功", new { });
        }
    }
}
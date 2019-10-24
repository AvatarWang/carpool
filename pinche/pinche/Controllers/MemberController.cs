using Model;
using Service;
using System.Web.Http;


namespace CarPool.Controllers
{
    public class MemberController : ApiController
    {
        MemberService service = new MemberService();
        public HackResponse Post([FromBody] UserParam param)
        {
            User user = service.GetUser(param);
            return
                new HackResponse
                (HackResType.Success, HackRspCode.HackRspCode_0000, "查询成功", user);
        }
    }
}
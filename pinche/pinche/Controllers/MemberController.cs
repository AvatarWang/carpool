using Model;
using Service;
using System.Web.Http;


namespace CarPool.Controllers
{

    public class MemberController : ApiController
    {
        MemberService service = new MemberService();
        UserInfoService uservice = new UserInfoService();
        DriverInfoService dservice = new DriverInfoService();
        [HttpPost]
        public HackResponse Post([FromBody] UserParam param)
        {
            User user = service.GetUser(param);
            if (user != null)
            {
                LoginModel model = new LoginModel();
                model.user = user;
                UserInfoParam uparam = new UserInfoParam();
                uparam.UId = user.UId;
                UserInfo userinfo = uservice.GetUserInfo(uparam);
                if (userinfo != null)
                {
                    model.userInfo = userinfo;
                }
                DriverInfoParam dparam = new DriverInfoParam();
                dparam.DIUIID = user.UId;
                DriverInfo driverInfo = dservice.GetDriverInfo(dparam);
                if (driverInfo == null)
                {
                    model.driveInfo = driverInfo;
                }
                return
                new HackResponse
                (HackResType.Success, HackRspCode.HackRspCode_0000, "查询成功", model);
            }
            else
            {
                return
                    new HackResponse
                    (HackResType.DataError, HackRspCode.HackRspCode_0001, "查无结果", new { });
            }
        }
    }
}
using Model;
using Service;
using System.Web.Http;

namespace CarPool.Controllers
{
    public class DriverInfoController : ApiController
    {
        DriverInfoService service = new DriverInfoService();
        public HackResponse Post([FromBody] DriverInfoParam param)
        {
            DriverInfo driverInfo = service.GetDriverInfo(param);
            if (driverInfo == null)
            {

                bool isSuc = service.AddDriverInfo(param);
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

        // GET api/values/5
        [HttpGet]
        public HackResponse Get(long id)
        {
            DriverInfoParam param = new DriverInfoParam();
            param.DIUIID = id;
            DriverInfo driverInfo = service.GetDriverInfo(param);
            if (driverInfo == null)
            {

                return
                    new HackResponse
                    (HackResType.DataError, HackRspCode.HackRspCode_0001, "查无结果", new { });
            }
            else
            {
                return
                   new HackResponse
                   (HackResType.Success, HackRspCode.HackRspCode_0001,
                   "查询成功", driverInfo);
            }
        }
    }
}
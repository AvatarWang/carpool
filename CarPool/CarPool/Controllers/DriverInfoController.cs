using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverInfoController : ControllerBase
    {
        [HttpPost]
        public HackResponse Post([FromBody] DriverInfoParam param)
        {
            DriverInfo driverInfo = DriverInfoService.GetDriverInfo(param);
            if (driverInfo == null)
            {

                bool isSuc = DriverInfoService.AddDriverInfo(param);
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
using System.Collections.Generic;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpPost]
        public HackResponse Post([FromBody] UserParam param)
        {
            string sqlstring = "select * from user";
            List<User> users = HackMySqlHelper.TSqlQuery<User>(sqlstring, null, false);
            return
                new HackResponse
                (HackResType.Success, HackRspCode.HackRspCode_0000, "查询成功", users);
        }
    }
}

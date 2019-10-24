using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpPost]
        public HackResponse Post([FromBody] UserParam param)
        {
            User user = MemberService.GetUser(param);
            return
                new HackResponse
                (HackResType.Success, HackRspCode.HackRspCode_0000, "查询成功", user);
        }
    }
}
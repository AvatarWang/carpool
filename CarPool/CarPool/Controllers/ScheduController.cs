using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduController
    {
        ScheduService service = new ScheduService();
        //检查当前是否有行程
        //如果有行程 提示当前有行程 并且返回自己的匹配行程
        //如果无行程 到发布页面
        [HttpPost]
        public HackResponse Post([FromBody] ScheduParam param)
        {
            bool flag = service.AddSchedu(param);
            if (flag)
            {
                return new HackResponse(HackResType.Success, HackRspCode.HackRspCode_0000, "创建成功", true);
            }
            else
            {
                return new HackResponse(HackResType.Success, HackRspCode.HackRspCode_3000, "创建失败", false);
            }

        }
    }
}

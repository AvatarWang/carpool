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
        // GET api/values
        [HttpGet]
        public ActionResult<HackResponse> Get()
        {
            string sqlstring = "select * from user";
            List<User> users = HackMySqlHelper.TSqlQuery<User>(sqlstring, null, false);
            return new HackResponse(HackResType.Success, HackRspCode.HackRspCode_0000, "查询成功", users);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

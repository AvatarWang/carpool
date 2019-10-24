using DataAccess;
using Model;
using System.Collections.Generic;

namespace Service
{
    public class MemberService
    {
        HackMySqlHelper hackMySqlHelper = new HackMySqlHelper();
        public User GetUser(UserParam param)
        {
            User user = null;
            string sqlstring = "select * from user where UWorkNumber=@UWorkNumber " +
                "AND UPassWord=@UPassWord limit 1";
            var sqlParams = new
            {
                workNum = param.workNum,
                passWord = param.passWord
            };
            List<User> users = hackMySqlHelper.DapperQuery<User>(sqlstring, sqlParams, false);
            if (users != null && users.Count > 0)
            {
                user = users[0];
            }
            return user;
        }
    }
}

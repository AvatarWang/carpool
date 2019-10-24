using DataAccess;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public static class MemberService
    {
        public static User GetUser(UserParam param)
        {
            User user = null;
            string sqlstring = "select * from user where UWorkNumber=@UWorkNumber " +
                "AND UPassWord=@UPassWord limit 1";
            MySqlParameter[] sqlParams = new MySqlParameter[]
                {
                       new MySqlParameter("@UWorkNumber", MySqlDbType.VarChar),
                       new MySqlParameter("@UPassWord", MySqlDbType.VarChar)
                };
            sqlParams[0].Value = param.workNum;
            sqlParams[1].Value = param.passWord;
            List<User> users = HackMySqlHelper.TSqlQuery<User>(sqlstring, sqlParams, false);
            if (users != null && users.Count > 0)
            {
                user = users[0];
            }
            return user;
        }
    }
}

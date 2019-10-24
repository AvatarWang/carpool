using DataAccess;
using Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Service
{
    public static class UserInfoService
    {
        public static bool AddUserInfo(UserInfoParam param)
        {
            string sqlstring = @"INSERT INTO userinfo
(
UIUId,
UIHomeAddress,
UIWorkAddress,
UIHomeLat,
UIHomeLon,
UIWorkLat,
UIWorkLon,
UIRole)
VALUES
( 
    @UIUId,
    @UIHomeAddress,
    @UIWorkAddress,
    @UIHomeLat,
    @UIHomeLon,
    @UIWorkLat,
    @UIWorkLon,
    @UIRole)";
            MySqlParameter[] sqlParams = new MySqlParameter[]
                {
                       new MySqlParameter("@UIUId", MySqlDbType.Int64),
                       new MySqlParameter("@UIHomeAddress", MySqlDbType.VarChar),
                       new MySqlParameter("@UIWorkAddress", MySqlDbType.VarChar),
                       new MySqlParameter("@UIHomeLat", MySqlDbType.VarChar),
                       new MySqlParameter("@UIHomeLon", MySqlDbType.VarChar),
                       new MySqlParameter("@UIWorkLat", MySqlDbType.VarChar),
                       new MySqlParameter("@UIWorkLon", MySqlDbType.VarChar),
                       new MySqlParameter("@UIRole", MySqlDbType.Int32)
                };
            sqlParams[0].Value = param.UId;
            sqlParams[1].Value = param.UIHomeAddress;
            sqlParams[2].Value = param.UIWorkAddress;
            sqlParams[3].Value = param.UIHomeLat;
            sqlParams[4].Value = param.UIHomeLon;
            sqlParams[5].Value = param.UIWorkLat;
            sqlParams[6].Value = param.UIWorkLon;
            sqlParams[7].Value = param.UIRole;
            bool isSuc = HackMySqlHelper.TSqlExcute(sqlstring, sqlParams, false);
            return isSuc;
        }


        public static UserInfo GetUserInfo(UserInfoParam param)
        {
            UserInfo userinfo = null;
            string sqlstring = "select * from userinfo where UIUId=@UIUId " +
                " limit 1";
            MySqlParameter[] sqlParams = new MySqlParameter[]
                {
                       new MySqlParameter("@UIUId", MySqlDbType.Int64)
                };
            sqlParams[0].Value = param.UId;
            List<UserInfo> userinfos = HackMySqlHelper.TSqlQuery<UserInfo>(sqlstring, sqlParams, false);
            if (userinfos != null && userinfos.Count > 0)
            {
                userinfo = userinfos[0];
            }
            return userinfo;
        }
    }
}

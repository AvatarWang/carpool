using DataAccess;
using Model;
using System.Collections.Generic;

namespace Service
{
    public class UserInfoService
    {
        HackMySqlHelper hackMySqlHelper = new HackMySqlHelper();
        public bool AddUserInfo(UserInfoParam param)
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
            var sqlParams = new
            {
                UId = param.UId,
                UIHomeAddress = param.UIHomeAddress,
                UIWorkAddress = param.UIWorkAddress,
                UIHomeLat = param.UIHomeLat,
                UIHomeLon = param.UIHomeLon,
                UIWorkLat = param.UIWorkLat,
                UIWorkLon = param.UIWorkLon,
                UIRole = param.UIRole
            };

            bool isSuc = hackMySqlHelper.DapperExcute(sqlstring, sqlParams);
            return isSuc;
        }


        public UserInfo GetUserInfo(UserInfoParam param)
        {
            UserInfo userinfo = null;
            string sqlstring = "select * from userinfo where UIUId=@UIUId " +
                " limit 1";
            var sqlParams = new
            {
                UId = param.UId
            };
            List<UserInfo> userinfos = hackMySqlHelper.DapperQuery<UserInfo>(sqlstring, sqlParams, false);
            if (userinfos != null && userinfos.Count > 0)
            {
                userinfo = userinfos[0];
            }
            return userinfo;
        }
    }
}

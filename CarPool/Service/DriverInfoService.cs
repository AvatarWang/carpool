using DataAccess;
using Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Service
{
    public class DriverInfoService
    {
        public static bool AddDriverInfo(DriverInfoParam param)
        {
            string sqlstring = @"INSERT INTO driverinfo
(
DITelPhone,
DICarType,
DICarNumber,
DICardNo,
DIDrivingLicense,
DIDrivingPermit,
DICardFront,
DICardFace,
DIUIID)
VALUES
(
 @DITelPhone,
 @DICarType,
 @DICarNumber,
 @DICardNo,
 @DIDrivingLicense,
 @DIDrivingPermit,
 @DICardFront,
 @DICardFace,
 @DIUIID);
";
            MySqlParameter[] sqlParams = new MySqlParameter[]
                {
                       new MySqlParameter("@DITelPhone", MySqlDbType.VarChar),
                       new MySqlParameter("@DICarType", MySqlDbType.VarChar),
                       new MySqlParameter("@DICarNumber", MySqlDbType.VarChar),
                       new MySqlParameter("@DICardNo", MySqlDbType.VarChar),
                       new MySqlParameter("@DIDrivingLicense", MySqlDbType.VarChar),
                       new MySqlParameter("@DIDrivingPermit", MySqlDbType.VarChar),
                       new MySqlParameter("@DICardFront", MySqlDbType.VarChar),
                       new MySqlParameter("@DICardFace", MySqlDbType.VarChar),
                       new MySqlParameter("@DIUIID", MySqlDbType.Int64)
                };
            sqlParams[0].Value = param.DITelPhone;
            sqlParams[1].Value = param.DICarType;
            sqlParams[2].Value = param.DICarNumber;
            sqlParams[3].Value = param.DICardNo;
            sqlParams[4].Value = param.DIDrivingLicense;
            sqlParams[5].Value = param.DIDrivingPermit;
            sqlParams[6].Value = param.DICardFront;
            sqlParams[7].Value = param.DICardFace;
            sqlParams[8].Value = param.DIUIID;
            bool isSuc = HackMySqlHelper.TSqlExcute(sqlstring, sqlParams, false);
            return isSuc;
        }


        public static DriverInfo GetDriverInfo(DriverInfoParam param)
        {
            DriverInfo driverInfo = null;
            string sqlstring = "select * from driverinfo where DIUIID=@DIUIID " +
                " limit 1";
            MySqlParameter[] sqlParams = new MySqlParameter[]
                {
                       new MySqlParameter("@DIUIID", MySqlDbType.Int64)
                };
            sqlParams[0].Value = param.DIUIID;
            List<DriverInfo> driverInfos = HackMySqlHelper.TSqlQuery<DriverInfo>(sqlstring, sqlParams, false);
            if (driverInfos != null && driverInfos.Count > 0)
            {
                driverInfo = driverInfos[0];
            }
            return driverInfo;
        }
    }
}

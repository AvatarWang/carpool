using DataAccess;
using Model;
using System.Collections.Generic;

namespace Service
{
    public class DriverInfoService
    {
        HackMySqlHelper hackMySqlHelper = new HackMySqlHelper();
        public bool AddDriverInfo(DriverInfoParam param)
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
            var sqlParams = new
            {
                DITelPhone = param.DITelPhone,
                DICarType = param.DICarType,
                DICarNumber = param.DICarNumber,
                DICardNo = param.DICardNo,
                DIDrivingLicense = param.DIDrivingLicense,
                DIDrivingPermit = param.DIDrivingPermit,
                DICardFront = param.DICardFront,
                DICardFace = param.DICardFace,
                DIUIID = param.DIUIID
            };

            bool isSuc = hackMySqlHelper.DapperExcute(sqlstring, sqlParams);
            return isSuc;
        }


        public DriverInfo GetDriverInfo(DriverInfoParam param)
        {
            DriverInfo driverInfo = null;
            string sqlstring = "select * from driverinfo where DIUIID=@DIUIID " +
                " limit 1";
            var sqlParams = new
            {
                DIUIID = param.DIUIID
            };

            List<DriverInfo> driverInfos = hackMySqlHelper.DapperQuery<DriverInfo>(sqlstring, sqlParams, false);
            if (driverInfos != null && driverInfos.Count > 0)
            {
                driverInfo = driverInfos[0];
            }
            return driverInfo;
        }
    }
}

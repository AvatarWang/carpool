using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ScheduService
    {
        HackMySqlHelper hackMySqlHelper = new HackMySqlHelper();
        public bool AddSchedu(ScheduParam parameter)
        {
            string sql = @"INSERT INTO `calpool`.`schedu`(`SUIId`,`SStartAddress`,`SEndAddress`,`SStartLat`,`SEndLon`,`SEndLat`,
            `SStartLon`,`SRemark`,`SStartTime`,`SCreateTime`,`SStatus`,`SCount`,`SPrice`,`SType`)VALUES(@@,@SStartAddress,@SEndAddress,@SStartLat,
            @SEndLon,@SEndLat,@SStartLon,@SRemark,@SStartTime,@SStatus,@SCount,@SPrice,@SType)";
            var param = new
            {
                SType = parameter.type,
                SStartAddress = parameter.startAddress,
                SEndAddress = parameter.endAddress,
                SStartLat = parameter.startLat,
                SEndLon = parameter.endLon,
                SEndLat = parameter.endLat,
                SStartLon = parameter.startLon,
                SRemark = parameter.remark,
                SStartTime = parameter.startTime,
                SStatus = parameter.status,
                SCount = parameter.count,
                SPrice = parameter.price
            };

            return hackMySqlHelper.DapperExcute(sql, param);
        }
    }
}

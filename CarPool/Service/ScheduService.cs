using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Schedu> GetSchedu(ScheduParam parameter)
        {
            var startSql = @"
                SELECT *
                FROM  calpool.schedu
                WHERE     ROUND(
                        6378.138 * 2 * ASIN(
                            SQRT(
                                POW(
                                    SIN(
                                        (
                                           @lat * PI() / 180 - SStartLat * PI() / 180
                                        ) / 2
                                    ),
                                    2
                                ) + COS(@lat * PI() / 180) * COS(SStartLat * PI() / 180) * POW(
                                    SIN(
                                        (
                                            @lon * PI() / 180 - SStartLon * PI() / 180
                                        ) / 2
                                    ),
                                    2
                                )
                            )
                        ) * 1000
                    ) <=  10000";
            var starParam = new
            {
                lat = parameter.startLat,
                lon = parameter.startLon
            };
            var startScheduList = hackMySqlHelper.DapperQuery<Schedu>(startSql, starParam);
            var endSql = @"
                SELECT *
                FROM  calpool.schedu
                WHERE     ROUND(
                        6378.138 * 2 * ASIN(
                            SQRT(
                                POW(
                                    SIN(
                                        (
                                            @lat * PI() / 180 - SEndLat * PI() / 180
                                        ) / 2
                                    ),
                                    2
                                ) + COS(@lat * PI() / 180) * COS(SEndLat * PI() / 180) * POW(
                                    SIN(
                                        (
                                            @lon * PI() / 180 - SEndLon * PI() / 180
                                        ) / 2
                                    ),
                                    2
                                )
                            )
                        ) * 1000
                    ) <=  10000";
            var endParam = new
            {
                lat = parameter.startLat,
                lon = parameter.startLon
            };
            var endScheduList = hackMySqlHelper.DapperQuery<Schedu>(endSql, endParam);
            var scheduList = startScheduList.Intersect(endScheduList).Where(x=>Convert.ToDateTime(x.SStartTime)<Convert.ToDateTime(parameter.startTime).AddMinutes(15) && Convert.ToDateTime(x.SStartTime) > Convert.ToDateTime(parameter.startTime).AddMinutes(-15)).ToList();
            return scheduList;

        }
    }
}

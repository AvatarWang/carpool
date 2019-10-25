using DataAccess;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ScheduService
    {
        HackMySqlHelper hackMySqlHelper = new HackMySqlHelper();
        public bool AddSchedu(ScheduParam parameter)
        {
            string sql = @"INSERT INTO `calpool`.`schedu`(`SUIId`,`SStartAddress`,`SEndAddress`,`SStartLat`,`SEndLon`,`SEndLat`,
            `SStartLon`,`SRemark`,`SStartTime`,`SStatus`,`SCount`,`SPrice`,`SType`)VALUES(@SUIId,@SStartAddress,@SEndAddress,@SStartLat,
            @SEndLon,@SEndLat,@SStartLon,@SRemark,@SStartTime,@SStatus,@SCount,@SPrice,@SType)";
            var param = new
            {
                SUIId = parameter.userId,
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

        public List<ScheduNew> GetSchedu(ScheduParam parameter)
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
                lat = parameter.endLat,
                lon = parameter.endLon
            };
            var endScheduList = hackMySqlHelper.DapperQuery<Schedu>(endSql, endParam);
            List<ScheduNew> target = new List<ScheduNew>();
            MemberService mservice = new MemberService();
            foreach (var item in endScheduList)
            {
                foreach (var itemin in startScheduList)
                {
                    if (itemin.SId == item.SId)
                    {
                        ScheduNew itemnew = new ScheduNew();
                        itemnew.SId = itemin.SId;
                        itemnew.SUIId = itemin.SUIId;
                        itemnew.SStartAddress = itemin.SStartAddress;
                        itemnew.SEndAddress = itemin.SEndAddress;
                        itemnew.SStartLat = itemin.SStartLat;
                        itemnew.SEndLon = itemin.SEndLon;
                        itemnew.SEndLat = itemin.SEndLat;
                        itemnew.SStartLon = itemin.SStartLon;
                        itemnew.SRemark = itemin.SRemark;
                        itemnew.SStartTime = itemin.SStartTime;
                        itemnew.SCreateTime = itemin.SCreateTime;
                        itemnew.SStatus = itemin.SStatus;
                        itemnew.SCount = itemin.SCount;
                        itemnew.SPrice = itemin.SPrice;
                        itemnew.SType = itemin.SType;
                        UserParam uParam = new UserParam();
                        uParam.UId = itemin.SUIId;
                        User user = mservice.GetUserById(uParam);
                        if (user != null)
                        {
                            itemnew.NickName = user.UNick;
                        }
                        target.Add(itemnew);
                    }
                }
            }
            var scheduList = target.Where(x => x.SType == Convert.ToInt32(parameter.type)).ToList();
            return scheduList;

        }
    }
}

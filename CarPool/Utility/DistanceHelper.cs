using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public class DistanceHelper
    {
        //地球平均半径  
        private static double EARTH_RADIUS = 6378137;
        //把经纬度转为度（°）  
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /**  
         * 根据两点间经纬度坐标（double值），计算两点间距离，单位为米  
         * @param lng1  
         * @param lat1  
         * @param lng2  
         * @param lat2  
         * @return  
         */
        public static double getDistance(double lng1, double lat1, double lng2, double lat2)
        {
            double radLat1 = rad(lat1);
            double radLat2 = rad(lat2);
            double a = radLat1 - radLat2;
            double b = rad(lng1) - rad(lng2);
            double s = 2 * Math.Asin(
                 Math.Sqrt(
                     Math.Pow(Math.Sin(a / 2), 2)
                     + Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)
                 )
             );
            s = s * EARTH_RADIUS;
            s = Math.Round(s * 10000) / 10000;
            return s;
        }
    }
}

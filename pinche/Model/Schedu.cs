using System;

namespace Model
{
    public class Schedu
    {
        public long SId { get; set; }
        public long SUIId { get; set; }
        public string SStartAddress { get; set; }
        public string SEndAddress { get; set; }
        public string SStartLat { get; set; }
        public string SEndLon { get; set; }
        public string SEndLat { get; set; }
        public string SStartLon { get; set; }
        public string SRemark { get; set; }
        public DateTime SStartTime { get; set; }
        public DateTime SCreateTime { get; set; }
        public int SStatus { get; set; }
        public int SCount { get; set; }
        public string SPrice { get; set; }
        public int SType { get; set; }
    }
}
